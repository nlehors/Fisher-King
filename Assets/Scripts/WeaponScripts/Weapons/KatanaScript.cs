using System;
using Unity.Cinemachine;
using UnityEngine;

public class KatanaScript : WeaponParent
{
    public float slashSpeed;
    public float slashDistance;
    
    private Vector3 tempPos;
    private float tempDis;
    private Vector3 originPos;

    private void FixedUpdate()
    {
        Debug.Log(tempDis);
        if (tempDuration > 0)
        {
            timer = cooldown;
            if (!isActive)
            {
                ActivateHitbox();
                GetNearestEnnemy();
                if (nearestEnnemy != null)
                {
                    //Orientate(nearestEnnemy.transform);
                }
            }
            Slash();
            tempDuration -= Time.deltaTime;
        }
        else
        {
            if (isActive)
            {
                DesactivateHitbox();
                //reset
                transform.localPosition = originPos;
                tempDis = 0;

            }
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            tempDuration = durationEffect;
        }
    }

    //private void Update()
    //{
    //    //Debug.Log(collider.enabled);
    //    if (timer <= 0)
    //    {
    //        Slash();
    //    }
    //    timer -= Time.deltaTime;
    //    
    //    if (isActive == false)
    //    {
    //        GetNearestEnnemy();
    //        Orientate(nearestEnnemy.transform);
    //    }
    //    
    //}

    public override void Setup()
    {
        base.Setup();
        tempPos = transform.localPosition;
        originPos = transform.localPosition;
        tempDis = 0;

    }

    private void Slash()
    {
        if (tempDis <= slashDistance)
        {
            tempPos = transform.localPosition;
            tempPos.x -= slashSpeed * Time.deltaTime;
            transform.localPosition = tempPos;
            tempDis += slashSpeed * Time.deltaTime;
        }
    }
    
}
