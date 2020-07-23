using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public GameObject Player;
    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 movement;
    public float speedLimit = 12f;
    public Animator am;

    // Update is called once per frame
    void Update()
    {
        bool brakeON = true;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (moveSpeed >= speedLimit)
        {
            brakeON = false;
        }
        if ((movement.x != 0 | movement.y != 0) && brakeON == true )
        {
            moveSpeed = moveSpeed + 0.08f;
        }
        if ((movement.x == 0 && movement.y == 0) && moveSpeed > 0 )
        {
            moveSpeed = 0;
        }

        // if (Input.GetAxisRaw("Horizontal") == -1)
        // {
        //     Player.transform.localScale = new Vector3(-1, 0, 0);
        // }
        // else if (Input.GetAxisRaw("Horizontal") == 1)
        // {
        //     Player.transform.localScale = new Vector3(1, 0, 0);
        // }
        am.SetFloat("moveSpeed", moveSpeed);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            Player.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            Player.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
