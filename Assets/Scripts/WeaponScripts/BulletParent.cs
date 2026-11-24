using System.Collections.Generic;
using UnityEngine;

public class BulletParent : MonoBehaviour
{
    public WeaponParent weaponScript;
    public float lifeTime = 10f;
    
    private float bulletSpeed = 1f;
    private Vector2 dirVector;
    
    
    private Player player;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<Player>();
        Destroy(gameObject,lifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        transform.position += new Vector3(dirVector.x,dirVector.y,0) * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
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

    public void Shoot(Transform target)
    {
        dirVector = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y).normalized;
        dirVector *= bulletSpeed;
        if (transform.CompareTag("Player"))
        {
            dirVector *= player.GetComponent<Player>().playerStatsDictionary["playerSpeed"]
        }
    }
    
}
