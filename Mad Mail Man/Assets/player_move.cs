using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    //public int playerSpeed = 10;
    //public bool facingRight = true;
    //public int playerJumpPower = 1250;
    private Vector2 moveDirection = Vector2.zero;
    public float gravity = 20.0F;
    public float speed = 6.0F;
    //Transform playerGraphics;
    // Use this for initialization
    /*void Start () {}*/

    // Update is called once per frame
    void Update()
    {
        //PlayerMove();
        CharacterController player = GetComponent<CharacterController>();
        //moveDirection.y -= gravity * Time.deltaTime;
        moveDirection.x = speed;
        player.Move(moveDirection * Time.deltaTime/3);
       /* playerGraphics = transform.Find("Graphics");
        if (playerGraphics == null)
        {
            Debug.LogError("no arm bruh");
        }
        */
    }
    /*void PlayerMove()
    {//controls animation. etc.}
    */
}

