using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookieFace : MonoBehaviour
{
    public SpriteRenderer cookieFace;
    public float time = 0f;

    private void Start()
    {
        StartCoroutine(CoMarker());
    }
    public IEnumerator CoMarker()
    {
        while(true)
        {
            cookieFace.enabled = false;
            yield return new WaitForSeconds(3f);
            cookieFace.enabled = true;
            yield return new WaitForSeconds(0.5f);
            cookieFace.enabled = false;
            yield return new WaitForSeconds(0.2f);
            cookieFace.enabled = true;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
