using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // The Chracter's movement speed
    [SerializeField] // available from unity 
    private float speed;

    [SerializeField]
    private Animator animator;

    // The Character's direction
    protected Vector2 direction;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
    } // Start

    // Update is called once per frame
    protected virtual void Update() {
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
} // Character