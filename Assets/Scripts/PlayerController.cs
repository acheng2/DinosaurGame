using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float jumpPower = 15;

    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private RuntimeAnimatorController testAnim;

    private Rigidbody2D rb;
    public Animator animator;
    [SerializeField]
    public String dinosaurSkin;

    private Vector2 duckColliderOffset;
    private Vector2 duckColliderSize;

    private Vector2 runColliderOffset;
    private Vector2 runColliderSize;

    private int animationState; // 0 for run, 1 for duck
    private int colliderState; // 0 for run, 1 for duck

    // Start is called before the first frame update
    private void Start() {
        rb = player.GetComponent<Rigidbody2D>();
        //player.GetComponent<Animator>().runtimeAnimatorController = testAnim;
        //animator = player.GetComponent<Animator>();
        
        dinosaurSkin = "";

        //duckColliderOffset = new Vector2(CharacterStats.stats[dinosaurSkin + "DuckColliderOffsetX"], CharacterStats.stats[dinosaurSkin + "DuckColliderOffsetY"]);
        //duckColliderSize = new Vector2(CharacterStats.stats[dinosaurSkin + "DuckColliderSizeX"], CharacterStats.stats[dinosaurSkin + "DuckColliderSizeY"]);
        //runColliderOffset = new Vector2(CharacterStats.stats[dinosaurSkin + "RunColliderOffsetX"], CharacterStats.stats[dinosaurSkin + "RunColliderOffsetY"]);
        //runColliderSize = new Vector2(CharacterStats.stats[dinosaurSkin + "RunColliderSizeX"], CharacterStats.stats[dinosaurSkin + "RunColliderSizeY"]);

        //player.GetComponent<BoxCollider2D>().offset = runColliderOffset;
        //player.GetComponent<BoxCollider2D>().size = runColliderSize;
    } // Start

    // Update is called once per frame
    private void Update() {
        if (GameController.gamePlaying) {
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                if (animationState == 0) {
                    Jump();
                } // if
            } // if jump

            if (Input.GetKeyDown(KeyCode.Space)) {
                Attack();
            } // if attack

            if (Input.GetKey(KeyCode.DownArrow)) {
                Duck();
            } // if duck

            if (Input.GetKeyUp(KeyCode.DownArrow)) {
                if (animationState == 1) {
                    animationState = 0;
                } // if
                if (colliderState == 1) {
                    colliderState = 0;
                    player.GetComponent<BoxCollider2D>().offset = runColliderOffset;
                    player.GetComponent<BoxCollider2D>().size = runColliderSize;
                } // if
            } // if finish duck
        } // if game playing
    } // Update

    private void Jump() {
        if (Math.Abs(rb.velocity.y) < 0.001) {
            animator.SetTrigger("Jump");
            rb.velocity = new Vector2(0, jumpPower);
        } // if
    } // Jump

    private void Attack() {
        animator.SetTrigger("Attack");
    } // Attack

    private void Duck() {
        if (Math.Abs(rb.velocity.y) < 0.001) {
            animator.SetTrigger("Duck");
            if (animationState != 1) {
                animationState = 1;
            } // if
            if (colliderState != 1) {
                colliderState = 1;
                player.GetComponent<BoxCollider2D>().offset = duckColliderOffset;
                player.GetComponent<BoxCollider2D>().size = duckColliderSize;
            } // if
        } // if
    } // Duck

    public void SetCharacter(String dinoSkin) {
        dinosaurSkin = char.ToLower(dinoSkin[0]) + dinoSkin[1..];
        player.GetComponent<Animator>().runtimeAnimatorController = GameObject.Find("Choose" + dinoSkin).GetComponent<CharacterSelect>().anim;
        animator = player.GetComponent<Animator>();

        Debug.Log(dinosaurSkin);

        duckColliderOffset = new Vector2(CharacterStats.stats[dinosaurSkin + "DuckColliderOffsetX"], CharacterStats.stats[dinosaurSkin + "DuckColliderOffsetY"]);
        duckColliderSize = new Vector2(CharacterStats.stats[dinosaurSkin + "DuckColliderSizeX"], CharacterStats.stats[dinosaurSkin + "DuckColliderSizeY"]);
        runColliderOffset = new Vector2(CharacterStats.stats[dinosaurSkin + "RunColliderOffsetX"], CharacterStats.stats[dinosaurSkin + "RunColliderOffsetY"]);
        runColliderSize = new Vector2(CharacterStats.stats[dinosaurSkin + "RunColliderSizeX"], CharacterStats.stats[dinosaurSkin + "RunColliderSizeY"]);

        player.GetComponent<BoxCollider2D>().offset = runColliderOffset;
        player.GetComponent<BoxCollider2D>().size = runColliderSize;

        if (dinosaurSkin.Equals("duck")) {
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
    } // SetCharacter
} // PlayerController
