using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D rb;
    BoxCollider2D cb;
    public Animator animator;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        cb = GetComponent<BoxCollider2D>();
    }

    void Update() {
        if(isFacingDown()) {
            rb.velocity = new Vector2(0f, -moveSpeed);
            animator.SetBool("isMovingUp", true);
        } else {
            rb.velocity = new Vector2(0f, moveSpeed);
            animator.SetBool("isMovingUp", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
    }

    private bool isFacingDown() {
        return transform.localScale.x > Mathf.Epsilon;
    }

}
