using System;
using Unity.Cinemachine;
using UnityEngine;

public class KatanaScript : WeaponParent
{
    public float slashSpeed;
    public float slashDistance;
    public bool isBackSword;
    public bool canBackNForth;

    private bool hasGoBack = false;
    private Vector3 tempPos;
    private float tempDis;
    private float tempDisBack;
    private Vector3 originPos;
    

    private void FixedUpdate()
    {
        //Debug.Log("");
        if (tempDuration > 0)
        {
            timer = cooldown;
            if (!isActive)
            {
                ActivateHitbox();
                GetNearestEnnemy();
                if (nearestEnnemy != null)
                {
                    Orientate(nearestEnnemy.transform);
                }
            }
            Slash();
            if (canBackNForth && tempDis > slashDistance)
            {
                BackSlash();
            }
            tempDuration -= Time.deltaTime;
        }
        else
        {
            if (isActive)
            {
                DesactivateHitbox();
                //reset
                transform.localPosition = originPos;
                parent.transform.localEulerAngles = new Vector3();
                tempDis = 0;
                tempDisBack = 0;
            }
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            tempDuration = durationEffect;
        }
    }
    
    public override void Setup()
    {
        base.Setup();
        tempPos = transform.localPosition;
        originPos = transform.localPosition;
        tempDis = 0;
        tempDisBack = 0;

    }

    private void Slash()
    {
        if (tempDis <= slashDistance)
        {
            if (!isBackSword)
            {
                tempPos = transform.localPosition;
                tempPos.x -= slashSpeed * Time.deltaTime;
                transform.localPosition = tempPos;
            }
            else
            {
                tempPos = transform.localPosition;
                tempPos.x += slashSpeed * Time.deltaTime;
                transform.localPosition = tempPos;
            }
            tempDis += slashSpeed * Time.deltaTime;
        }
    }

    private void BackSlash()
    {
        if (tempDisBack <= slashDistance)
        {
            if (!isBackSword)
            {
                tempPos = transform.localPosition;
                tempPos.x += slashSpeed * Time.deltaTime;
                transform.localPosition = tempPos;
            }
            else
            {
                tempPos = transform.localPosition;
                tempPos.x -= slashSpeed * Time.deltaTime;
                transform.localPosition = tempPos;
            }
            tempDisBack += slashSpeed * Time.deltaTime;
        }
    }
    
}
