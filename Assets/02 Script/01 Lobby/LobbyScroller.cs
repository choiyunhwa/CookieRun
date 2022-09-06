using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyScroller : MonoBehaviour
{
    [SerializeField]
    private RawImage img;

    private float xPos = 0.01f;
    private float yPos = 0.01f;

    private void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(xPos, yPos) * Time.deltaTime,img.uvRect.size);
    }

}
