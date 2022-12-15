using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Image image;
    void Start()
    {
        image.gameObject.SetActive(false);
    }

    public void Open()
    {
        image.gameObject.SetActive(true);
    }
    public void Close()
    {
        image.gameObject.SetActive(false);
    }
}
