using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Musicing : Interactable {
    public AudioTrigger audioTrigger;
    public Animator[] animators;

    public override void Interact(Player player) {
        if (PlayerStats.inHands[PlayerStats.currentPiece]) {
            PlayerStats.inHands[PlayerStats.currentPiece] = false;
            StartCoroutine(Collected(player));
        }
        


        
        audioTrigger.TriggerAudio(player);
    } // Interact

    IEnumerator Collected(Player pl) {
        animators[PlayerStats.currentPiece].SetBool("isOn", true);
        pl.CanMove = false; pl.CanInteract = false;
        yield return new WaitForSeconds(5f); // skip frame (time dilation)
        animators[PlayerStats.currentPiece].SetBool("isOn", false);
        PlayerStats.currentPiece++;
        if (PlayerStats.currentPiece < 8) PlayerStats.isCollected[PlayerStats.currentPiece] = false;
        pl.CanMove = true; pl.CanInteract = true;
        SceneManager.LoadScene(PlayerStats.nextScene);
    } // Play2
}

