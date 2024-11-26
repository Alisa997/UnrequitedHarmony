using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThree : MonoBehaviour
{

    [SerializeField]
    private Sprite mom;

    [SerializeField]
    private Sprite lainey;

    [SerializeField]
    private Talking talking;

    [SerializeField]
    private GameObject fridge;


    // Start is called before the first frame update
    void Start() {
        fridge.SetActive(true);
        talking.dialogueTrigger = new DialogueTrigger() {
            dialogue = new Dialogue
            {
                sentences = new Line[] {  new Line() { character = "Mommy",
                                                    speech = "Good morning my sweetheart, Happy Birthday!",
                                                    sprite = mom },
                                          new Line() { character = "Lainey",
                                                    speech = "Mommy what are you doing? Is it for me? Is it?",
                                                    sprite = lainey},
                                          new Line() { character = "Mommy",
                                                    speech = "Yes Lainey, it's your cake, why don't you go over there and wait while I finish.",
                                                    sprite = mom },
                                          new Line() { character = "Lainey",
                                                    speech = "No I want to help! Can I help! Let me help you Mommy!",
                                                    sprite = lainey},
                                          new Line() { character = "Mommy",
                                                    speech = "...",
                                                    sprite = mom },
                                          new Line() { character = "Mommy",
                                                    speech = "Well okay, why don't you watch for now",
                                                    sprite = mom },
                                          new Line() { character = "Lainey",
                                                    speech = "No I'll get the eggs from fridge! I'll get the eggs!",
                                                    sprite = lainey} }
            },

        };

    }


    // Update is called once per frame
    void Update() {
        
    }
}
