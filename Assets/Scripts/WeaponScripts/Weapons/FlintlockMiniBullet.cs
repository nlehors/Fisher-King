using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlintlockMiniBullet : BulletParent
{
    private void FixedUpdate()
    {
        transform.localPosition += new Vector3(0, 1, 0) * (bulletSpeed * player.GetComponent<Player>().playerStatsDictionary["playerSpeed"]) * Time.fixedDeltaTime;
    }

    public override void TriggerEnter(Collider2D collision)
    {
        // à modif après manger pour que ça déclenche le hasSplit une fois l'ennemi touché puis que ça détruise
            if (collision.CompareTag("Ennemi"))
            {
                Ennemi ennemiScript = collision.GetComponent<Ennemi>();
        
                weaponScript.Damage(ennemiScript);
        
                if (ennemiScript.ennemiLife <= 0)
                {
                    ennemiScript.Death();
                }
                Destroy(gameObject);
            }
    }
    
}
