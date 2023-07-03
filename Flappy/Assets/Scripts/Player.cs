using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Transform PlayerTransform;
    private SpriteRenderer PlayerRenderer;
    private Animator Animator;

    private float Horizontal = 0f,Vertical = 0f,Speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        PlayerTransform = GetComponent<Transform>();
        PlayerRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Animator.SetBool("Dead", !Animator.GetBool("Dead"));
        }
        //Horizontal¸òVerticalªº½d³ò·|¦b -1~1
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        PlayerTransform.Translate(new Vector3(Horizontal,Vertical,0)*Speed*Time.deltaTime);
        if (Horizontal != 0)
        {
            PlayerRenderer.flipX = Horizontal < 0 ? true : false;
        }
        
        
    }
}
