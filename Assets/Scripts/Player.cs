using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{


    // Start is called before the first frame update
    void Start()
    {

    } // Update

    // Update is called once per frame
    protected override void Update() {

        GetInput();
        base.Update();

    } // Update


    private void GetInput()
    {
        direction = Vector2.zero; // reset direction

        if (Input.GetKey(KeyCode.UpArrow)) // up
            direction = Vector2.up;

        if (Input.GetKey(KeyCode.DownArrow)) // down
            direction = Vector2.down;

        if (Input.GetKey(KeyCode.RightArrow)) // right
            direction = Vector2.right;

        if (Input.GetKey(KeyCode.LeftArrow)) // left
            direction = Vector2.left;

    } // GetInput
} // Player
