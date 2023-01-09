using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public TMP_Text attackText;
    public TMP_Text speedAmount;
    public TMP_Text healthText;
    private void Update()
    {
        healthText.text = FindObjectOfType<Player>().hp.ToString();
        attackText.text = FindObjectOfType<Player>().atackPower.ToString();
        speedAmount.text = FindObjectOfType<Player>().speedAmount.ToString();
    }
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
