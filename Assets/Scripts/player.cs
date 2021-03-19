using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer renderer;
    private float speed = 2;
    private float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if(GameManager.instance.stopTrigger == false)
        {
            animator.SetTrigger("dead");
        }
        else
        {
            PlayerMove();
        }
        ScreenChk();
    }

    private void PlayerMove()
    {
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        if(horizontal > 0)  // right
        {
            renderer.flipX = true;
        }
        else                // left
        {
            renderer.flipX = false;
        }
        rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);
    }

    private void ScreenChk()
    {
        Vector3 worlpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worlpos.x < 0.07f) worlpos.x = 0.07f;
        if (worlpos.x > 0.9f) worlpos.x = 0.9f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worlpos);
    }

    public void ButtonClick(string d)
    {
        
    }
}
