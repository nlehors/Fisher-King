using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelingUp : MonoBehaviour
{
    public int level = 0;
    public float xpToLevelUp = 10;
    public float xpCount = 0;

    [SerializeField] private GameObject uiUpgrade;
    [SerializeField] private Image xpBar;
    
    private Player playerScript;
    private bool canUpgrade = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Xp"))
        {
            Destroy(other.gameObject);
            xpCount++;
            if (xpCount >= xpToLevelUp)
            {
                level++;
                xpCount -= xpToLevelUp ;
                canUpgrade = true;
            }
        }
    }

    public void UpgradeSpeed()
    {
        playerScript.playerSpeed ++;
        canUpgrade = false;
    }

    void Start()
    {
        playerScript = GetComponent<Player>();
        uiUpgrade.SetActive(false);
    }
    
    void Update()
    {
        xpBar.fillAmount = xpCount / xpToLevelUp;
        
        //if (canUpgrade)
        //{
        //    Time.timeScale = 0;
        //    uiUpgrade.SetActive(true);
        //}
        //else
        //{
        //    Time.timeScale = 1;
        //    uiUpgrade.SetActive(false);
        //}

        if (canUpgrade)
        {
            UpgradeMenuActivation();
            canUpgrade = false;
        }
    }

    void UpgradeMenuActivation()
    {
        Time.timeScale = 0;
        uiUpgrade.SetActive(true);
    }

    void UpgradeMenuDesactivation()
    {
        Time.timeScale = 1;
        uiUpgrade.SetActive(false);
    }
    
    public void Button1()
    {
        UpgradeMenuDesactivation();
        UpgradeSpeed();
    }
    
    public void Button2()
    {
        UpgradeMenuDesactivation();
        UpgradeSpeed();
    }
    
    public void Button3()
    {
        UpgradeMenuDesactivation();
        UpgradeSpeed();
    }
}
