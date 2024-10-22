using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void TriggerAudio(Player player) {
        player.isInteracting = true;

        audioSource.PlayOneShot(audioClip);
        player.isInteracting = false;
    } // TriggerNarrative
}
