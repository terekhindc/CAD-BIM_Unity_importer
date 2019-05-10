using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextData : MonoBehaviour
{

    static Text textUI;

    // Start is called before the first frame update
    void Start()
    {
        textUI = GetComponent<Text>();
    }

    // Update is called once per frame
    static public void SetText(string text)
    {
        textUI.text = text;
    }
}
