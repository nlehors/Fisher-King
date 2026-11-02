using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishingManager : MonoBehaviour
{
    public GameObject fishingUI;
    public bool isnoyFishing;
    public FishingController fishingController;
    
    [SerializeField] private List<FishData> fishDataList;
    //public GameObject fishingReward;
    //public SpriteRenderer fishingRewardSprite;
    //public TMP_Text fishingRewardText;

    public Player player;

    void Update()
    {
        fishingUI.SetActive(player.isOnFishingZone);
        if (player.isOnFishingZone)
        {
            fishingController.QTE();
        }
        else
        {
            fishingController.Restart();
        }
    }
}