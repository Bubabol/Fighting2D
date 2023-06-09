using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    public int playerIndex;
    private float horizontalMove = 0f;
    private bool crouch = false;
    private bool jump = false;
    private bool punch = false;

    public PlayerControls controls;
    
    private void Awake()
    {
        controls = new PlayerControls();

        controls.Movement.Move.performed += ctx => horizontalMove = ctx.ReadValue<Vector2>().x;

        controls.Movement.Move.canceled += ctx => horizontalMove = 0f;

        controls.Movement.Jump.started += _ => jump = true;
        controls.Movement.Jump.canceled += _ => jump = false;

        controls.Movement.Crouch.started += _ => crouch = true;
        controls.Movement.Crouch.canceled += _ => crouch = false;

        controls.Movement.Punch.started += _ => punch = true;
        
            
        
    }

    private void OnEnable()
    {
        controls.Movement.Enable();
    }

    private void OnDisable()
    {
        controls.Movement.Disable();
    }

    private void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        animator.SetBool("IsJumping", jump);
        animator.SetBool("IsCrouching", crouch);
        animator.SetBool("IsPunching", punch);
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    public void OnCrouching()
    {
        animator.SetBool("IsCrouching", true);
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * runSpeed * Time.fixedDeltaTime, crouch, jump);
        jump = false;

        controller.Punch(punch);
        punch = false;
    }
    

    
    
}
