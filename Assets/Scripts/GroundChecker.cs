using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public Animator animator;
    
    PlayerMovement _player;

    void Awake()
    {
        _player = GameObject.Find("rogue").GetComponent<PlayerMovement>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Ground")
       {
           _player.isGrounded = true;
           _player.animator.SetBool("Salto", false);
       }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        _player.isGrounded = false;
    }
}
