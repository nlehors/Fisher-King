using UnityEngine;

public class FlintlockScript : WeaponShooterParent
{
    public bool isSecondGun = false;
    public bool canSplitBullet = false;
    private GameObject secondNearestEnnemy;

    private bool hasShot = false;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   private void FixedUpdate()
    {
        
        if (tempBulletRound > 0)
        {
            timer = cooldown;
            if (!isActive)
            {
                isActive = true;
                if (!isSecondGun)
                {
                    GetNearestEnnemy();
                    if (nearestEnnemy != null)
                    {
                        Orientate(nearestEnnemy.transform);
                        CreateProjectile();
                        if (canSplitBullet)
                        {
                            lastBulletShot.GetComponentInChildren<FlintlockBullet>().canSplit = true;
                        }
                        lastBulletShot.GetComponentInChildren<BulletParent>().Shoot(nearestEnnemy.transform);
                    }
                }
                else
                {
                    GetSecondNearestEnnemy();
                    if (secondNearestEnnemy != null)
                    {
                        Orientate(secondNearestEnnemy.transform);
                        CreateProjectile();
                        if (canSplitBullet)
                        {
                            lastBulletShot.GetComponentInChildren<FlintlockBullet>().canSplit = true;
                        }
                        lastBulletShot.GetComponentInChildren<BulletParent>().Shoot(secondNearestEnnemy.transform);
                    }
                }
            }

        
            
            tempBulletRound --;
        }
        else
        {
            if (isActive)
            {
                isActive = false;
                //reset
            }
            
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            tempBulletRound = bulletRound;
        }
        
    }


    private void GetSecondNearestEnnemy()
    {
        GetNearestEnnemy();
        float secondDistanceMinPlayer = detectionDistance;
        foreach (GameObject ennemi in gameManager.ennemiList)
        { 
            if (Vector3.Distance(ennemi.transform.position,playerScript.transform.position) < secondDistanceMinPlayer && ennemi != nearestEnnemy)
            {
                secondDistanceMinPlayer = Vector3.Distance(ennemi.transform.position, playerScript.transform.position);
              
                secondNearestEnnemy = ennemi;
            }
        }
    }
   
   
   
}
