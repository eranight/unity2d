using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public float epsilon;
    public float acceleration;
    public float maxVelocity;
    public float rotAngle;
    private float velocity;
    private Rigidbody2D rb2d;
    private Vector2 orientation;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        orientation = Vector2.up;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        manageVelocity();
        manageAngle();
    }

    private void manageVelocity()
    {
        if (rb2d.velocity.magnitude > maxVelocity)
        {
            rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxVelocity);
        }
        if (rb2d.velocity.magnitude < epsilon)
        {
            rb2d.velocity = Vector2.zero;
        }

        if (Input.GetKey(KeyCode.UpArrow) && rb2d.velocity.magnitude < maxVelocity)
        {
            rb2d.AddForce(orientation * acceleration);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && rb2d.velocity.magnitude > 0.0)
        {
            float nextVelocity = rb2d.velocity.magnitude - acceleration * Time.fixedDeltaTime;
            if (nextVelocity > 0.0f)
            {
                rb2d.AddForce(-orientation * acceleration);
            } 
        }
    }

    private void manageAngle()
    {
        /*if (rb2d.velocity.magnitude > 0.0f)
        {*/
            float deltaTime = Time.fixedDeltaTime;
            bool isChanged = false;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                orientation = orientation.Rotate(-rotAngle * deltaTime);
                isChanged = true;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                orientation = orientation.Rotate(rotAngle * deltaTime);
                isChanged = true;
            }
            if (isChanged)
            {
                rb2d.velocity = orientation * rb2d.velocity.magnitude;
                transform.rotation = Quaternion.LookRotation(Vector3.forward, orientation);
            }
        //}
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