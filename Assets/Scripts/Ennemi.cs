using System;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public float ennemiSpeed;
    public float ennemiLife;
    public int contactDamage = 5;
    
    public GameObject player;
    
    void Start()
    {
        
    }

    void Update()
    {
        GoThere(player.transform.position,ennemiSpeed);
        Health();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player playerScript = collision.GetComponent<Player>();
        playerScript.healthPoint -= contactDamage;
    }


    void GoThere(Vector3 target, float speed)
    {
        Vector2 vector = new Vector2(target.x - transform.position.x, target.y - transform.position.y);

        vector = Vector2.Normalize(vector) * speed;

        transform.position += new Vector3(vector.x, vector.y, 0);
    }

    void Health()
    {
        if (ennemiLife <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}