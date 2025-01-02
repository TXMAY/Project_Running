using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float jump;
    [SerializeField] float power = 5.0f;
    [SerializeField] bool isGround = true;
    [SerializeField] bool isSlide = false;

    Rigidbody2D rigidbody;
    Animator animator;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (rigidbody.velocity.y < 0)
        {
            animator.SetBool("jumping", false);
            animator.SetBool("falling", true);
        }
        isSlide = animator.GetBool("sliding");
    }

    public void OnJump()
    {
        if (isGround)
        {
            rigidbody.AddForce(Vector2.up * power, ForceMode2D.Impulse);
            animator.SetBool("jumping", true);
            isGround = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
        animator.SetBool("falling", false);
    }

    public void OnSlide(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetBool("sliding", true);
            Debug.Log("슬라이드 누름");
        }
        else
        {
            animator.SetBool("sliding", false);
            Debug.Log("슬라이드 뗌");
        }
    }
}
