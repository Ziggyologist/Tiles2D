using System.Net;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    PlayerMovement player;
    Rigidbody2D rb;
    //CapsuleCollider2D bodyCollider2d;
    float xSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<PlayerMovement>();
        //bodyCollider2d = GetComponent<CapsuleCollider2D>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(xSpeed, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemiy")
        {
            Destroy(collision.gameObject);
        }
        //Destroy(gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        //Destroy(gameObject);

    }
}
