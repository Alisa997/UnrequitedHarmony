using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class LevelTwo : Interactable
{
    [SerializeField]
    private GameObject gift;
    [SerializeField]
    private GameObject giftOpened;
    [SerializeField]
    private Animator animator;

    private int count = 0;
    private bool animationDone = false;
    private bool changeSceneDone = false;

    public override void Interact(Player player) {
        gift.SetActive(false);
        giftOpened.SetActive(true);
        StartCoroutine(Wait(2));
    } // Interact


    IEnumerator Wait(float seconds) {
        yield return new WaitForSeconds(seconds); // skip frame (time dilation)
        count++;
    } // Play3

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (count == 1 && !animationDone) {
            animationDone = true;
            animator.SetBool("isOn", true);
            StartCoroutine(Wait(7));
        }
        if (count == 2 && !changeSceneDone) {
            changeSceneDone = true;
            SceneManager.LoadScene("BedroomNow");
        }
    }
}
