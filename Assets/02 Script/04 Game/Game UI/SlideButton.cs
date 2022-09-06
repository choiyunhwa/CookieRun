using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideButton : MonoBehaviour
{
    PlayerManager playerMove;
    private void Awake()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }
    public void PointerSlideDown()
    {
        playerMove.Slide(true);
        Debug.Log("Slide��ư ������ ��!");
    }
    public void PointerSlideUp()
    {
        playerMove.Slide(false);
        Debug.Log("Slide��ư ��!");
    }
}
