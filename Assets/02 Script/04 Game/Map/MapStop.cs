using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapStop : MonoBehaviour
{
    public GameObject stopPoint;

    private Animator flagAni;
    private PlayerManager playerManager;

    private GameUIManager gameUIManager;

    public float panelTime = 0f;

    private void Awake()
    {
        flagAni = GameObject.FindGameObjectWithTag("Flag").GetComponent<Animator>();
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        gameUIManager = GameObject.FindGameObjectWithTag("GameUIManager").GetComponent<GameUIManager>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Player") == 0)
        {
            flagAni.SetTrigger("IsGoal");
            flagAni.SetTrigger("IsFly");
            MapScroll.mapSpeed = 0;

            GameSuccesePanel();
        }
    }
    public void GameSuccesePanel()
    {
       gameUIManager.Finish();     
    }
}
