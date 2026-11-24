using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;


public class WeaponShooterParent : WeaponParent
{
    
    [SerializeField] public GameObject bulletPrefab;

    public float bulletRound; //nb bullet

    protected float tempBulletRound;
    protected GameObject lastBulletShot;
    
    
    public override void Setup()
    {
        base.Setup();
        sprite.enabled = true;
        tempBulletRound = bulletRound;
    }
    
    
    
    // fonction globales :
    public void CreateProjectile()
    {
        lastBulletShot = Instantiate(bulletPrefab, transform.position, transform.rotation);
        lastBulletShot.GetComponent<BulletParent>().weaponScript = this;
    }
}
