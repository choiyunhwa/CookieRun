using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    private MeshRenderer render;

    public float offset;
    public float speed = 0.04f;
    private void Awake()
    {
        render = GetComponent<MeshRenderer>();
    }   

    void Update()
    {
        offset += Time.deltaTime * speed;
        render.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
