using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{
    private void OnMouseEnter()
    {
        //transform.GetComponent<Image>().color = Color.HSVToRGB(.1f,.1f,.8f);
        Color color = transform.GetComponent<Image>().color;
        color.a = .5f;
        transform.GetComponent<Image>().color = color;
    }
    private void OnMouseExit()
    {
        transform.GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }
}
