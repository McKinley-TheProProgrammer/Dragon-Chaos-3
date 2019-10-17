using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool isInRange;
    public Transform posAtaque;
    public float raioDeAtaque;
    public BoxCollider2D colisor;
    public LayerMask enemies;
    
    Animator ataque;
    void Start()
    {
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
            ataque.SetTrigger("Attack");
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
