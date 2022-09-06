using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour
{
    PlayerManager playerMove;

    private void Awake()
    {

        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickJump()
    {

        playerMove.Jump();
        Debug.Log("Jump≈¨∏Ø!");
    }
}
