using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{

    [SerializeField]
    private MusicBoxPiece[] pieces;

    [SerializeField]
    private Player player;


    private NarrativeTrigger narrativeTrigger;


    // Start is called before the first frame update
    void Start()
    {
        foreach (MusicBoxPiece p in pieces) {
            p.piece.SetActive(!PlayerStats.isCollected[p.pieceIndex]);
            p.pieceInHands.SetActive(PlayerStats.inHands[p.pieceIndex]);
        }
        if(PlayerStats.isStart) Play1();
        PlayerStats.isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (MusicBoxPiece p in pieces) {
            p.piece.SetActive(!PlayerStats.isCollected[p.pieceIndex]);
            p.pieceInHands.SetActive(PlayerStats.inHands[p.pieceIndex]);
        }
    }


    void Play1() {
        narrativeTrigger = new NarrativeTrigger()
        {
            narrative = new Narrative
            {
                sentences = new Sentence[] { new Sentence() { text = "It’s... empty. Just like I remember, but different.",
                                                               toAdd = false,
                                                               isQuestion = false,
                                                               cl = new CloserLook(),
                                                               answer = false},
                                              new Sentence() { text = "So much space. So much silence.",
                                                               toAdd = false,
                                                               isQuestion = false,
                                                               cl = new CloserLook()},
                                              new Sentence() { text = "I thought there’d be more.",
                                                               toAdd = false,
                                                               isQuestion = false,
                                                               cl = new CloserLook()},
                                              new Sentence() { text = "I thought I’d feel something, but it’s just... nothing.",
                                                               toAdd = true,
                                                               isQuestion = false,
                                                               cl = new CloserLook()},
                                              new Sentence() { text = "No one’s been here in years.",
                                                               toAdd = false,
                                                               isQuestion = false,
                                                               cl = new CloserLook()},
                                              new Sentence() { text = "This place is full of nothing.",
                                                               toAdd = true,
                                                               isQuestion = false,
                                                               cl = new CloserLook()},
                                              new Sentence() { text = "Just the echoes of what was...",
                                                               toAdd = false,
                                                               isQuestion = false,
                                                               cl = new CloserLook()} }

            },


        };

        narrativeTrigger.TriggerNarrative(player);
    } // Play1
}
