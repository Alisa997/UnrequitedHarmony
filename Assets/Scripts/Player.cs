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
    public bool isInteracting;

    [SerializeField]
    private GameObject piece;
    [SerializeField]
    private GameObject pieceInHands;
    [SerializeField]
    private int pieceIndex;

    private Vector2 rayBox = new Vector2(1f, 1f);

    // Start is called before the first frame update
    void Start() {
        player.position = new Vector2(PlayerStats.playerPos[0], PlayerStats.playerPos[1]);

        interactIcon.SetActive(false);
        CanInteract = true;
        isInteracting = false;

        CanMove = true;

        piece.SetActive(!PlayerStats.isCollected[pieceIndex]);
        pieceInHands.SetActive(PlayerStats.inHands);

    } // Update

    // Update is called once per frame
    protected override void Update() {
        if (Input.GetKeyDown(KeyCode.Z) && CanInteract) {
            CheckInteraction();
        } // if

        GetInput();
        if (CanMove) Move();

        piece.SetActive(!PlayerStats.isCollected[pieceIndex]);
        pieceInHands.SetActive(PlayerStats.inHands);

    } // Update


    private void GetInput()
    {
        direction = Vector2.zero; // reset direction
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

    } // GetInput

    // Moves the character
    public override void Move() {

        //player.MovePosition(new Vector2(transform.position.x + direction.x * speed * Time.deltaTime,
        //    transform.position.y + direction.y * speed * Time.deltaTime));

        player.MovePosition(
            new Vector2(transform.position.x, transform.position.y) + direction * speed * Time.fixedDeltaTime);


        AnimateMovement(direction);
    } // Move

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
