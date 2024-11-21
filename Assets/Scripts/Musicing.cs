using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Musicing : Interactable {
    public AudioTrigger audioTrigger;

    public override void Interact(Player player) {
        if(PlayerStats.inHands) SceneManager.LoadScene(PlayerStats.nextScene);
        PlayerStats.inHands = false;

        audioTrigger.TriggerAudio(player);
    } // Interact
}

