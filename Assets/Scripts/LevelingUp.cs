using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class LevelingUp : MonoBehaviour
{
    public int level = 0;
    public float xpToLevelUp = 10;
    public float xpCount = 0;

    [SerializeField] private GameObject uiUpgrade;
    [SerializeField] private Image xpBar;
    
    private Player playerScript;
    private bool canUpgrade = false;

    int randomButton1;
    int randomButton2;
    int randomButton3;

    public TMP_Text button1;
    public TMP_Text button2;
    public TMP_Text button3;
    
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

    void Start()
    {
        playerScript = GetComponent<Player>();
        uiUpgrade.SetActive(false);
    }
    
    void Update()
    {
        xpBar.fillAmount = xpCount / xpToLevelUp;

        if (canUpgrade)
        {
            canUpgrade = false;

            randomButton1 = Random.Range(0, 12);
            randomButton2 = Random.Range(0, 12);
            while (randomButton1 == randomButton2)
            {
                randomButton2 = Random.Range(0, 12);
            }
            randomButton3 = Random.Range(0, 12);
            while (randomButton1 == randomButton3 | randomButton2 == randomButton3)
            {
                randomButton2 = Random.Range(0, 12);
            }
            
            button1.text = playerScript.uprgradeButtonTextList[randomButton1];
            button2.text = playerScript.uprgradeButtonTextList[randomButton2];
            button3.text = playerScript.uprgradeButtonTextList[randomButton3];
            
            UpgradeMenuActivation();
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
        
        playerScript.playerStatsDictionary[playerScript.upgradeNames[randomButton1]]++;
    }
    
    public void Button2()
    {
        UpgradeMenuDesactivation();
        
        playerScript.playerStatsDictionary[playerScript.upgradeNames[randomButton2]]++;
    }
    
    public void Button3()
    {
        UpgradeMenuDesactivation();
        
        playerScript.playerStatsDictionary[playerScript.upgradeNames[randomButton3]]++;
    }
}


//So many times we rise and fall
//After awhile it's good and all together
//Together
//So many times we rise and fall
//Wondering if we'll find it all together
//Together
//
//Baby, but all the nights and days we spent together
//(Together)
//It's so easy to forget how to surrender
//But nothing's ever stopped
//Music and lines
//Rhythm and melodies
//
//(Take us to the top)
//So many nights
//So many memories
//Music and lines
//Rhythm and melodies
//(But nothing's ever stopped)
//So many nights
//So many memories
//
//So many times we rise and fall
//After awhile it's good and all together
//Together
//So many ways to lose it all
//Livin' with future, we won't have to give up
//Together
//Baby, but all the nights and days we spent together
//Together
//
//It's so easy to forget how to surrender
//But nothing's ever stopped
//Music and lines
//Rhythm and melodies
//(Take us to the top)
//So many nights
//So many memories
//Music and lines
//Rhythm and melodies
//(But nothing's ever stopped)
//
//So many nights
//So many memories
//But nothing's ever stopped
//Take us to the top
//But nothing's ever stopped
//Music and lines
//Rhythm and melodies
//(Take us to the top)
//
//So many nights
//So many memories
//Music and lines
//Rhythm and melodies
//(But nothing's ever stopped)
//So many nights
//So many memories
//Music and lines
//Rhythm and melodies
//(Take us to the top)
//
//So many nights
//So many memories
//Music and lines
//Rhythm and melodies
//(But nothing's ever stopped)
//So many nights
//So many memories