using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameManager cutscene;
    public GameObject textname;
    public GameObject textdialog;
    public GameObject butao;
    public Text textoNome;
    public Text textoDialogo;
    public GameObject player;
    public NPCTrigger quemFala;

    public int npcPoint;
    private Queue<string> sentencas;
	// Use this for initialization
	void Start () {
        sentencas = new Queue<string>();
       
	}
	
	public void ComecarDialogo(Dialogue dialogo)
    {
        

        textoNome.text = dialogo.nome;

        sentencas.Clear();

        foreach(string frase in dialogo.sentencas)
        {
            sentencas.Enqueue(frase);
        }

        DisplayNextFrase();
    }
    public void DisplayNextFrase()
    {
        /* if(sentencas.Count == 3)
        {
            GameManager.Instance.CineEnabled();
        }
        if(sentencas.Count == 0)
        {
             if (npcPoint != 0)
                 EndDialogo(npcPoint);
             else if(npcPoint == 0)
                    EndDialogo(npcPoint++);
                 
            //EndDialogo(npcPoint++);
            return; 
        }*/
        //player.GetComponent<PlayerMovement>().activatePhys += 1;
        switch (sentencas.Count)
        {
            case 3:
                GameManager.Instance.CineEnabled();
                break;
            
        }

        if (sentencas.Count == 0)
        {
            if (npcPoint != 0)
                EndDialogo(npcPoint);
            else if (npcPoint == 0)
                EndDialogo(npcPoint++);

            //EndDialogo(npcPoint++);
            return;
        }
        string sentenda = sentencas.Dequeue();
        StopAllCoroutines();
        StartCoroutine(SentencadeMorte(sentenda));
    }

    IEnumerator SentencadeMorte(string sentenca)
    {
        textoDialogo.text = "";
        foreach (char letra in sentenca.ToCharArray())
        {
            textoDialogo.text += letra;
            yield return null;
        }
    }
    public void EndDialogo(int npcPointer)
    {
        quemFala.GetComponent<NPCTrigger>().saiuDoCampo = true;

        GameManager.Instance.CineDisabled();
        
        player.GetComponent<PlayerMovement>().inDialog = false;
        textname.SetActive(false);
        textdialog.SetActive(false);
        butao.SetActive(false);
        Debug.Log("Fim da Conversa");
    }
}
