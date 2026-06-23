using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class unicodeTest : MonoBehaviour
{
    public Text tmptest;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tmptest.text = "\u2614";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
