using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public GameObject petSkill;
    public bool isSkill;

    private Transform player;
    private Animator petAnimator;

    public void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        petAnimator = GetComponent<Animator>();
        StartCoroutine("CoPetMove");
    }
    public void PetDie()
    {
        StopCoroutine("CoPetMove");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Jelly")
        {
            collision.transform.GetComponent<Item>().ItemState(true);
        }
    }
    public IEnumerator CoPetMove()
    {
        float timer = 0;

        while (true)
        {
            yield return null;
            transform.position = Vector2.Lerp(transform.position, (Vector2)player.position + new Vector2(-1.6f, 1.6f), 0.05f);
            petAnimator.SetBool("Effect", false);
            timer += Time.deltaTime;

            if (timer >= 7f)
            {
                timer = 0;
                while (true)
                {
                    yield return null;
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(-2, 0), 0.1f);

                    petAnimator.SetBool("Effect", true);

                    if (Vector2.Distance(transform.position, new Vector2(-2, 0)) < 0.1f)
                    {
                        isSkill = true;
                    }
                    Collider2D[] jelly = Physics2D.OverlapCircleAll(transform.position, 2.0f);
                    for (int i = 0; i < jelly.Length; i++)
                    {
                        if (jelly[i].tag == "Jelly")
                        {
                            jelly[i].GetComponent<Item>().Magnet();
                        }
                    }
                    timer += Time.deltaTime;
                    if (timer >= 2f) break;
                }
                isSkill = false;
                for (int i = 0; i <= 1; i++)
                {
                    float jellyY = 0;
                    jellyY += Random.Range(-2.5f, 2.5f);
                    GameObject jellys = Instantiate(petSkill, transform.position, Quaternion.identity);
                    while (true)
                    {
                        yield return null;
                        jellys.transform.position = Vector2.MoveTowards(jellys.transform.position, new Vector2(transform.position.x + 2f, jellyY), 0.5f);
                        if (Vector2.Distance(jellys.transform.position, new Vector2(transform.position.x + 2f, jellyY)) < 0.1f)
                        {
                            break;
                        }
                    }
                    for (int j = 0; j < jellys.transform.childCount; j++)
                    {
                        jellys.GetComponent<Item>().Magnet();
                        //jellys.transform.GetChild(j).GetComponent<Item>().Magnet();
                    }
                    yield return new WaitForSeconds(0.2f);
                }
                timer = 0;
            }
        }

    }

}
