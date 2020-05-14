using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorShift : MonoBehaviour
{

    [SerializeField] Color lerpedColor = Color.red;
    [SerializeField] TextMeshProUGUI mainText;
    [SerializeField] int colorOrder = 0;
    
    void Update()
    {
        GetComponent<TextMeshProUGUI>().color = lerpedColor;
        if (colorOrder == 0)
        {
            lerpedColor = Color.Lerp(Color.red, Color.magenta, Mathf.PingPong(Time.time, 1));
            GetComponent<TextMeshProUGUI>().color = lerpedColor;
            colorOrder++;
        }
        else if (colorOrder == 1)
        {
            lerpedColor = Color.Lerp(Color.magenta, Color.blue, Mathf.PingPong(Time.time, 1));
            GetComponent<TextMeshProUGUI>().color = lerpedColor;
            colorOrder++;
        }
        else if (colorOrder == 2)
        {
            lerpedColor = Color.Lerp(Color.blue, Color.green, Mathf.PingPong(Time.time, 1));
            GetComponent<TextMeshProUGUI>().color = lerpedColor;
            colorOrder++;
        }
        else if (colorOrder == 3)
        {
            lerpedColor = Color.Lerp(Color.green, Color.yellow, Mathf.PingPong(Time.time, 1));
            GetComponent<TextMeshProUGUI>().color = lerpedColor;
            colorOrder++;
        }
        else if (colorOrder == 4)
        {
            lerpedColor = Color.Lerp(Color.yellow, Color.red, Mathf.PingPong(Time.time, 1));
            GetComponent<TextMeshProUGUI>().color = lerpedColor;
            colorOrder = 0;
        }
    }

}