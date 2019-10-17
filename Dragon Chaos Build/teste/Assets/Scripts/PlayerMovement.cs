using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    float velocity = 136f;
    float jumpForce = 400f;
    Rigidbody2D body;
    Animator anim;
    SpriteRenderer flipa;

    bool isAttacking;
    bool moving = true;
    public bool inDialog = false;
    bool activatePhysics;
    public int activatePhys = 0;
    public bool isInRange;


    public Transform peDoPlayer;
    private float raio = 0.3f;
    public LayerMask groundChecker;
    public bool isOnLand = true;
    public AttackMechanic attackScript;

    #region Singleton
    static PlayerMovement instance;
    public static PlayerMovement Instance { get { return instance; } }
    #endregion

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        isOnLand = true;
        anim = GetComponent<Animator>();
        flipa = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground_Grass")
            isOnLand = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground_Grass")
            isOnLand = false;
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "NPC")
        {
            body.isKinematic = true;
        }
        if(activatePhys >= 9)
        {
            body.isKinematic = false;
        }
    }*/


    void Update()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));

        if (inDialog || isAttacking)
        {
            anim.SetBool("IsWalking", false);
            body.velocity = Vector2.zero;
            return;
        }


        float x = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(x * velocity * Time.deltaTime, body.velocity.y);
        if (Input.GetKeyDown(KeyCode.W) && isOnLand == true)
        {
            anim.SetTrigger("Jumper");
            body.AddForce(new Vector2(0, jumpForce));
        }
        if (x > 0 && !moving)
        {
            moving = true;
            flipa.flipX = false;
        }
        else
        {
            if (x < 0 && !moving)
            {
                moving = true;
                flipa.flipX = true;
            }
            else
            {
                moving = false;
            }
        }




        if (x == 0)
        {
            anim.SetBool("IsWalking", false);
        }
        else
        {
            anim.SetBool("IsWalking", true);
        }

        isOnLand = Physics2D.OverlapCircle(peDoPlayer.position, raio, groundChecker);
    }

    public void StartAttack()
    {
        attackScript.TurnColliderOn();
        isAttacking = true;
    }
    public void StopAttack()
    {
        attackScript.TurnColliderOff();
        isAttacking = false;
    }

}
