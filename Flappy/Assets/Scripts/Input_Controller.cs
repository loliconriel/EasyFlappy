using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class Input_Controller : MonoBehaviour
{
    public PlayerInput playerInput;

    public event EventHandler Jump;
    public event EventHandler Flip;
    public event EventHandler Reload;

    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        closemap();
        //¤Á´«map
        if(SystemInfo.deviceType == DeviceType.Handheld)
        {
            playerInput.SwitchCurrentActionMap("Mobile");
        }
        else
        {
            playerInput.SwitchCurrentActionMap("Keyboard");
        }
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if(ctx.phase == InputActionPhase.Performed)
        {
            Jump?.Invoke(this, EventArgs.Empty);
        }
    }
    public void OnFlip(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            Flip?.Invoke(this, EventArgs.Empty);
        }
    }
    public void OnReload(InputAction.CallbackContext ctx)
    {
        if(ctx.phase == InputActionPhase.Performed)
        {
            Reload?.Invoke(this, EventArgs.Empty);
        }
    }
    public void OnMove(InputAction.CallbackContext ctx)
    {
        direction = ctx.ReadValue<Vector2>();
    }

    void closemap()
    {   
        //Ãö±¼©Ò¦³map
        foreach(var map in playerInput.actions.actionMaps)
        {
            map.Disable();
        }
    }
}
