using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCamaraShake : MonoBehaviour
{
    public float amout = 0.1f;
    private float timer;

    Vector3 originPosition;

    public void ViTime(float time)
    {
        timer = time;
    }
    private void Start()
    {
        originPosition = new Vector3(0f, 0f, -10f);
    }
    private void Update()
    {        
        if(timer > 0)
        {
            transform.position = Random.insideUnitSphere * amout + originPosition;
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0.0f;
            transform.position = originPosition;
        }
    }

}
