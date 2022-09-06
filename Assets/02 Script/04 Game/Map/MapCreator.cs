using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public MapScroll current;
    public GameObject[] maps;
    private int mapNum = 0;
    public void NewMap()
    {
        if(mapNum < maps.Length - 1)
        {
            var prefab = maps[mapNum % maps.Length];

            var mapScroll = prefab.GetComponent<MapScroll>();
            var pos = current.dummy.transform.position;
            Vector2 offset = mapScroll.dummy.localPosition;
            var newGo = Instantiate(maps[++mapNum % maps.Length], pos, Quaternion.identity);
            current = newGo.GetComponent<MapScroll>();
        }        
    }
}
