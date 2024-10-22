using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    [SerializeField]
    private Animator buttonsAnimator;

    private bool isStart = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        CheckButtons();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isStart)
                SceneManager.LoadScene("Tutorial");
            else
                Application.Quit();
        }
    } // Update

    private void CheckButtons() {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            isStart = !isStart;
            buttonsAnimator.SetBool("isStart", isStart);
        }
    } 
}
