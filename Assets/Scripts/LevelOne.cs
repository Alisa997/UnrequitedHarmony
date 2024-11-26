using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOne : MonoBehaviour
{

    [SerializeField]
    private Animator eyesAnimator;

    [SerializeField]
    private Player player;

    [SerializeField]
    private Animator shadowAnimator;

    private NarrativeTrigger narrativeTrigger;

    private int count;
    private bool play1done;
    private bool play2done;
    private bool play3done;
    private bool enddone;

    // Start is called before the first frame update
    void Start() {
        count = 0;
        play1done = false;
        play2done = false;
        play3done = false;
        enddone = false;
        StartCoroutine(Wait(5));
    }

    // Update is called once per frame
    void Update() {
        if (count == 1 && !play1done) {
            play1done = true;
            Play1();
        }
        if (count == 2 && !play2done) {
            play2done = true;
            Play2();
        }
        if (count == 3 && !play3done) {
            play3done = true;
            Play3();
        }
        if (count == 4 && !enddone) {
            enddone = true;
            StartCoroutine(End());
        }
    }

    IEnumerator Wait(float seconds) {
        yield return new WaitForSeconds(seconds); // skip frame (time dilation)
        count++;
    } // Play3

    void Play1() {
        narrativeTrigger = new NarrativeTrigger()
        {
            narrative = new Narrative
            {
                sentences = new Sentence[3] { new Sentence() { text = "Where am I?",
                                                               toAdd = false,
                                                               isQuestion = false,
                                                               cl = new CloserLook(),
                                                               answer = false},
                                              new Sentence() { text = "Oh... it's just my room.",
                                                               toAdd = false,
                                                               isQuestion = false,
                                                               cl = new CloserLook()},
                                              new Sentence() { text = "Everything's okay.",
                                                               toAdd = true,
                                                               isQuestion = false,
                                                               cl = new CloserLook()} }

            },


        };

        narrativeTrigger.TriggerNarrative(player);
        StartCoroutine(Wait(8));
    } // Play1


    void Play2() {
        narrativeTrigger = new NarrativeTrigger()
        {
            narrative = new Narrative
            {
                sentences = new Sentence[2] { new Sentence() { text = "Mommy’s here... she’s always here when I wake up.",
                                                               toAdd = false,
                                                               isQuestion = false,
                                                               cl = new CloserLook(),
                                                               answer = false},
                                              new Sentence() { text = "I love when she sings to me. It’s like the world is softer with her voice",
                                                               toAdd = false,
                                                               isQuestion = false,
                                                               cl = new CloserLook()}}

            },


        };

        narrativeTrigger.TriggerNarrative(player);
        StartCoroutine(Wait(8));
    } // Play2


    // Play 3
    void Play3() {
        narrativeTrigger = new NarrativeTrigger()
        {
            narrative = new Narrative
            {
                sentences = new Sentence[2] { new Sentence() { text = "Mommy... can I stay like this forever?",
                                                               toAdd = false,
                                                               isQuestion = false,
                                                               cl = new CloserLook(),
                                                               answer = false},
                                              new Sentence() { text = "I don’t want to wake up again... not yet.",
                                                               toAdd = false,
                                                               isQuestion = false,
                                                               cl = new CloserLook()}}

            },


        };

        narrativeTrigger.TriggerNarrative(player);
        StartCoroutine(Wait(11));
    } // Play3

    IEnumerator End() {
        shadowAnimator.SetBool("isOn", true);
        yield return new WaitForSeconds(12f); // skip frame (time dilation)
        SceneManager.LoadScene("BedroomNow");

    } // Play2

}
