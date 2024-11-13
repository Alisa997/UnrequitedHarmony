using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    public Animator animator;

    private Queue<Sentence> sentences;
    private Sentence current;

    private Player player;
    private int counter = 0;
    private bool NarrationStarted = false;
    // Start is called before the first frame update
    void Start() {
        sentences = new Queue<Sentence>();
        current = new Sentence {toAdd = false, text = ""};
        player = FindObjectOfType<Player>(); 
    } // Start

    public void StartNarrative(Player pl, Narrative narrative) {
        animator.SetBool("isOpen", true);
        animator.SetBool("Answer", true);
        counter = 0;
        player = pl;

        player.CanInteract = false;
        player.CanMove = false;
        player.isInteracting = true;

        sentences.Clear();

        foreach (Sentence sentence in narrative.sentences) {
            sentences.Enqueue(new Sentence() { isQuestion = sentence.isQuestion,
                                                answer = true,
                                                text = sentence.text,
                                                toAdd = sentence.toAdd,
                                                cl = sentence.cl});
        }// foreach
        NarrationStarted = true;
        DisplayNextSentence();
    } // StartDialogue

    // Update is called once per frame
    void Update() {
        if (current.isQuestion &&
            (Input.GetKeyDown(KeyCode.RightArrow) ||
            Input.GetKeyDown(KeyCode.LeftArrow)   ||
            Input.GetKeyDown(KeyCode.UpArrow)     ||
            Input.GetKeyDown(KeyCode.DownArrow))) {
            SwitchAnswer();
        }
        if ((Input.GetKeyDown("space") || Input.GetKeyDown("return")) && NarrationStarted) {
            DisplayNextSentence();
        } // if 
    } // Update

    public void DisplayNextSentence() {
        if (sentences.Count == 0 && NarrationStarted) {
            EndNarrative();
            return;
        } // if
        text.text = current.text;

        player.CanInteract = false;
        player.CanMove = false;

        Sentence sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence)); // starting parallel task
    }// DisplayNextSentence

    IEnumerator TypeSentence(Sentence sentence) {
        animator.SetBool("isQuestion", sentence.isQuestion);
        current = sentence;
        if (sentence.toAdd) text.text += " ";
        else text.text = "";

        foreach (char letter in sentence.text.ToCharArray()) {
            text.text += letter;
            yield return new WaitForSeconds(0.03f); // skip frame (time dilation)
        } // foreach
    }// TypeSentence

    private void SwitchAnswer() {
        current.answer = !current.answer;
        animator.SetBool("Answer", current.answer);
    } // SwitchAnswer

    void EndNarrative() {
        animator.SetBool("isOpen", false);
        Debug.Log("End of conversation.");
        player.CanInteract = true;
        player.CanMove = true;

        player.isInteracting = false;
        NarrationStarted = false;
        if (current.isQuestion && current.answer&& counter == 0) {
            counter++;
            FindObjectOfType<CloserLookManager>().StartCloserLook(player, current.cl);
        }
    } // EndNarrative


}
