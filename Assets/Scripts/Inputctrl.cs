using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputctrl : MonoBehaviour
{
    public float speed = 3;
    private Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponentInChildren<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x == 0 && y == 0)
        {
            return ;
        }

        rb.MovePosition(rb.position + new Vector2(x, y) * speed * Time.fixedDeltaTime);
    }
}
