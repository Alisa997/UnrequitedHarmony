using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip defaultClip;

    public void TriggerAudio(Player player) {
        if (player.isInteracting) return;
        player.isInteracting = true;
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.PlayOneShot(audioClip);
        
        StartCoroutine(VerifyPlaying(player));
    } // TriggerNarrative

    IEnumerator VerifyPlaying(Player player) {
        while (true) {
            yield return new WaitForSeconds(1f);
            if (!audioSource.isPlaying) {
                player.isInteracting = false;
                audioSource.clip = defaultClip;
                audioSource.Play();
            } // if
        } // while
    } // VerifyPlaying
}
