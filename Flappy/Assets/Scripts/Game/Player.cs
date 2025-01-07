using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public GameObject Lose_Panel;
    public GameObject Point_Text;
    public GameObject[] Effect = new GameObject[2];
    public GameObject GameManage;
    public GameObject PipeSpawner;

    private Transform PlayerTransform;
    private SpriteRenderer PlayerRenderer;
    private Animator Animator;
    private Rigidbody2D Rigidbody;
    private Vector2 direction;
    private Input_Controller input_Controller;

    //Player_Controller Player_;

    public int point = 0;
    private float Horizontal = 0f,Vertical = 0f,Speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        GameManage = GameObject.Find("GameManager");

        Time.timeScale = 1f;
        Animator = GetComponent<Animator>();
        PlayerTransform = GetComponent<Transform>();
        PlayerRenderer = GetComponent<SpriteRenderer>();
        Rigidbody = GetComponent<Rigidbody2D>();
        point = 0;
        Rigidbody.gravityScale = 0;
        //��k�T
        input_Controller = GetComponent<Input_Controller>();

        input_Controller.Jump += Jump;
        input_Controller.Flip += Flip;
        input_Controller.Reload += Reload;
        //

        /*�ϥ�Input map C#�Ҥ~�|�Ψ� ��k�G
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
   
        //Horizontal��Vertical���d��|�b -1~1
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
    /*��k�@
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

    //��k�T
    private void Jump(object sender, EventArgs e)
    {
        if (Rigidbody.gravityScale ==0)
        {
            Rigidbody.gravityScale = 1;
            PipeSpawner.SetActive(true);
        }
        Rigidbody.linearVelocity = Vector2.zero;
        Rigidbody.AddForce(new Vector2(0,300f));
        var effect = Instantiate(Effect[1], transform.position, Quaternion.identity);
        effect.GetComponent<AudioSource>().time = 0.3f;
        effect.GetComponent<AudioSource>().Play();
        Destroy(effect, 5f);
    }
    private void Reload(object sender, EventArgs e)
    {
        SceneManager.LoadScene("Main");
    }
    private void Flip(object sender, EventArgs e)
    {
        Animator.SetBool("Dead", !Animator.GetBool("Dead"));
    }
    private void Lose()
    {
        Time.timeScale = 0f;
        Lose_Panel.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            point++;
            Point_Text.GetComponent<TextMeshProUGUI>().text = point.ToString();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            var effect = Instantiate(Effect[0], transform.position, Quaternion.identity);
            effect.GetComponent<AudioSource>().time = 0.12f;
            effect.GetComponent<AudioSource>().Play();
            Destroy(effect,5f);
            Lose();
            GameManage.GetComponent<GameManager>().Lose(point);
        }
    }

}
