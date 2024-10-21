using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private GameObject interactIcon;

    [SerializeField]
    private Rigidbody2D player;

    public bool CanInteract;

    private Vector2 rayBox = new Vector2(1f, 1f);

    // Start is called before the first frame update
    void Start() {

        interactIcon.SetActive(false);
        CanInteract = true;
        CanMove = true;
    } // Update

    // Update is called once per frame
    protected override void Update() {
        if (Input.GetKeyDown(KeyCode.Z) && CanInteract) {
            CheckInteraction();
        } // if

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


    public void OpenInteractableIcon() {
        interactIcon.SetActive(true);
    } // OpenInteractableIcon

    public void CloseInteractableIcon() {
        interactIcon.SetActive(false);
    } // CloseInteractableIcon

    private void CheckInteraction() {
        if (!interactIcon.active) return;
        RaycastHit2D[] hits = Physics2D.BoxCastAll(player.position, rayBox, 0, Vector2.zero);
        if (hits.Length > 0)
        {
            foreach (RaycastHit2D rc in hits)
            {
                if (rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact(this);
                    return;
                } // if
            } // foreach 
        } // if
    } // CheckInteraction
} // Player
