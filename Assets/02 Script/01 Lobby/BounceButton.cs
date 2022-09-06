using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceButton : MonoBehaviour
{
    public float timer = 0f;
    public float size = 5;
    public float sizeUptimer = 0.2f;

    private void Update()
    {
        if(timer <= sizeUptimer)
        {
            transform.localScale = Vector2.one * (1 * size * timer);
        }
        else if(timer <= sizeUptimer*2)
        {
            transform.localScale = Vector2.one * (2 * size * sizeUptimer + 1 - timer * size);
        }
        else
        {
            transform.localScale = Vector2.one;
        }
        timer += Time.deltaTime;
    }
    public void resetAnim()
    {
        timer = 0f;
    }


}
