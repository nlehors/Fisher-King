using UnityEngine;

public class FlintlockScript : WeaponShooterParent
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   private void FixedUpdate()
    {
        if (tempBulletRound > 0)
        {
            timer = cooldown;
            if (!isActive)
            {
                isActive = true;
                GetNearestEnnemy();
                if (nearestEnnemy != null)
                {
                    CreateProjectile();
                    lastBulletShot.GetComponent<BulletParent>().Shoot(nearestEnnemy.transform);
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
}
