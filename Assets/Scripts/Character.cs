using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private GameObject interactIcon;

    // The Chracter's movement speed
    [SerializeField] // available from unity 
    private float speed;

    [SerializeField]
    private Animator animator;

    // The Character's direction
    protected Vector2 direction;

    [SerializeField]
    private Rigidbody2D player;

    private Vector2 rayBox = new Vector2(2f, 2f);

    // Start is called before the first frame update
    void Start() {
        interactIcon.SetActive(false);
        animator = GetComponent<Animator>();
    } // Start

    // Update is called once per frame
    protected virtual void Update() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            CheckInteraction();
        } // if
        Move();
    } // Update


    // Moves the character
    public void Move() {

        transform.Translate(direction * speed * Time.deltaTime);

        AnimateMovement(direction);
    } // Move


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
        RaycastHit2D[] hits = Physics2D.BoxCastAll(player.position, rayBox, 0, Vector2.zero);
        if (hits.Length > 0)
        {
            foreach (RaycastHit2D rc in hits)
            {
                if (rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact();
                    return;
                } // if
            } // foreach 
        } // if
    } // CheckInteraction
} // Character
