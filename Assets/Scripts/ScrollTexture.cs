using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    public Vector2 speed;
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        ScrollTextureFunction();
    }
    void ScrollTextureFunction()
    {
        rend.material.mainTextureOffset += speed * Time.deltaTime;
    }       
}
