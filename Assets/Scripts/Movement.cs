using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody2D myRigidBody;
    private CircleCollider2D myFeet;

    private LayerMask ground;

    private float speed = 5f;
    private float horizontalMovement = 0f;
    private float jumpForce = 7f;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<CircleCollider2D>();
        ground = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && myFeet.IsTouchingLayers(ground))
        {
            myRigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        myRigidBody.velocity = new Vector2(horizontalMovement * speed, myRigidBody.velocity.y);
    }
}
