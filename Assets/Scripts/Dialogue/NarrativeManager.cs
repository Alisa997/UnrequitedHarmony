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
    // Start is called before the first frame update
    void Start() {
        sentences = new Queue<Sentence>();
        current = new Sentence {toAdd = false, text = ""};
    } // Start

    public void StartNarrative(Narrative narrative) {
        animator.SetBool("isOpen", true);


        sentences.Clear();

        foreach (Sentence sentence in narrative.sentences) {
            sentences.Enqueue(sentence);
        }// foreach

        DisplayNextSentence();
    } // StartDialogue

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("z")) {
            DisplayNextSentence();
        } // if 
    } // Update

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndNarrative();
            return;
        } // if
        text.text = current.text;

        Sentence sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence)); // starting parallel task
    }// DisplayNextSentence

    IEnumerator TypeSentence(Sentence sentence) {
        current = sentence;
        if (sentence.toAdd) text.text += " ";
        else text.text = "";

        foreach (char letter in sentence.text.ToCharArray()) {
            text.text += letter;
            yield return new WaitForSeconds(0.03f); // skip frame (time dilation)
        } // foreach
    }// TypeSentence

    void EndNarrative() {
        animator.SetBool("isOpen", false);
        Debug.Log("End of conversation.");
    } // EndNarrative


}
