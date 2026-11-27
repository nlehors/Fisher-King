using System.Collections.Generic;
using UnityEngine;

public class BulletParent : MonoBehaviour
{
    public WeaponParent weaponScript;
    public float lifeTime = 10f;


    protected float bulletSpeed = 1f;
    private Vector2 dirVector;


    protected Player player;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Setup();
       
    }

    // Update is called once per frame
  
    void OnTriggerEnter2D(Collider2D collision)
    {
       TriggerEnter(collision);
       
        
    }

    public virtual void Setup()
    {
        player = FindAnyObjectByType<Player>();
        Destroy(gameObject,lifeTime);
    }

    public virtual void TriggerEnter(Collider2D collision)
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
    
    // ReSharper disable Unity.PerformanceAnalysis
    public void Shoot(Transform target)
    {
        dirVector = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        dirVector = Vector2.Normalize(dirVector) * (bulletSpeed * player.GetComponent<Player>().playerStatsDictionary["playerSpeed"]);
    }

    public void Move(Transform target)
    {
        target.position += new Vector3(dirVector.x,dirVector.y,0) * Time.deltaTime;
    }
    
}
