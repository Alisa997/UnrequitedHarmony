using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Narrating : Interactable
{

    public NarrativeTrigger narrativeTrigger;


    public override void Interact(Player player) {
        narrativeTrigger.TriggerNarrative(player);
    } // Interact
} // Talking
