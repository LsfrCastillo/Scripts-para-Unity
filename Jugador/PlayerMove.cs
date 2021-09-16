using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2;
    public float JumpSpeed = 3;
    Rigidbody2D rb2D;

    public bool BetterJump = false;
    public float FallMultiplayer = 0.5f;
    public float LowJumpMultiplayer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d")||Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            //el rb2D.velocity.y es solo para "mantener" o no modificar el valor del eje
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }
        if (Input.GetKey("space") && CheckGround.IsGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, JumpSpeed);
        }
        if (BetterJump) //salto tipo mario, mantener para saltar mas.
        {
            if(rb2D.velocity.y <0){
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplayer) * Time.deltaTime;
            }
            if (rb2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (LowJumpMultiplayer) * Time.deltaTime;
            }
        }
    }
}
