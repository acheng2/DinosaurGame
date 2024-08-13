using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject obstacle;
    private bool plantExist;
    private bool coroutinePlaying;

    // Start is called before the first frame update
    void Start() {
        plantExist = false;
        coroutinePlaying = false;
    }

    // Update is called once per frame
    void Update() {
        if (!coroutinePlaying && GameController.gamePlaying) {
            coroutinePlaying = true;
            StartCoroutine(Obstacles());
        } else if (coroutinePlaying && !GameController.gamePlaying) {
            coroutinePlaying = false;
            StopCoroutine(Obstacles());
        }
    }

    
    IEnumerator Obstacles() {
        while (GameController.gamePlaying) {
            //plantExist = true;
            int flying = Random.Range(1, 3);
            float newY = 0f;
            if (flying == 1) {
                // if ground obstacle
                newY = -2.28f;
            } else if (flying == 2) {
                // if flying obstacle
                newY = -0.5f;
            } // if-else
            Debug.Log(flying + "\t" + newY);
            Instantiate(obstacle, new Vector3(transform.position.x, newY, transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(2);
        } // while
    }
}
