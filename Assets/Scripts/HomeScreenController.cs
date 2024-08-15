using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenController : MonoBehaviour
{
    [SerializeField]
    private GameObject instructionsPage;
    void Start() {
        instructionsPage.SetActive(false);
    } // Start

    public void SceneSwitch(String scene) {
        SceneManager.LoadScene(scene);
    } // SceneSwitch

    public void ToggleInstructions(bool active) {
        instructionsPage.SetActive(active);
    } // ShowInstructions
}
