using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (GameController.gamePlaying) {
            transform.Translate(new Vector2(-1f, 0f) * speed * Time.deltaTime);
        }
    } // FixedUpdate

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log(collider.gameObject.tag);
        if (collider.gameObject.tag.Equals("Player")) {
            Debug.Log("hit");
            GameController.gamePlaying = false;
        } else if (collider.gameObject.tag.Equals("Catcher")) {
            Debug.Log("gone");
            Destroy(gameObject);
        } // if-else
    } // OnTriggerEnter2D
}
