using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Image characterImage;

    public Animator animator;

    private Queue<Line> sentences; // fifo -- first in first out

    private Player player;
    private int counter;

    private bool DialogueStarted = false;

    // Start is called before the first frame update
    void Start() {
        sentences = new Queue<Line>();
        player = FindObjectOfType<Player>();
    } // Start

    public void StartDialogue(Player pl, Dialogue dialogue) {
        player = pl;
        animator.SetBool("isOpen", true);

        player.CanInteract = false;
        player.CanMove = false;

        sentences.Clear();

        foreach (Line sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }// foreach
        DialogueStarted = true;

        DisplayNextSentence();
    } // StartDialogue

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("space") && DialogueStarted) {
            DisplayNextSentence();
        } // if 
    } // Update

    public void DisplayNextSentence() {
        if(sentences.Count == 0&& DialogueStarted) {
            EndDialogue();
            return;
        } // if
        player.CanInteract = false;
        player.CanMove = false;


        Line sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence)); // starting parallel task
    }// DisplayNextSentence

    IEnumerator TypeSentence(Line sentence) {
        dialogueText.text = "";
        nameText.text = sentence.character;
        characterImage.sprite = sentence.sprite;

        foreach (char letter in sentence.speech.ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.03f);
        } // foreach
    }// TypeSentence

    private void EndDialogue() {
        DialogueStarted = false;
        animator.SetBool("isOpen", false);
        Debug.Log("End of conversation.");
        player.CanInteract = true;
        player.CanMove = true;
    } // EndDialogue
} // DialogueManager
