using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField]
    float speed = 10f;
    [SerializeField]
    float randomFactor = 0.2f;

    Vector2 direction = Vector2.one.normalized;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float y = Random.Range(-1f, 1f);
        direction = new Vector2(1, y).normalized;
        rb.velocity = direction * speed;
    }
    
    // Called when the ball collides with something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get the collision normal (the direction in which the ball collided with the object)
        Vector2 collisionNormal = collision.contacts[0].normal;

        // Reflect the ball's direction using the collision normal
        direction = Vector2.Reflect(direction, collisionNormal);

        // Add some randomness to the ball's direction to make the game more interesting
        direction += new Vector2(
            Random.Range(-randomFactor, randomFactor),
            Random.Range(-randomFactor, randomFactor)
        );

        // Normalize the ball's direction to maintain a constant speed
        direction = direction.normalized;

        // Set the ball's new velocity
        rb.velocity = direction * speed;
    }



}
