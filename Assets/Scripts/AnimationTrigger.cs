using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip defaultClip;
    public Animator animator;

    public void TriggerAnimation(Player player) {
        if (player.isInteracting) return;
        player.isInteracting = true;
        audioSource.Stop();
        audioSource.clip = audioClip;
        animator.SetBool("isOn", true);
        audioSource.PlayOneShot(audioClip);
        StartCoroutine(VerifyPlaying(player));
        
    } // TriggerNarrative

    IEnumerator VerifyPlaying(Player player) {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (!audioSource.isPlaying)
            {
                player.isInteracting = false;
                audioSource.clip = defaultClip;
                audioSource.Play();
                animator.SetBool("isOn", false);
            } // if
        } // while
    } // VerifyPlaying
}
