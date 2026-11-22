using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

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

    public GameObject gotAfishUi;

    public TMP_Text upgradeText;
    int randomUpgrade;

    private void Start()
    {
        gotAfishUi.SetActive(false);
    }

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

    public void FishInterfaceActivate()
    {
        Time.timeScale = 0;
        gotAfishUi.SetActive(true);
    }
    
    public void FishInterfaceDeactivate()
    {
        Time.timeScale = 1;
        gotAfishUi.SetActive(false);
    }

    public void NewFish()
    {
        randomUpgrade = Random.Range(0, 12);//faudrat remplacer par la collection de fish quand on l'aura
        
        upgradeText.text = player.uprgradeButtonTextList[randomUpgrade];
        player.playerStatsDictionary[player.upgradeNames[randomUpgrade]]++;
    }
}