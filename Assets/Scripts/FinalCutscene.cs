using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCutscene : MonoBehaviour
{
    [SerializeField]
    private int duration;

    [SerializeField]
    private Player player;

    private int count;

    private bool play1done;
    private bool enddone;

    [SerializeField]
    private NarrativeTrigger narrativeTrigger;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(Wait(40));
    }

    // Update is called once per frame
    void Update() {
        if (count == 1 && !play1done) {
            play1done = true;
            Play1();
        }
        if (count == 2 && !enddone) {
            enddone = true;
            End();
        }
    }

    IEnumerator Wait(float seconds) {
        yield return new WaitForSeconds(seconds); // skip frame (time dilation)
        count++;
    } // Wait

    void Play1()
    {
        narrativeTrigger.TriggerNarrative(player);

        StartCoroutine(Wait(duration - 40));

    }

    void End() {
        SceneManager.LoadScene("CreditsRoll");

    } // End

}
