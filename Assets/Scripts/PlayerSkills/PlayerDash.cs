using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDash : PlayerSkills
{
    public TMP_Text dashCooldown;
    private PlayerDash()
    {
        nextSkillTime = 0f;
        skillCooldown = 5f;
    }
    private float DashMultiple = 10f;
    private bool direction;
    public bool canIDash = true;
    private void Update()
    {
        Dash();
    }
    private void Dash()    //cooldown'a g�re dash atan fonksiyon 
    {
        if (Input.GetKey(KeyCode.A))
            direction = false;                      //karakterin dash y�n�n� kontrol eder.
        else if (Input.GetKey(KeyCode.D))
            direction = true;
        if (Time.time >= nextSkillTime)
        {
            if (Input.GetKeyDown(KeyCode.F) && canIDash)
            {
                if(direction)
                    transform.position += new Vector3(DashMultiple, 0);
                else
                    transform.position += new Vector3(-DashMultiple, 0);
                nextSkillTime = Time.time + skillCooldown;
            }
        }
        else
        {
            dashCooldown.text =Mathf.RoundToInt((nextSkillTime - Time.time)).ToString();
        }
    }
}
