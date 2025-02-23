using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(moveSpeed, 0f);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("exit collision");
        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    }


    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.linearVelocity.x)), 1f);

    }
}
