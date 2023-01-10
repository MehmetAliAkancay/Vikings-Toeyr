using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerRollBack : PlayerSkills
{
    private Vector2 clonePosition;
    private bool amIClone;

    public TMP_Text rollBackCooldown;
    public PlayerRollBack()
    {
        nextSkillTime = 0f;
        skillCooldown = 5f;
    }
    private void Update()
    {
        RollBack();
    }
    private void RollBack()
    {
        if(Time.time>=nextSkillTime)
        {
            if (Input.GetKey(KeyCode.T) && !amIClone)
            {
                clonePosition = transform.position;
                amIClone = true;
                nextSkillTime = Time.time + skillCooldown;
            }
            else if (Input.GetKey(KeyCode.R) && amIClone)
            {
                transform.position = clonePosition;
                amIClone = false;
            }
        }
        else
        {
            rollBackCooldown.text = Mathf.RoundToInt((nextSkillTime - Time.time)).ToString();
        }
    }
}
