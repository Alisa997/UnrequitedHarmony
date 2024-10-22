using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private Sprite lola;

    [SerializeField]
    private Sprite lainey;

    [SerializeField]
    private Player player;

    [SerializeField]
    private Animator lolaAnimator;

    [SerializeField]
    private Animator musicboxAnimator;

    [SerializeField]
    private Animator shadowAnimator;

    [SerializeField]
    private GameObject musicbox;

    private DialogueTrigger dialogueTrigger;

    private int counter = 0;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start() {
        //lolaAnimator = GetComponent<Animator>();
        lolaAnimator.SetBool("isActive", false);
        musicboxAnimator.SetBool("isActive", false);
        musicbox.SetActive(false);
        player.CanMove = false;


        dialogueTrigger = new DialogueTrigger()
        {
            dialogue = new Dialogue
            {
                sentences = new Line[2] { new Line() { character = "Lainey",
                                                    speech = "Where am I?",
                                                    sprite = lainey },
                                          new Line() { character = "Lainey",
                                                    speech = "It’s... so dark.",
                                                    sprite = lainey }}
            },

        };

        dialogueTrigger.TriggerDialogue(player);

        //player.CanMove = false;
    }

    // Update is called once per frame
    void Update() {
        if (player.CanMove && counter == 0) {
            StartCoroutine(Play());
            counter++;
        }
        if(player.transform.position != new Vector3(0, 0, 0) && counter == 1) {
            player.CanInteract = false;
            StartCoroutine(Play2());
            counter++;
        }
        if (player.CanInteract && counter == 2) {
            StartCoroutine(Play3());
            counter++;
            player.CanInteract = false;
            player.isInteracting = true;
        }

        // починить: так чтобы можно было нажать кнопку только рядом со шкатулкой  
        if (Input.GetKeyDown(KeyCode.Z) && !player.isInteracting) {
            audioSource.Pause();
            StartCoroutine(End());
            counter++;
            player.CanInteract = false;
        } // if

        if(player.CanInteract && counter == 4) {
            SceneManager.LoadScene("Bedroom");
        }
    }

    IEnumerator Play() {
        player.CanMove = false;

        lolaAnimator.SetBool("isActive", true);
        yield return new WaitForSeconds(2f); // skip frame (time dilation)
        dialogueTrigger = new DialogueTrigger()
        {
            dialogue = new Dialogue
            {
                sentences = new Line[] { new Line() { character = "Lola",
                                                    speech = "Hey, Lainey! You’re in a place between the memories.",
                                                    sprite = lola },
                                          new Line() { character = "Lola",
                                                    speech = "Don’t worry, I’m here with you.",
                                                    sprite = lola },
                                          new Line() { character = "Lainey",
                                                    speech = "It feels... empty. How do I move?",
                                                    sprite = lainey },
                                          new Line() { character = "Lola",
                                                    speech = "Take it slow. Use the arrow keys to find your way",
                                                    sprite = lola }}
            },

        };

        dialogueTrigger.TriggerDialogue(player);
    } // Play

    IEnumerator Play2() {
        yield return new WaitForSeconds(2f); // skip frame (time dilation)
        dialogueTrigger = new DialogueTrigger()
        {
            dialogue = new Dialogue
            {
                sentences = new Line[] { new Line() { character = "Lola",
                                                    speech = "Good, you’re getting the hang of it.",
                                                    sprite = lola },
                                          new Line() { character = "Lola",
                                                    speech = "To interact with anything in here, press Z.",
                                                    sprite = lola }}
            },

        };

        dialogueTrigger.TriggerDialogue(player);

        
    } // Play2

    IEnumerator Play3() {

        musicbox.SetActive(true);
        musicboxAnimator.SetBool("isActive", true);
        yield return new WaitForSeconds(0.5f); // skip frame (time dilation)
        dialogueTrigger = new DialogueTrigger()
        {
            dialogue = new Dialogue
            {
                sentences = new Line[] { new Line() { character = "Lainey",
                                                    speech = "Wait... is that...?",
                                                    sprite = lainey },
                                          new Line() { character = "Lola",
                                                    speech = "That music box was always in your room, wasn’t it?",
                                                    sprite = lola },
                                          new Line() { character = "Lola",
                                                    speech = "Maybe it’ll help you remember. Go ahead, press Z.",
                                                    sprite = lola }}
            },

        };

        dialogueTrigger.TriggerDialogue(player);
    } // Play2


    IEnumerator End() {
        shadowAnimator.SetBool("isOn", true);
        yield return new WaitForSeconds(6f); // skip frame (time dilation)

        dialogueTrigger = new DialogueTrigger() {
            dialogue = new Dialogue {
                sentences = new Line[] { new Line() { character = "Lainey",
                                                    speech = "I remember this... from my bedroom.",
                                                    sprite = lainey },
                                          new Line() { character = "Lola",
                                                    speech = "Welcome back. This is where it all started.",
                                                    sprite = lola }}
            },

        };

        dialogueTrigger.TriggerDialogue(player);
    } // Play2

}
