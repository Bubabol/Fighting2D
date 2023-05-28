using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2 : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;

    private float horizontalMove = 0f;
    private bool crouch = false;
    private bool jump = false;
    private bool punch = false;

    public PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Movement2.Move2.performed += ctx => horizontalMove = ctx.ReadValue<Vector2>().x;
        controls.Movement2.Move2.canceled += ctx => horizontalMove = 0f;

        controls.Movement2.Jump2.started += _ => jump = true;
        controls.Movement2.Jump2.canceled += _ => jump = false;

        controls.Movement2.Crouch2.started += _ => crouch = true;
        controls.Movement2.Crouch2.canceled += _ => crouch = false;

        controls.Movement2.Punch2.started += _ => punch = true;
    }

    private void OnEnable()
    {
        controls.Movement2.Enable();
    }

    private void OnDisable()
    {
        controls.Movement2.Disable();
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

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * runSpeed * Time.fixedDeltaTime, crouch, jump);
        jump = false;

        controller.Punch(punch);
        punch = false;
    }
}
