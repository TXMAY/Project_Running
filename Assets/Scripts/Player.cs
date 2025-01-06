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
        animator.SetBool("sliding", isSlide);
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
            isSlide = true;
        }
        else
        {
            isSlide = false;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isSlide && collision.tag == "Bird") return;
        if (collision.tag == "Coin")
        {
            Debug.Log("¾ÆÀÌÅÛ È¹µæ");
            GameManager.Instance.preScore += 50.0f;
            Destroy(collision.gameObject);
            return;
        }
        animator.SetTrigger("hitting");
        GameManager.Instance.isGameOver = true;
    }

    void HitObstacle()
    {
        GameManager.Instance.GameOver();
    }
}
