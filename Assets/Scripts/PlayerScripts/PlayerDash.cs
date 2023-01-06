using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : PlayerSkills
{
    private PlayerDash()
    {
        nextSkillTime = 0f;
        skillCooldown = 5f;
    }
    private float DashMultiple = 5f;
    private bool direction;
    public bool canIDash = true;
    private void Update()
    {
        Dash();
    }
    private void Dash()    //cooldown'a göre dash atan fonksiyon 
    {
        if (Input.GetKey(KeyCode.A))
            direction = false;                      //karakterin dash yönünü kontrol eder.
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
            Debug.Log(nextSkillTime-Time.time);
        }
    }
}
