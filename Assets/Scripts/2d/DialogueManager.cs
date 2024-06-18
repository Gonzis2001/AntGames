using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    public GameObject dialogueBox;
    private Queue<string> sentences;

    private bool isTyping = false;

    public UnityEvent onDialogueEnd;

    void Start()
    {
        sentences = new Queue<string>();
        if (onDialogueEnd == null)
            onDialogueEnd = new UnityEvent();
    }

    public void StartDialogue(string[] dialogue)
    {
        dialogueBox.SetActive(true);
        sentences.Clear();

        foreach (string sentence in dialogue)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        if (!isTyping)
        {
            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        isTyping = false;
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
        onDialogueEnd.Invoke();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isTyping)
        {
            DisplayNextSentence();
        }
    }
}
