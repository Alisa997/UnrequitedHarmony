using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{

    [SerializeField]
    private MusicBoxPiece[] pieces;


    // Start is called before the first frame update
    void Start()
    {
        foreach (MusicBoxPiece p in pieces) {
            p.piece.SetActive(!PlayerStats.isCollected[p.pieceIndex]);
            p.pieceInHands.SetActive(PlayerStats.inHands[p.pieceIndex]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        foreach (MusicBoxPiece p in pieces) {
            p.piece.SetActive(!PlayerStats.isCollected[p.pieceIndex]);
            p.pieceInHands.SetActive(PlayerStats.inHands[p.pieceIndex]);
        }
    }
}
