using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float angle = 100f;

    public void Crash()
    {
        StartCoroutine("CoCrash");
    }

    public IEnumerator CoCrash() // 방향, 날라가는 속도, 
    {
        float time = 0;
        while (true)
        {    
            yield return new WaitForSeconds(0.02f);            
            transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + angle * time);
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(1,1,0), Time.deltaTime * 10f);
            time += Time.deltaTime;
            if (time > 3f)
            {
                break;
            }
        }   
    }
    /*====================================
     * 22.06.29
     * 빠르게 달리는 상태, 커지는 상태 일때 Obstacle 날라가기     
     =====================================*/

}
