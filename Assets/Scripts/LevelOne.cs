using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOne : MonoBehaviour
{

    [SerializeField]
    private Animator eyesAnimator;

    [SerializeField]
    private Player player;

    private NarrativeTrigger narrativeTrigger;

    private int count;
    private bool play1done;

    // Start is called before the first frame update
    void Start() {
        count = 0;
        play1done = false;
        StartCoroutine(Wait(5));
    }

    // Update is called once per frame
    void Update() {
        if (count == 1 && !play1done) {
            play1done = true;
            Play1();
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
    }
}
