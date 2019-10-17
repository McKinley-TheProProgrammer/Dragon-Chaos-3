using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public float velocidade = 6f;
    public float pararDist;
    public float recuarDist;
    public GameObject range;
    public Transform seguirAlvo;
    //Checa se tem um buraco
    public Transform edge;
    public float raioDoCanto;
    public LayerMask whereIsEdge;
    public bool isOnGround;
    bool isAttacking;
    public EnemyAttack atackscript;
    int enemyRange = 50;
    public Transform player;

   // Animator anim;
    SpriteRenderer flipa;
    // Start is called before the first frame update
    void Start()
    {
        seguirAlvo = GameObject.FindWithTag("Player").transform;
        //anim = GetComponent<Animator>();
        flipa = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics2D.OverlapCircle(edge.position, raioDoCanto, whereIsEdge);
        if (seguirAlvo != null)
        {
            if (transform.position.x > player.position.x)
            {
                flipa.flipX = true;
            }
            else
            {
                flipa.flipX = false;
            }
            if (isAttacking)
            {
                return;
            }
            //Debug.Log("The Fim");
            if(CheckRange() && isOnGround)
            {
                //anim.SetBool("EnemySpotted",true);
                
                transform.position = Vector2.MoveTowards(transform.position, seguirAlvo.position, velocidade * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, seguirAlvo.position) < pararDist && Vector2.Distance(transform.position, seguirAlvo.position) > recuarDist && isOnGround)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, seguirAlvo.position) < recuarDist && isOnGround)
            {
                transform.position = Vector2.MoveTowards(transform.position, seguirAlvo.position, -velocidade * Time.deltaTime);
            }
        }
    }

    bool CheckRange()
    {
        return Vector2.Distance(transform.position, player.position) < enemyRange;
    }
    public void StartAttack()
    {
        atackscript.TurnColliderOn();
        isAttacking = true;
    }
    public void StopAttack()
    {
        atackscript.TurnColliderOff();
        isAttacking = false;
    }
}
