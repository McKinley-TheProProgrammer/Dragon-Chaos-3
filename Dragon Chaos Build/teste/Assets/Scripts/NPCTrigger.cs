using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCTrigger : MonoBehaviour
{
    public GameObject instrucao;
    public GameObject textoNome;
    public GameObject textoDialogo;
    public GameObject butao;
    public Dialogue dialogo;
    public GameObject player;
    public bool podeFalar;
    public bool saiuDoCampo = false;
    public bool cineActive;

    public int npcIdentifier;
    void OnTriggerExit2D(Collider2D trigo)
    {
        instrucao.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        instrucao.SetActive(true);
    }
    void OnTriggerStay2D(Collider2D trigo)
    {
        if (trigo.gameObject.CompareTag("Player") && saiuDoCampo == false && player.GetComponent<PlayerMovement>().isOnLand == true)
        {
           Debug.Log("Entrou");
           
           if (Input.GetKeyDown(KeyCode.F))
           {
                Debug.Log("Ativou");
                
                FindObjectOfType<DialogueManager>().ComecarDialogo(dialogo);
                textoDialogo.SetActive(true);
                textoNome.SetActive(true);
                butao.SetActive(true);
                player.GetComponent<PlayerMovement>().inDialog = true;
                if(cineActive == false)
                {
                    Debug.Log("LOOG");
                    cineActive = true;
                    //FindObjectOfType<DialogueManager>().cutscene.CineEnabled();
                    //GameManager.Instance.CineEnabled();

                }
            }
        }
        
    }

}
