using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : Interactable
{
    public string SceneName;
    public override void Interact(Player player) {
        SceneManager.LoadScene(SceneName);
    } // Interact
}
