using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollingBackground : MonoBehaviour
{
    Material mat;
    float distance;
    [SerializeField]
    private float speed = 0.2f;

    // Start is called before the first frame update
    void Start() {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update() {
        if (!SceneManager.GetActiveScene().name.Equals("GameScene") || GameController.gamePlaying) {
            distance += Time.deltaTime * speed;
            mat.SetTextureOffset("_MainTex", Vector2.right * distance);
        }
    } // Update
}
