using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishingManager : MonoBehaviour
{
    public GameObject fishingUI;
    public bool isFishing;
    public FishingController fishingController;
    
    [SerializeField] private List<FishData> fishDataList;
    public GameObject fishingReward;
    public SpriteRenderer fishingRewardSprite;
    public TMP_Text fishingRewardText;
    
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
            fishingController.QTE();
        }

        if (isFishing==false)
        {
            fishingUI.SetActive(false);
            fishingController.Restart();
        }
    }
}