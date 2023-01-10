using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character: MonoBehaviour
{
    public float hp { get; set; }
    public int atackPower { get; set; }
    public int jumpAmount { get; set; }
    public int speedAmount { get; set; }
}