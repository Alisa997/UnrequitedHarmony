using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicBoxPiece : Interactable {
    [SerializeField]
    public int pieceIndex;

    [SerializeField]
    public GameObject piece;

    [SerializeField]
    public GameObject pieceInHands;

    [SerializeField]
    private string nextScene;

    public float x;
    public float y;

    [SerializeField]
    private Player player;

    private NarrativeTrigger narrativeTrigger;

    public override void Interact(Player player) {
        if (pieceIndex == 0) FirstPiece();

        PlayerStats.isCollected[pieceIndex] = true;
        PlayerStats.inHands[PlayerStats.currentPiece] = true;
        PlayerStats.playerPos = new float[] { x, y };
        PlayerStats.nextScene = nextScene;
    } // Interact

    // FirstPiece
    void FirstPiece() {
        narrativeTrigger = new NarrativeTrigger()
        {
            narrative = new Narrative
            {
                sentences = new Sentence[3] { new Sentence() { text = "This... ",
                                                               toAdd = false,
                                                               isQuestion = false,
                                                               cl = new CloserLook(),
                                                               answer = false},
                                              new Sentence() { text = "it looks like it belongs to the music box. ",
                                                               toAdd = true,
                                                               isQuestion = false,
                                                               cl = new CloserLook()},
                                              new Sentence() { text = "Maybe if I place it back, something will change.",
                                                               toAdd = false,
                                                               isQuestion = false,
                                                               cl = new CloserLook()}}

            },


        };

        narrativeTrigger.TriggerNarrative(player);
    } // FirstPiece
}
