using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animating : Interactable {
    public AnimationTrigger animationTrigger;

    public override void Interact(Player player) {
        animationTrigger.TriggerAnimation(player);
    } // Interact
}
