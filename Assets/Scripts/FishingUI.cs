using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishingUI : MonoBehaviour
{
    public GameObject fishingUI;
    
    void Start()
    {
    }

    private void Awake()
    {
        fishingUI.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            fishingUI.SetActive(true);
        }

        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            fishingUI.SetActive(false);
        }
    }
}
