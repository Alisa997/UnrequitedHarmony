using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NarrativeTrigger : MonoBehaviour
{
    public Narrative narrative;

    public void TriggerNarrative(Player pl) {
        FindObjectOfType<NarrativeManager>().StartNarrative(pl, narrative);
    } // TriggerNarrative
} // NarrativeTrigger
