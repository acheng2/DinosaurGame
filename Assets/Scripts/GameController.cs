using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool gamePlaying;
    public static bool gameEnd;
    public static bool gameRestart;

    [SerializeField]
    public GameObject gameEndScreen;

    [SerializeField]
    private GameObject selectionScreen;

    // Start is called before the first frame update
    void Start() {
        gamePlaying = false;
        gameEnd = false;
        gameRestart = false;

        gameEndScreen.SetActive(false);
    } // Start

    // Update is called once per frame
    void Update() {
        if (gameEnd) {
            gameEndScreen.SetActive(true);
        } // if
    } // Update

    public void RestartGame() {
        gameEnd = false;
        gameRestart = true;
        gameEndScreen.SetActive(false);
        selectionScreen.SetActive(true);
    } // RestartGame
}
