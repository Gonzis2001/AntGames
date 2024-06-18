using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diolegue : MonoBehaviour
{
  [SerializeField]  private DialogueManager dialogueManager;

    [SerializeField] private string[] dialogue;
    [SerializeField]GameObject canvas;



    private bool isTalking = false;

    private void Start()
    {
        canvas.SetActive(false);
        dialogueManager.onDialogueEnd.AddListener(ResetDialogue);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PJ") && Input.GetKeyDown(KeyCode.E) && !isTalking)
        {
            
            isTalking = true;
            dialogueManager.StartDialogue(dialogue);
        }
        if(collision.CompareTag("PJ")  && !isTalking)
        {
            canvas.SetActive(true);
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PJ"))
        {
            canvas.SetActive(false);

        }
    }

    private void Update()
    {
        if (!isTalking)
        {
            
        }
    }

    private void ResetDialogue()
    {
        isTalking = false;
    }
}
