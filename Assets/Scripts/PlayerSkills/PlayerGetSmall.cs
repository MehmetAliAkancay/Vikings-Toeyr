using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetSmall : MonoBehaviour
{
    private Player player;
    public bool canIGrow;
    public bool headCheck=false;
    private int getSmallSpeed=2;
    private int getSmallAttackPower = 20;
    private int getSmallJump = 2;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {
        GetSmall();
    }
    private void GetSmall()
    {
       if(Input.GetKeyDown(KeyCode.C) && !canIGrow)
       {
            Smaller();
       }
       else if(Input.GetKeyDown(KeyCode.C) && canIGrow && !headCheck)
       {
            GrowUp();
       }
    }
    private void Smaller()
    {
        transform.localScale = new Vector3(3, 3);
        player.atackPower -=getSmallAttackPower;
        player.jumpAmount -=getSmallJump;
        player.speedAmount += getSmallSpeed;
        canIGrow = true;
    }
    private void GrowUp()
    {
        player.atackPower += getSmallAttackPower;
        player.jumpAmount += getSmallJump;
        player.speedAmount -= getSmallSpeed;
        transform.localScale = new Vector3(5, 5);
        canIGrow = false;
    }
}