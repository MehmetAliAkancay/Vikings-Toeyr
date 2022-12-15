using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetSmall : PlayerSkills
{
    private PlayerGetSmall()
    {
        nextSkillTime = 0;
        skillCooldown = 10;
    }
    private Player player;
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
        if(Time.time>=nextSkillTime)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                StartCoroutine(GetSmalls());
                nextSkillTime = Time.time+skillCooldown;
            }
        }
    }
    IEnumerator GetSmalls()
    {
        transform.localScale = new Vector3(3, 3);
        player.atackPower = 10;
        yield return new WaitForSecondsRealtime(5f);
        player.atackPower = 30;
        transform.localScale = new Vector3(5, 5);
    }
}