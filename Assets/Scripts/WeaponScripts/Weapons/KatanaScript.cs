using System;
using Unity.Cinemachine;
using UnityEngine;

public class KatanaScript : WeaponParent
{
    public float slashDistance;
    public float slashSpeed;
    [SerializeField] private GameObject parent;

    private float tempDistance;
    private Vector3 tempPos;
    
    private void Update()
    {
        //Debug.Log(collider.enabled);
        if (timer <= 0)
        {
            Slash();
        }
        timer -= Time.deltaTime;
        
        if (isActive == false)
        {
            GetNearestEnnemy();
            Orientate(nearestEnnemy.transform);
        }
        
    }

    public override void Setup()
    {
        base.Setup();
        tempDistance = slashDistance;
        tempPos = transform.localPosition;
    }

    private void Slash()
    {
        ActivateHitbox();
        if (slashDistance > 0)
        {
            Vector3 temp = transform.localPosition;
            temp.x -= slashSpeed * Time.deltaTime;
            transform.localPosition = temp;
            slashDistance -= slashSpeed * Time.deltaTime;
            Debug.Log(slashDistance);
        }
        else
        {
            slashDistance = tempDistance;
            transform.localPosition = tempPos;
            timer = cooldown;
            DesactivateHitbox();
        }
    }
    
}
