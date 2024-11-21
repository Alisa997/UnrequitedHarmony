using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : Interactable
{
    public string SceneName;
    public float x;
    public float y;

    public override void Interact(Player player) {
        PlayerStats.playerPos = new float[] { x, y };
        SceneManager.LoadScene(SceneName);
    } // Interact
}
