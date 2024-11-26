using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class Closet : Interactable {

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private Animator video;

    [SerializeField]
    private UnityEngine.Video.VideoPlayer videoPlayer;

    private int count = 0;
    private bool sceneChanged = false;

    public override void Interact(Player player) {
        video.SetBool("isOn", true);
        audioSource.Stop();
        videoPlayer.Play();
        PlayerStats.playerPos = new float[] { 0, 0 };

        StartCoroutine(Wait(17));
    } // Interact

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
        if (count == 1 && !sceneChanged)  {
            sceneChanged = true;
            SceneManager.LoadScene("BedroomNow");
        }
    }
}
