using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBoxPiece : Interactable {
    [SerializeField]
    private int pieceIndex;

    [SerializeField]
    private string nextScene;

    public override void Interact(Player player) {
        PlayerStats.isCollected[pieceIndex] = true;
        PlayerStats.inHands = true;
        PlayerStats.nextScene = nextScene;
    } // Interact
}
