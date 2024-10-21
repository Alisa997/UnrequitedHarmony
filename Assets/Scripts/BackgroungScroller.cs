using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroungScroller:MonoBehaviour
{
    [Range(0, 10f)]
    public float scrollSpeed = 0.5f;
    [SerializeField]
    private Background bg;

    private float offset;
    private float offsetVert;

    [SerializeField]
    private GameObject interactIcon;

    [SerializeField]
    private Rigidbody2D player;

    public bool CanInteract;


    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Character lola; 

    private Vector2 rayBox = new Vector2(1f, 1f);

    // The Character's direction
    protected Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
        interactIcon.SetActive(false);
        CanInteract = true;
        //CanMove = true;
    } // Update

    // Update is called once per frame
    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && CanInteract)
        {
            CheckInteraction();
        } // if

        GetInput();

    } // Update


    private void GetInput()
    {

        bool moved = false;

        if (Input.GetKey(KeyCode.UpArrow)) { // up
            offsetVert += (Time.deltaTime * scrollSpeed) / 10f;
            moved = true;
            direction = Vector2.up;
        }

        if (Input.GetKey(KeyCode.DownArrow)) { // down
            offsetVert += (Time.deltaTime * (-scrollSpeed)) / 10f;
            moved = true;
            direction = Vector2.down;
        }

        if (Input.GetKey(KeyCode.RightArrow)) {  // right
            offset += (Time.deltaTime * scrollSpeed) / 10f;
            moved = true;
            direction = Vector2.right;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {  // left
            offset += (Time.deltaTime * (-scrollSpeed)) / 10f;
            moved = true;
            direction = Vector2.left;
        }

        //transform.position = lola + offset;

        // Update both offsets, even when only one is moved
        if (moved)
        {
            bg.mat.SetTextureOffset("_MainTex", new Vector2(offset, offsetVert));
            AnimateMovement(direction);
        }
    } // GetInput

    public void AnimateMovement(Vector2 direction) {

        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);

    } // Animate


    public void OpenInteractableIcon() {
        interactIcon.SetActive(true);
    } // OpenInteractableIcon

    public void CloseInteractableIcon() {
        interactIcon.SetActive(false);
    } // CloseInteractableIcon

    private void CheckInteraction() {
        if (!interactIcon.active) return;
        RaycastHit2D[] hits = Physics2D.BoxCastAll(player.position, rayBox, 0, Vector2.zero);
        if (hits.Length > 0) {
            foreach (RaycastHit2D rc in hits)  {
                if (rc.transform.GetComponent<Interactable>()) {
                    //rc.transform.GetComponent<Interactable>().Interact(this);
                    return;
                } // if
            } // foreach 
        } // if
    } // CheckInteraction
}

