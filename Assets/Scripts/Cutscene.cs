using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    [SerializeField]
    private int duration;

    private int count;
    private bool enddone;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(Wait(duration));
    }

    // Update is called once per frame
    void Update() {
        if (count == 1 && !enddone) {
            enddone = true;
            End();
        }
    }

    IEnumerator Wait(float seconds) {
        yield return new WaitForSeconds(seconds); // skip frame (time dilation)
        count++;
    } // Wait

    void End() {
        SceneManager.LoadScene("BedroomNow");

    } // End

}
