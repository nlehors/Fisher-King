using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishingUI : MonoBehaviour
{
    public GameObject fishingUI;
    public bool isFishing;
    public FishingController fishingController;
    
    void Start()
    {
        isFishing = false;
    }

    void Update()
    {
        if (isFishing == true)
        {
            isFishing = true;
            fishingUI.SetActive(true);
        }

        if (isFishing==false)
        {
            fishingUI.SetActive(false);
            fishingController.Restart();
        }
    }
}