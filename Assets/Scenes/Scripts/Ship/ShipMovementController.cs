using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementController : MonoBehaviour {

    public float epsilon;
    public float acceleration;
    public float maxVelocity;
    public float rotAngle;
    private Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        manageVelocity();
        manageAngle();
    }

    private void manageVelocity()
    {
        if (Input.GetKey(KeyCode.UpArrow) && rb2d.velocity.magnitude < maxVelocity)
        {
            rb2d.AddForce(transform.up * acceleration);
            if (rb2d.velocity.magnitude > maxVelocity)
            {
                rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxVelocity);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) && rb2d.velocity.magnitude > 0.0)
        {
            float nextVelocity = rb2d.velocity.magnitude - acceleration * Time.fixedDeltaTime;
            if (nextVelocity > 0.0f)
            {
                rb2d.AddForce(-transform.up * acceleration);
            }
            else if (rb2d.velocity.magnitude < epsilon)
            {
                rb2d.velocity = Vector2.zero;
            }
        }
    }

    private void manageAngle()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward, -rotAngle * Time.fixedDeltaTime);
            rb2d.velocity = transform.up * rb2d.velocity.magnitude;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward, rotAngle * Time.fixedDeltaTime);
            rb2d.velocity = transform.up * rb2d.velocity.magnitude;
        }
    }
}

public static class Vector2Extension
{

    public static Vector2 Rotate(this Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }
}