using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpac : MonoBehaviour
{
    [SerializeField] PlayerSO player;
    [SerializeField] Card potion;
    [SerializeField] private DialogueManager dialogueManager;

    [SerializeField] private string[] dialogue;




    private bool isTalking = false;

    private void Start()
    {
        isTalking = false;

        
        dialogueManager.onDialogueEnd.AddListener(ResetDialogue);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PJ") && Input.GetKeyDown(KeyCode.E) && !isTalking)
        {

            isTalking = true;
            player.hP = player.hPmax;
            if (player.ObjectDeck.Count < 4)
            {
                int veces = 4 - player.ObjectDeck.Count;
                for (int i = 0; i < veces; i++)
                {
                   player.ObjectDeck.Add(potion);

                }
            }
            dialogueManager.StartDialogue(dialogue);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    private void Update()
    {
        if (isTalking)
        {

        }
    }

    private void ResetDialogue()
    {
        isTalking = false;
    }
}
