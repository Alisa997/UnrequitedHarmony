using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NarrativeTrigger : MonoBehaviour
{
    public Narrative narrative;

    public void TriggerNarrative()
    {
        FindObjectOfType<NarrativeManager>().StartNarrative(narrative);
    } // TriggerNarrative
} // NarrativeTrigger
