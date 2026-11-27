using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlintlockBullet : BulletParent
{
    [SerializeField]public bool canSplit = false;
    [SerializeField]public List<GameObject> miniBulletList = new List<GameObject>();

    private bool hasSplit = false;

    private void FixedUpdate()
    {
        if (canSplit)
        {
            if (!hasSplit)
            {
                Move(transform);
            }
            else
            {
                this.GetComponent<SpriteRenderer>().enabled = false;
                this.GetComponent<Collider2D>().enabled = false;
                
                foreach (GameObject minibullet in miniBulletList)
                {
                    minibullet.SetActive(true);
                    minibullet.GetComponentInChildren<FlintlockMiniBullet>().weaponScript = this.weaponScript;
                }
            }
        }
        else
        {
            Move(transform);
        }
    }

    public override void TriggerEnter(Collider2D collision)
    {
        // à modif après manger pour que ça déclenche le hasSplit une fois l'ennemi touché puis que ça détruise

        if (!canSplit)
        {
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
        else
        {
            if (!hasSplit)
            {
                if (collision.CompareTag("Ennemi"))
                {
                    Ennemi ennemiScript = collision.GetComponent<Ennemi>();
        
                    weaponScript.Damage(ennemiScript);
        
                    if (ennemiScript.ennemiLife <= 0)
                    {
                        ennemiScript.Death();
                    }

                    hasSplit = true;
                }
            }
            else
            {
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
        
        
    }
    
}
