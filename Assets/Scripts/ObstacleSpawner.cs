using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject groundObstacle;
    [SerializeField]
    private GameObject ground2Obstacle;
    [SerializeField]
    private GameObject skyObstacle;
    [SerializeField]
    private GameObject sky2Obstacle;
    [SerializeField]
    private GameObject hitObstacle;
    [SerializeField]
    private GameObject hit2Obstacle;
    private bool coroutinePlaying;
    private float waitSeconds = 2f;

    // Start is called before the first frame update
    void Start() {
        coroutinePlaying = false;
    } // Start

    // Update is called once per frame
    void Update() {
        waitSeconds -= GameController.gameSpeedIncrease * Time.deltaTime;
        if (!coroutinePlaying && GameController.gamePlaying) {
            coroutinePlaying = true;
            StartCoroutine(Obstacles());
        } else if (coroutinePlaying && !GameController.gamePlaying) {
            coroutinePlaying = false;
            StopCoroutine(Obstacles());
            waitSeconds = 2f;
        } // if
    } // Update

    
    IEnumerator Obstacles() {
        while (GameController.gamePlaying) {
            //plantExist = true;
            int obstacleType = Random.Range(1, 4);
            float newY = 0f;
            
            GameObject obstacle = groundObstacle;
            Quaternion rotation = Quaternion.identity;
            int obstacleSkin = Random.Range(1, 3);
            if (obstacleType == 1) {
                // if ground obstacle
                newY = -2.28f;
                if (obstacleSkin == 1) {
                    obstacle = groundObstacle;
                } else if (obstacleSkin == 2) {
                    obstacle = ground2Obstacle;
                } // if
            } else if (obstacleType == 2) {
                // if flying obstacle
                newY = -1.2f;
                rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                if (obstacleSkin == 1) {
                    obstacle = skyObstacle;
                } else if (obstacleSkin == 2) {
                    obstacle = sky2Obstacle;
                } // if
            } else if (obstacleType == 3) {
                newY = -1.6f;
                if (obstacleSkin == 1) {
                    obstacle = hitObstacle;
                } else if (obstacleSkin == 2) {
                    obstacle = hit2Obstacle;
                } // if
            } // if-else
            Instantiate(obstacle, new Vector3(transform.position.x, newY, transform.position.z), rotation);

            float staggerObstacle = Random.Range(0, 100) / 100f;
            yield return new WaitForSeconds(waitSeconds + staggerObstacle);
        } // while
    } // Obstacles
}
