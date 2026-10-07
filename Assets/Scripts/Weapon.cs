using Unity.VisualScripting;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField]public float damage = 10f;
    [SerializeField]public int angleRotation = 45;
    [SerializeField]public float couldown = 1f;
    [SerializeField]public bool canRotate;
    [SerializeField]public bool canShoot;

    [SerializeField] public GameObject prefabToGenerate;
    
    private Transform pos;
    private Quaternion temp;
    private float timer;
    
    

    void Start()
    {
        pos = GetComponent<Transform>();
        temp = pos.rotation;
        timer = couldown;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (canRotate)
            {
                Rotation(angleRotation);
            }
            CreateProjectile();
            
            timer = couldown;
        }

        if (pos.rotation.eulerAngles.z > angleRotation)
        {
            pos.rotation = temp;
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    { 
        Ennemi ennemiScript = collision.GetComponent<Ennemi>();
        Damage(ennemiScript);
    }
    
    
    
    private void Rotation(float angle)
    { 
        pos.Rotate(pos.forward,angle); 
    }

    private void Damage(Ennemi target)
    {
        target.ennemiLife -= damage;
    }

    private void CreateProjectile()
    {
        Instantiate(prefabToGenerate);
    }
}
