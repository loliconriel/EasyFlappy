using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Move : MonoBehaviour
{
    
    private float speed = 0.15f;

    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
