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

    public IEnumerator CoCrash() // ����, ���󰡴� �ӵ�, 
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
     * ������ �޸��� ����, Ŀ���� ���� �϶� Obstacle ���󰡱�     
     =====================================*/

}
