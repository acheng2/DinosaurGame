using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float jumpPower = 10;

    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    private void Start() {
        rigidbody = player.GetComponent<Rigidbody2D>();
    } // Start

    // Update is called once per frame
    private void Update() {
        if (Input.GetButtonDown("Jump")) {
            Jump();
        }
        Debug.Log(rigidbody.velocity.y);
    } // Update

    private void Jump() {
        if (rigidbody.velocity.y == 0) {
            rigidbody.velocity = new Vector2(0, jumpPower);
        }
    } // Jump
}
