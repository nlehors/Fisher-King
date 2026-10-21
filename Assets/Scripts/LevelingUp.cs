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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = GetComponent<Player>();
    }
    
    // Update is called once per frame
    void Update()
    {
        xpBar.fillAmount = xpCount / xpToLevelUp;
        UnityEngine.Debug.Log(xpCount / xpToLevelUp);
        if (canUpgrade)
        {
            Time.timeScale = 0;
            uiUpgrade.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            uiUpgrade.SetActive(false);
        }
    }




}
