using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//달리기, 한번 점프, 두번 점프, 슬라이드, 게임 오버

public class PlayerManager : MonoBehaviour
{
    public enum Status
    {
        Run = 1,
        Jump = 2,
        DoubleJump = 3,
        Slide = 4,
        Landing = 5,
        Hit = 6,
        Die = 7,
        FastRun = 8,
    }

    private Animator animator;
    private Rigidbody2D rigid;
    private BoxCollider2D boxCol;
    private CapsuleCollider2D capCol;

    private HitCamaraShake camera;
    private PetManager pet;
    private GameUIManager gameUIManager;

    private Status cookieStatus;

    //jump
    public int jumpCount = 2;
    public float jumpOneForce = 600f;
    public float jumpDoubleForce = 300f;

    public float cookieTime = 1f;
    private Vector2 originScale;

    private bool isGround = false;
    private bool isHit = false;
    private bool isDie = false;
    private bool isGiant = false;
    private bool isRush = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
        capCol = GetComponent<CapsuleCollider2D>();
        pet = GameObject.FindGameObjectWithTag("Pet").GetComponent<PetManager>();
        camera = GameObject.FindWithTag("MainCamera").GetComponent<HitCamaraShake>();
        gameUIManager = GameObject.FindGameObjectWithTag("GameUIManager").GetComponent<GameUIManager>();
        originScale = transform.localScale;
    }
    private void Start()
    {
        Init();
    }
    public void Init()
    {
        boxCol.enabled = true;
        capCol.enabled = false;

        isDie = false;
        isHit = false;
        isGiant = false;
        isRush = false;
        jumpCount = 0;

        CookieState(1);
    }

    public bool CookieState(int num)
    {
        if (cookieStatus == (Status)num)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Animation(int stateNumber)
    {
        cookieStatus = (Status)stateNumber;
        if (CookieState(6))
        {
            if (isHit) return;
            isHit = true;
            animator.SetBool("IsHit", true);
        }
        else if (CookieState(7))
        {
            animator.SetBool("IsDie", true);
        }
        animator.SetInteger("State", stateNumber);
    }
    public void Run() //Idle
    {
        boxCol.enabled = true;
        capCol.enabled = false;
    }
    public void Jump()
    {
        /* Ani */
        if( CookieState(6)|| CookieState(7))
        {
            return;
        }
        if (CookieState(2))
        {
            Animation(3);
        }
        else
        {
            Animation(2);
        }
        if (isGround && jumpCount > 0)
        {
            jumpCount--;

            rigid.velocity = new Vector2(rigid.velocity.x, 0f);
            rigid.AddForce(Vector2.up * jumpOneForce);
        }
    }

    public void Slide(bool IsOn)
    {
        if (CookieState(7))
        {
            return;
        }
        if (IsOn)
        {
            Animation(4);
            capCol.enabled = true;
            boxCol.enabled = false;
        }
        else
        {
            Animation(1);
            capCol.enabled = false;
            boxCol.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("Jelly"))
        {
            collision.transform.GetComponent<Item>().ItemState(true);
        }
        else if (collision.gameObject.tag == ("Obstacle"))
        {
            Debug.Log("플레이어 피격 상태");
            
            if(!isGiant && !isRush)
            {
                Hit();
                gameUIManager.hp.value -= 5f;
                Invoke("PostHit", 0.5f);

            }
            else
            {
                collision.transform.GetComponent<Obstacle>().Crash();
            }
        }

    }
    public void Hit()
    {
        Debug.Log("Hit");
        camera.ViTime(0.5f);
        animator.SetBool("IsHit", true);
    }
    public void PostHit()
    {
        Animation(1);
        isHit = false;
        animator.SetBool("IsHit", false);
    }

    public void Die()
    {
        isDie = true;
        pet.PetDie();
        Time.timeScale = 0;
        Animation(7);
        GameOverPanel();        
        animator.SetBool("IsDie", true);

    }
    public void GameOverPanel()
    {
        gameUIManager.GameOver();
    }
    public void Giant(bool IsTrue)
    {
        StartCoroutine(CoGiant(IsTrue));
    }
    public IEnumerator CoGiant(bool IsTrue)
    {
        float cookieScale;

        if(IsTrue)
        {
            cookieScale = 0.5f;
            while (transform.position.x < cookieScale)
            {
                yield return null;
                isGiant = true;
                transform.localScale = transform.localScale * (1f + cookieTime * 1f);
                cookieTime += Time.deltaTime;

                if (transform.localScale.x >= cookieScale)
                {
                    cookieTime = 0f;
                    break;
                }                
            }
            yield return new WaitForSeconds(4.0f);
            Giant(false);
        }
        else
        {
            isGiant=false;
            transform.localScale = originScale;
        }
    }

    public void Magnet(float max = 2.0f)
    {
        if(CoCookieMagnet == null)
        {
            CoCookieMagnet = StartCoroutine(CoMagnet(max));
        }
    }
    
    public IEnumerator CoMagnet(float max = 2.0f)
    {
        float magnetTime = 0;
        float range = 3.0f;
        if(max != 2.0f)
        {
            range = 1f;
        }
        while(true)
        {
            yield return null;
            magnetTime += Time.deltaTime;
            if(!pet.isSkill)
            {
                Collider2D[] jelly = Physics2D.OverlapCircleAll(transform.position + new Vector3(0,1,0) * 1f ,range);
                for (int i = 0; i < jelly.Length; i++)
                {
                    if (jelly[i].tag == "Jelly")
                    {
                        jelly[i].GetComponent<Item>().Magnet();
                    }
                }
            }
            if(magnetTime >= max)
            {
                break;
            }
            CoCookieMagnet = null;
        }

    }Coroutine CoCookieMagnet;

    public void Rush()
    {
        if(coRush != null)
        {
            StopCoroutine("CoRush");            
        }
        coRush = StartCoroutine("CoRush");
    }
    public IEnumerator CoRush()
    {
        isRush = true;
        MapScroll.mapSpeed *= 1.5f;
        Animation(8);
        yield return new WaitForSeconds(1.5f);
        isRush = false;
        MapScroll.mapSpeed *= 1f;
        Animation(1);
    }Coroutine coRush;

    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            if(CookieState(2)||CookieState(3))
            {
                Animation(1);
            }            
            isGround = true;
            jumpCount = 2;
        }        
    }
   


}
