using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class LevelFive : Interactable
{
    [SerializeField]
    private GameObject vase;

    [SerializeField]
    private GameObject vaseBroken;

    [SerializeField]
    private GameObject[] doors;

    [SerializeField]
    private ChangeScene bedroom;

    [SerializeField]
    private Player player;

    [SerializeField]
    private Narrating narrating;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private AudioClip defaultClip;

    private NarrativeTrigger narrativeTrigger;

    private int count = 0;
    private bool narationDone = false;
    private bool changeSceneDone = false;

    public override void Interact(Player player) {
        if (count == 0) {

            foreach(GameObject d in doors) {
                d.SetActive(false);
            }

            bedroom.SceneName = "Closet";

            vase.SetActive(false);
            vaseBroken.SetActive(true);
            StartCoroutine(Wait(2));

            audioSource.Stop();
            audioSource.clip = audioClip;
            audioSource.PlayOneShot(audioClip);

            StartCoroutine(VerifyPlaying(player));
        }
    } // Interact


    IEnumerator VerifyPlaying(Player player) {
        while (true)  {
            yield return new WaitForSeconds(1f);
            if (!audioSource.isPlaying)
            {
                player.isInteracting = false;
                audioSource.clip = defaultClip;
                audioSource.Play();
            } // if
        } // while
    } // VerifyPlaying

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds); // skip frame (time dilation)
        count++;
    } // Play3

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if(count == 1 && !narationDone)
        {
            narationDone = true;
            Play1();
        }
        
    }

    private void Play1() {
        narrativeTrigger = new NarrativeTrigger()
        {
            narrative = new Narrative
            {
                sentences = new Sentence[] { new Sentence() { text = "Oh no! Mommy’s gonna be so mad...",
                                                               toAdd = false,
                                                               isQuestion = false,
                                                               cl = new CloserLook(),
                                                               answer = false},
                                              new Sentence() { text = "I didn’t mean to... I didn’t mean to!",
                                                               toAdd = false,
                                                               isQuestion = false,
                                                               cl = new CloserLook()},
                                              new Sentence() { text = "I... I’ll hide. Maybe if I’m not here, she won’t be so mad.",
                                                               toAdd = false,
                                                               isQuestion = false,
                                                               cl = new CloserLook()},
                                              new Sentence() { text = "The closet... I’ll hide in there!",
                                                               toAdd = false,
                                                               isQuestion = false,
                                                               cl = new CloserLook()}}

            },


        };

        narrating.narrativeTrigger = narrativeTrigger;


        narrativeTrigger.TriggerNarrative(player);
    } // Play1
}
