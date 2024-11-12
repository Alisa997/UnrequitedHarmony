using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class CloserLookManager : MonoBehaviour
{
    public TMP_Text description;
    public Image background;

    public Animator animator;

    private Player player = new Player();
    //private CloserLook closerLook = new CloserLook();

    // Start is called before the first frame update
    void Start() {

    } // Start

    public void StartCloserLook(Player pl, CloserLook cl) {
        player.isInteracting = true;
        animator.SetBool("isOpen", true);

        player = pl;

        player.CanInteract = false;
        player.CanMove = false;

        background.sprite = cl.sprite;

        StopAllCoroutines();
        StartCoroutine(TypeDescription(cl.description)); // starting parallel task
    } // StartDialogue

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.X)
            || Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyDown(KeyCode.Return))
        {
            EndCloserLook();
            return;
        } // if 
    } // Update

    IEnumerator TypeDescription(string text) {
        description.text = "";

        foreach (char letter in text.ToCharArray()) {
            if (letter == '+') description.text += "<br>";
            else description.text += letter;
            yield return new WaitForSeconds(0.03f);
        } // foreach
    }// TypeDescription

    void EndCloserLook() {
        StopAllCoroutines();
        animator.SetBool("isOpen", false);
        Debug.Log("End of closer look.");
        player.CanInteract = true;
        player.CanMove = true;
        player.isInteracting = false;
    } // EndDialogue

}