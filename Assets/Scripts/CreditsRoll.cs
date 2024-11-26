using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsRoll : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    private int count = 0;
    private bool sounfDone = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait(22));
    }

    // Update is called once per frame
    void Update()
    {
        if(count == 1 && !sounfDone)
        {
            sounfDone = true;
            audioSource.Play();
        }
    }


    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds); // skip frame (time dilation)
        count++;
    } // Wait
}
