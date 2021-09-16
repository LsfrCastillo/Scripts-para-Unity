using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool IsGrounded;
    //Acordate que si pones static esta variable la podras usar en otras scripts
    private void OnTriggerEnter2D(Collider2D collision) //Cuando el objeto esta colisionando
    {
        IsGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsGrounded = false;
    }
}

