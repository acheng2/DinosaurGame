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
        Debug.Log(GameController.gamePlaying);
        while (GameController.gamePlaying) {
            //plantExist = true;
            Instantiate(obstacle, new Vector3(transform.position.x, -2.28f, transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(2);
        } // while
    }
}
