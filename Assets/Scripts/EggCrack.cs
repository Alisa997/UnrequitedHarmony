using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(SpriteRenderer))]
public class EggCrack : Interactable {
    [SerializeField]
    private GameObject egg;

    [SerializeField]
    private GameObject mommy;

    [SerializeField]
    private GameObject fridge;

    [SerializeField]
    private Player player;

    [SerializeField]
    private Sprite mom1;

    [SerializeField]
    private Sprite mom2;

    [SerializeField]
    private Sprite lainey;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private Animator video;

    [SerializeField]
    private UnityEngine.Video.VideoPlayer videoPlayer;

    private DialogueTrigger dialogueTrigger;

    private int count = 0;
    private bool play1done = false;
    private bool enddone;
    private bool changeSceneDone = false;

    public override void Interact(Player player) {
        mommy.SetActive(false);
        this.player = player;
        if (count == 0) {
            count++;
            egg.SetActive(true);

            audioSource.Stop();
            audioSource.PlayOneShot(audioClip);
            StartCoroutine(Wait(3));
            Update();
        }
    } // Interact

    private void Update() {
        if(count == 2 && !play1done) {
            play1done = true;
            Play1();
        }
        if(count == 3 && !enddone) {
            enddone = true;
            End();
        }
        if(count == 4 && !changeSceneDone) {
            changeSceneDone = true;
            SceneManager.LoadScene("BedroomNow");
        }


    } // Update

    IEnumerator Wait(float seconds) {
        yield return new WaitForSeconds(seconds); // skip frame (time dilation)
        count++;
    } // Play3

    void Play1()
    {
        dialogueTrigger = new DialogueTrigger()
        {
            dialogue = new Dialogue
            {
                sentences = new Line[] { new Line() { character = "Lainey",
                                                    speech = "Oh... ",
                                                    sprite = lainey },
                                          new Line() { character = "Lainey",
                                                    speech = "I dropped it...I'm sorry Mommy",
                                                    sprite = lainey },
                                          new Line() { character = "Lainey",
                                                    speech = "Mommy?",
                                                    sprite = lainey },
                                          new Line() { character = "Mommy",
                                                    speech = "...",
                                                    sprite = mom1 },
                                          new Line() { character = "Lainey",
                                                    speech = "Mommy? Mommy?",
                                                    sprite = lainey },
                                          new Line() { character = "Lainey",
                                                    speech = "Mommy?...",
                                                    sprite = lainey },
                                          new Line() { character = "Mommy",
                                                    speech = "...",
                                                    sprite = mom2 }}
            },

        };


        dialogueTrigger.TriggerDialogue(player);
        StartCoroutine(Wait(7));
    } // Play1

    void End() {
        video.SetBool("isOn", true);
        videoPlayer.Play();
        PlayerStats.playerPos = new float[] { 0, 0};

        StartCoroutine(Wait(24));
    } // End
} // EggCrack

