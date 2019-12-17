using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMOve : MonoBehaviour
{

    public int playerSpeed = 10;
    private bool facingRight = true;
    public int jump = 100;
    private float Movex;
    public bool isGrounded;


    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRaycast();
    }
    void PlayerMove()
    {
        //controls
        Movex = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }
        //Animation
        //Player Direction
        if(Movex < 0.0f && facingRight == true){
            FlipPlayer();
        }
        else if(Movex > 0.0f && facingRight == false){
            FlipPlayer();
        }
        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Movex * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    void Jump()
    {
        //Jumping code
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump);
        isGrounded = false;
    }
    void FlipPlayer()
    {
        facingRight = ! facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("Player has collided with " + col.collider.name);
        if (col.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
        if (col.gameObject.tag == "Box")
        {
            isGrounded = true;
        }
        //if (col.gameObject.tag == "Enemy")
        //{
        //    isGrounded = true;
        //}
    }
    void PlayerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit.distance < 0.8f && hit.collider.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 100);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hit.collider.gameObject.GetComponent<EnemyMove>().enabled = false;
            //Destroy(hit.collider.gameObject);
        }
        if (hit.distance < 0.8f && hit.collider.tag != "Enemy")
        {
            isGrounded = true;
        }
        //Debug.Log("Touched Enemy");
    }
}
