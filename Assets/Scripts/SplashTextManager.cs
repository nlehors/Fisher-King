using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SplashTextManager : MonoBehaviour
{
    [SerializeField] TMP_Text splashText;

    [SerializeField] List<string> splashTextList = new List<string>();
    
    void Start()
    {
        if (splashTextList.Count>0)
        {
            splashText.text = splashTextList[Random.Range(0, splashTextList.Count)];
        }
    }

    void Update()
    {
        
    }
}
