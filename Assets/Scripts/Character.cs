using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character: MonoBehaviour
{
    public float hp { get; set; }
    public int atackPower { get; set; }
    protected int defence { get; set; }  
    protected int jumpAmount { get; set; }
    protected int speedAmount { get; set; }
}
