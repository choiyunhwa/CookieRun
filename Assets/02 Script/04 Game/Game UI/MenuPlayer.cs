using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayer : MonoBehaviour
{
    public GameObject stopPoint;

    public void Update()
    {
        
        transform.position = Vector2.Lerp(transform.position, stopPoint.transform.position, 0.008f);
    }
}
