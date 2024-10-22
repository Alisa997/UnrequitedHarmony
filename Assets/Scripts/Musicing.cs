using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicing : Interactable {
    public AudioTrigger audioTrigger;

    public override void Interact(Player player) {
        audioTrigger.TriggerAudio(player);
    } // Interact
}

