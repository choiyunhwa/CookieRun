using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public GameObject effect;

    public Slider hp;
    public float minusHp = 3f;

    public GameObject gameOverPanel;
    public GameObject finishPanel;

    PlayerManager playerMove;

    private void Awake()
    {        
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        gameOverPanel.SetActive(false);
        finishPanel.SetActive(false);        
    }
    private void Update()
    {
        Hpbar();
    }
    public void Hpbar()
    {
        if (hp.value > 0.015)
        {
            hp.value -= minusHp * Time.deltaTime;
        }
        else if(hp.value <= 0.015)
        {
            hp.value = 0;
            playerMove.Die();
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void Finish()
    {
        finishPanel.SetActive(true);
    }
}
