using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackMechanic : MonoBehaviour
{
    public Image barraDeAdrenalina;
    public Animator anim;
    float enemyDamage;
    public BoxCollider2D colisorDireita;
    public BoxCollider2D colisorEsquerda;
    public string enemyTag;
    public string strongerEnemyTag;
    int danoSET = 3;
    public ParticleSystem enemyTraces;
    // Start is called before the first frame update
    void Start()
    {
        colisorDireita.enabled = false;
        colisorEsquerda.enabled = false;
        barraDeAdrenalina.fillAmount = 0f;
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            anim.SetTrigger("Attack");
        
        
    }
   
    public void TurnColliderOn()
    {
        if (gameObject.GetComponentInParent<SpriteRenderer>().flipX == true)
            colisorDireita.enabled = true;
        if (gameObject.GetComponentInParent<SpriteRenderer>().flipX == false)
            colisorEsquerda.enabled = true;
    }
    public void TurnColliderOff()
    {
       
        colisorDireita.enabled = false;
        
        colisorEsquerda.enabled = false;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag(enemyTag))
        {
            barraDeAdrenalina.fillAmount += 0.08f;
            Instantiate(enemyTraces, transform.position, Quaternion.identity);

            //collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            //collision.gameObject.GetComponent<BoxCollider2D>().enabled = true;

            iTween.PunchScale(collision.gameObject,new Vector2(6,8),1);
            iTween.ColorTo(collision.gameObject,new Color(0,0,0,0),.5f);

            Destroy(collision.gameObject,.5f);
        }
        /*if (collision.gameObject.CompareTag(strongerEnemyTag))
        {
            danoSET--;
            barraDeAdrenalina.fillAmount += 0.05f;
            Instantiate(enemyTraces, transform.position, Quaternion.identity);
            if(danoSET <= 0)
                Destroy(collision.gameObject);
        }*/
    }

}
