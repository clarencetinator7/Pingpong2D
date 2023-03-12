using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerA : MonoBehaviour
{

    public float paddleSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Move paddle up or down on key press
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * paddleSpeed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * paddleSpeed * Time.deltaTime);
        }

        // Keep paddle within screen bounds using clamp
        float y = Mathf.Clamp(transform.position.y, -3.73f, 3.73f);
        transform.position = new Vector2(transform.position.x, y);

    }
}