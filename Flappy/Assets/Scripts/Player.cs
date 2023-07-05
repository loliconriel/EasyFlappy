using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{

    private Transform PlayerTransform;
    private SpriteRenderer PlayerRenderer;
    private Animator Animator;
    private Rigidbody2D Rigidbody;
    private Vector2 direction;
    private Input_Controller input_Controller;

    //Player_Controller Player_;

    private float Horizontal = 0f,Vertical = 0f,Speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        PlayerTransform = GetComponent<Transform>();
        PlayerRenderer = GetComponent<SpriteRenderer>();
        Rigidbody = GetComponent<Rigidbody2D>();

        //方法三
        input_Controller = GetComponent<Input_Controller>();

        input_Controller.Jump += Jump;
        input_Controller.Flip += Flip;
        input_Controller.Reload += Reload;
        //

        /*使用Input map C#黨才會用到 方法二
        Player_ = new Player_Controller();
        Player_.Keyboard.Enable();
        Player_.Keyboard.Jump.performed += Jump;
        Player_.Keyboard.Move.performed += Move;
        Player_.Keyboard.Move.canceled +=Move;
        Player_.Keyboard.Flip.performed += Flip;
        Player_.Keyboard.Reload.performed +=Reload;
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Animator.SetBool("Dead", !Animator.GetBool("Dead"));
        }
   
        //Horizontal跟Vertical的範圍會在 -1~1
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        direction = new Vector2(Horizontal,Vertical);
        */
        PlayerTransform.Translate(direction * Speed*Time.deltaTime);
        if (direction.x != 0)
        {
            PlayerRenderer.flipX = direction.x < 0 ? true : false;
        }
    }
    private void FixedUpdate()
    {
        direction = input_Controller.direction;
    }
    /*方法一
    public void Reload(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            SceneManager.LoadScene("Main");
        }
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        direction = ctx.ReadValue<Vector2>();
    }
    
    public void Flip(InputAction.CallbackContext ctx)
    {
        if(ctx.phase == InputActionPhase.Performed)
        {
            Animator.SetBool("Dead", !Animator.GetBool("Dead"));
        }
    }
    public void Jump(InputAction.CallbackContext ctx)
    {

    }
    */

    //方法三
    private void Jump(object sender, EventArgs e)
    {
        Rigidbody.velocity = Vector2.zero;
        Rigidbody.AddForce(new Vector2(0,300f));
    }
    private void Reload(object sender, EventArgs e)
    {
        SceneManager.LoadScene("Main");
    }
    private void Flip(object sender, EventArgs e)
    {
        Animator.SetBool("Dead", !Animator.GetBool("Dead"));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            Debug.Log("+1");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Dead");
        }
    }
}
