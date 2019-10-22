using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool isInRange;
    public bool enabledAttack;
    public float timer;
    public Transform posAtaque;
    public float raioDeAtaque;
    public BoxCollider2D colisor;
    public LayerMask enemies;
    
    Animator ataque;
    void Start()
    {
        enabledAttack = true;
        colisor.enabled = false;
        ataque = GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D ataque)
    {
        Debug.Log(isInRange);
        if (ataque.CompareTag("Player") && isInRange && ataque.GetComponent<PlayerDamage>().imortal == false)
        {
            Debug.Log("Tei Matei");
            Destroy(ataque.gameObject);
        }
    }

    void Update()
    {
        
        isInRange = Physics2D.OverlapCircle(posAtaque.position, raioDeAtaque,enemies);
        if (isInRange)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                enabledAttack = true;
                timer = 1.5f;

            }
            /*if (!enabledAttack)
            {
                timer -= Time.deltaTime;
            }*/
            if (enabledAttack)
            {
                ataque.SetTrigger("Attack");
                enabledAttack = false;
            }
            
        }
    }
    public void TurnColliderOn()
    {
        colisor.enabled = true;
    }
    public void TurnColliderOff()
    {
        colisor.enabled = false;
    }
}
