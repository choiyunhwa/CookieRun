using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScroll : MonoBehaviour
{
    public static float spawnX = 20f;

    public static float mapSpeed = 10f;
    private MapCreator creator;

    private float endPosition = -100f;
    private bool signal = false;

    public Transform dummy;

    private Transform player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        creator = GameObject.FindGameObjectWithTag("MapCreator").GetComponent<MapCreator>();
        
    }
    private void Update()
    {
        transform.Translate(-mapSpeed * Time.deltaTime, 0, 0); //¸Ê ÀÌµ¿
        if(player.position.x > (dummy.position.x - spawnX) && !signal)
        {
            creator.NewMap();
            signal = true;
        }

        if(transform.position.x <= endPosition)
        {
            Destroy(gameObject);
        }
    }
}
