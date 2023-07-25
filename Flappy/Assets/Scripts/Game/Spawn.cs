using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject pipe;

    float Reapeat_Time = 2f, low = -4f, high = 4f,Destroy_Time=5f;
    void Start()
    {
        InvokeRepeating(nameof(Spawn_), 1, Reapeat_Time);
    }
    void Spawn_()
    {
        var pip = Instantiate(pipe, transform.position, Quaternion.identity);
        pip.transform.position +=new Vector3(0,Random.Range(low,high),0);
        Destroy(pip,Destroy_Time);
    }
}
