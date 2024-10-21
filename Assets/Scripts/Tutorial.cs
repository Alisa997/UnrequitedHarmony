using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private Sprite lola;

    [SerializeField]
    private Sprite lainey;

    [SerializeField]
    private Player player;

    // Start is called before the first frame update
    void Start() {
        DialogueTrigger dialogueTrigger = new DialogueTrigger() {
            dialogue = new Dialogue {
                sentences = new Line[1] { new Line() { character = "Lainey",
                                                    speech = "Where am I? It’s... so dark.",
                                                    sprite = lainey } }
            },

        };

        dialogueTrigger.TriggerDialogue(player);
    }

    // Update is called once per frame
    void Update() {


    }
}
