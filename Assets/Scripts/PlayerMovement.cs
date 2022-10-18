using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private float horizontal;
    private Rigidbody2D rbody;
    public PlayableDirector director;
    public Animator animator;
    public bool isGrounded;

    // Start is called before the first frame update
    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 characterScale = transform.localScale;
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            characterScale.x = -1;
        }

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;

        if(horizontal == 0)
        {
            animator.SetBool("Correr", false);
        }
        else
        {
            animator.SetBool("Correr", true);

        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
            animator.SetBool("Salto", true);
            
        }

        
        
    

        rbody.velocity = new Vector2(horizontal * speed, rbody.velocity.y);
    

        //playerTransform.position += new Vector3 (horizontal * speed * Time.deltaTime, 0, 0);
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Cinematica")
        {
            director.Play();
        }
    }
}
