using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;


public class WeaponParent : MonoBehaviour
{
    [SerializeField]public float damage = 10f;
    [SerializeField]public float cooldown = 10f;
    [SerializeField]public float durationEffect = 3;
    [SerializeField]protected float timer;
    [SerializeField] public float detectionDistance;
    
    
    protected float tempDuration;
    protected float totalDamage;
    
    [HideInInspector]public bool isActive = false;
    
    [SerializeField]protected GameObject parent;
    
    protected Player playerScript;
    protected List<GameObject> ennemisList;
    protected GameObject nearestEnnemy;
    protected Collider2D collider;
    protected SpriteRenderer sprite;
    [HideInInspector]public GameManager gameManager;
    

    
    void Start()
    {
        Setup();
        
        GetNearestEnnemy();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.CompareTag("Ennemi"))
        {
            Ennemi ennemiScript = collision.GetComponent<Ennemi>();
            Damage(ennemiScript);
            if (ennemiScript.ennemiLife <= 0)
            {
                ennemiScript.Death();
            }
        }
    }
    
    // fonction globales :
    public virtual void Setup()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        playerScript = GetComponentInParent<Player>();
        timer = cooldown;
        tempDuration = durationEffect;
        collider = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        collider.enabled = false;
        sprite.enabled = false;
    }
    
    
    
    public void GetNearestEnnemy()
    {
        //jpp de ce code de con
        float distanceMinPlayer = detectionDistance;
        foreach (GameObject ennemi in gameManager.ennemiList)
        { 
            
            if (Vector3.Distance(ennemi.transform.position,playerScript.transform.position) < distanceMinPlayer)
            {
                distanceMinPlayer = Vector3.Distance(ennemi.transform.position, playerScript.transform.position);
              
                nearestEnnemy = ennemi;
            }
        }
    }
    
    public void Damage(Ennemi target)
    {
        totalDamage = damage + playerScript.baseDamage;
        target.ennemiLife -= totalDamage;
    }
    
    public void Orientate(Transform target)
    {
        Vector2 dirNearestEnnemy = target.position - parent.transform.position;
        if (dirNearestEnnemy != Vector2.zero)
        {
            parent.transform.up = dirNearestEnnemy;
        }
    }
    

    public void ActivateHitbox()
    {
        isActive = true;
        collider.enabled = true;
        sprite.enabled = true;
    }
    
    public void DesactivateHitbox()
    {
        isActive = false;
        collider.enabled = false;
        sprite.enabled = false;
    }
}
