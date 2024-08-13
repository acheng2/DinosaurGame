using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject selectionScreen;
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private RuntimeAnimatorController anim;

    // Start is called before the first frame update
    void Start()
    {
        selectionScreen.SetActive(true);
        GameController.gamePlaying = false;
        playerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Submit() {
        if (!CharacterSelect.dinosaurSkin.Equals("")) {
            String newDinoSkin = CharacterSelect.dinosaurSkin;
            playerController.SetCharacter(newDinoSkin);
            selectionScreen.SetActive(false);
            GameController.gamePlaying = true;
        } else {
            Debug.Log("no character selected");
        }
    }
}
