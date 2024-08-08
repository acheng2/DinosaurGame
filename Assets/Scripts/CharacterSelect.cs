using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField]
    private String skinName;
    public static String dinosaurSkin;
    public static Boolean skinClicked;
    private Sprite onSprite;
    private Sprite offSprite;
    [SerializeField]
    public RuntimeAnimatorController anim;

    // Start is called before the first frame update
    void Start()
    {
        dinosaurSkin = "";
        skinClicked = false;
        offSprite = Resources.Load<Sprite>(skinName + "/" + skinName + "Off");
        onSprite = Resources.Load<Sprite>(skinName + "/" + skinName + "On");
        GetComponent<Image>().sprite = offSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectCharacter(String dinoSkin) {
        if (!skinClicked) {
            skinClicked = true;
        } else if (dinosaurSkin.Equals(dinoSkin)) {
            skinClicked = !skinClicked;
        }
        if (!dinosaurSkin.Equals("") && !dinosaurSkin.Equals(dinoSkin)) {
            Debug.Log(0);
            GameObject oldSelect = GameObject.Find("Choose" + dinosaurSkin);
            oldSelect.GetComponent<Image>().sprite = Resources.Load<Sprite>(dinosaurSkin + "/" + dinosaurSkin + "Off");
            GetComponent<Image>().sprite = onSprite;
            dinosaurSkin = dinoSkin;
        } else  if (!skinClicked) {
            Debug.Log(1);
            GetComponent<Image>().sprite = offSprite;
            dinosaurSkin = "";
        } else {
            Debug.Log(2);
            GetComponent<Image>().sprite = onSprite;
            dinosaurSkin = dinoSkin;
        } // if
        Debug.Log(skinClicked);
        
    } // characterSelect
    
}
