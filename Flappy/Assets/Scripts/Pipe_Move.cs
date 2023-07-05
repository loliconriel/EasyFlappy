using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Move : MonoBehaviour
{
    float Speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.position-=new Vector3(Speed*Time.deltaTime,0,0);
    }
}
