using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats {
    public static bool[] isCollected = {false, true, true, true, true, true, true, true, true };

    public static bool[] inHands = {false, false, false, false, false, false, false, false, false};

    //public static bool inHands = false;
    public static int currentPiece = 0;

    public static float[] playerPos = {0, 0};

    public static string nextScene = " ";
    public static bool talkedToMom = false;
    public static bool isStart = true;
}
