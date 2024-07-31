using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float jumpPower = 10;

    [SerializeField]
    private GameObject weapon;

    private Rigidbody2D rigidbody;
    private Animator animator;

    // Start is called before the first frame update
    private void Start() {
        rigidbody = player.GetComponent<Rigidbody2D>();
        animator = player.GetComponent<Animator>();
    } // Start

    // Update is called once per frame
    private void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            Jump();
        } // if jump

        if (Input.GetKeyDown(KeyCode.Space)) {
            Attack();
        } // if attack
    } // Update

    private void Jump() {
        if (rigidbody.velocity.y == 0) {
            rigidbody.velocity = new Vector2(0, jumpPower);
        }
    } // Jump

    private void Attack() {
        animator.SetTrigger("Attack");
    } // Attack
}
