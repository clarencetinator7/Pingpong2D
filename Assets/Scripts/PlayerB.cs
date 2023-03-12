using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerB : MonoBehaviour
{
    public float paddleSpeed = 5f;
    public float bounds = 3.16f;

    // Update is called once per frame
    void Update()
    {
        // Move paddle up or down on key press
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * paddleSpeed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * paddleSpeed * Time.deltaTime);
        }

        // Keep paddle within screen bounds using clamp
        float y = Mathf.Clamp(transform.position.y, -(bounds), bounds);
        transform.position = new Vector2(transform.position.x, y);

    }
}
