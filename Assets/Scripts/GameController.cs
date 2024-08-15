using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static bool gamePlaying;
    public static bool gameEnd;
    public static bool gameRestart;

    [SerializeField]
    public GameObject gameEndScreen;

    [SerializeField]
    private GameObject selectionScreen;

    [SerializeField]
    private Text score;
    private int scoreValue;

    public static float gameSpeedIncrease = 0.1f;

    // Start is called before the first frame update
    void Start() {
        gamePlaying = false;
        gameEnd = false;
        gameRestart = false;

        gameEndScreen.SetActive(false);
        scoreValue = 0;
        score.text = scoreValue.ToString("D5");
    } // Start

    // Update is called once per frame
    void Update() {
        if (gamePlaying) {
            scoreValue += (int) Mathf.Floor(5f * Time.deltaTime * 200);
            score.text = scoreValue.ToString("D5");
        } // if
        
        if (gameEnd) {
            gameEndScreen.SetActive(true);
        } // if

        if (gameRestart) {
            scoreValue = 0;
            score.text = scoreValue.ToString("D5");
        } // if
    } // Update

    public void RestartGame() {
        gameEnd = false;
        gameRestart = true;
        gameEndScreen.SetActive(false);
        selectionScreen.SetActive(true);
    } // RestartGame
}
