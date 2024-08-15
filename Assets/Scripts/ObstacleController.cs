using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private String obstacleType;

    // Start is called before the first frame update
    void Start() {
        
    }
    
    void Update() {
        speed += GameController.gameSpeedIncrease * Time.deltaTime;
        if (GameController.gameRestart) {
            speed = 10f;
            Destroy(gameObject);
        } // if
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (GameController.gamePlaying) {
            //transform.Translate(new Vector2(-1f, 0f) * speed * Time.deltaTime);
            transform.position = transform.position + new Vector3(-1f, 0f, 0f) * speed * Time.deltaTime;
        }
    } // FixedUpdate

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log(collider.gameObject.tag);
        if (collider.gameObject.tag.Equals("Catcher")) {
            Debug.Log("gone");
            Destroy(gameObject);
        } else if (collider.gameObject.tag.Equals("Weapon") && obstacleType.Equals("hit")) {
            Debug.Log("pew");
            Destroy(gameObject);
        } else { //if (collider.gameObject.tag.Equals("Player")) {
            Debug.Log("hit");
            GameController.gamePlaying = false;
            GameController.gameEnd = true;
        }// if-else
    } // OnTriggerEnter2D
}
