using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    float _horizontalMove = 0f;
    bool _jump = false;
    bool _crouch = false;
    
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");
    private static readonly int IsCrouching = Animator.StringToHash("IsCrouching");

    // Update is called once per frame
    void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat(Speed, Mathf.Abs(_horizontalMove));
      
        
        if (Input.GetButtonDown("Jump"))
        {
            _jump = true;
            animator.SetBool(IsJumping, true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            _crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            _crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool(IsJumping, false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool(IsCrouching, isCrouching);
    }
    
    void FixedUpdate()
    {
        // Move our character
        controller.Move(_horizontalMove * Time.fixedDeltaTime, _crouch, _jump);
        _jump = false;
    }
}