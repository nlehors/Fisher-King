using Unity.VisualScripting;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField]public float damage = 10f;
    [SerializeField]public float angleRotation = 0;
    [SerializeField]public float couldown = 10f;
    [SerializeField]public bool canRotate;
    [SerializeField]public bool canShoot;

    [SerializeField] public GameObject prefabToGenerate;
    
    private Transform pos;
    private Quaternion temp;
    private float timer;
    private Player playerScript;
    private float totalDamage;

    void Start()
    {
        playerScript = GetComponentInParent<Player>();
        pos = GetComponent<Transform>();
        temp = pos.rotation;
        timer = couldown;
    }
    // Update is called once per frame
    void Update()
    {
        totalDamage = damage + playerScript.baseDamage;
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (canShoot)
            {
                CreateProjectile();
            }
            
            timer = couldown;
        }
        
        if (canRotate)
        {
            Rotation(angleRotation * Time.deltaTime);
        }
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
    
    
    
    private void Rotation(float angle)
    { 
        pos.Rotate(pos.forward,angle); 
    }

    public void Damage(Ennemi target)
    {
        target.ennemiLife -= totalDamage;
    }

    private void CreateProjectile()
    {
        GameObject lastBullet = Instantiate(prefabToGenerate, transform.position, transform.rotation);
    }
}
