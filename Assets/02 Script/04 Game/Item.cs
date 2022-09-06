using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ItemType
{
    Bagic,
    Yellow,
    Pink,
    Blue,
    Big,
    Health,
    PlayerBig,
    FastRun,
}//젤리 종류

public class Item : MonoBehaviour
{

    public int jellyNumber;
    private int score;
    private int coin;

    public float timer;
    
    private DataManager dataManager; 
    private PlayerManager playerManager;
    private PetManager petManager;
    private GameUIManager gameUIManager;
    
    private void Awake()
    {
        dataManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DataManager>();
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        petManager = GameObject.FindGameObjectWithTag("Pet").GetComponent<PetManager>();
        gameUIManager = GameObject.FindGameObjectWithTag("GameUIManager").GetComponent<GameUIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            switch (jellyNumber)
            {
                case 1: //Bigic
                    DataManager.Instance.score += 9444;
                    break;
                case 2: //Yellow
                    DataManager.Instance.score += 20555;
                    break;
                case 3: //Pink
                    DataManager.Instance.score += 29888;
                    break;
                case 4: //Blue
                    DataManager.Instance.score += 35444;
                    break;
                case 5: //pet jell
                    DataManager.Instance.score += 66666;
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }

    }
    
    public void ItemState(bool isOn)
    {
        switch (jellyNumber)
        {            
            case 7: //힐
                gameUIManager.hp.value += 20;
                break;
            case 8: //커지는 아이템
                playerManager.Giant(true);
                break;
            case 9: //빨라지는 아이템
                playerManager.Rush();
                break;
            case 10: //자석
                playerManager.Magnet();
                break;
        }
    }

    public void Magnet(bool isDelay = false)
    {
        if(coMagnet == null)
        {
            coMagnet = StartCoroutine(CoMagnet(isDelay));
        }        
    }

    public IEnumerator CoMagnet(bool isDelay)
    {
        if(isDelay)
        {
            yield return new WaitForSeconds(0.4f);
        }
        Transform petPos = playerManager.transform;
        if(petManager.isSkill)
        {
            petPos = petManager.transform;
        }
        float magnetSpeed = 8f;
        while (true)
        {
            yield return null;
            transform.position = Vector2.MoveTowards(transform.position, petPos.position, Time.deltaTime * magnetSpeed); // 펫 한테 이동
            if (Vector2.Distance(transform.position, petPos.position) < 0.3f)
            {
                ItemState(true);
            }
            magnetSpeed = 100f;
        }
    }Coroutine coMagnet = null;
}
