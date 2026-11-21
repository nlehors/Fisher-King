using System;
using Unity.Cinemachine;
using UnityEngine;

public class CutlassScript : WeaponParent
{
    public float rotationSpeed;
    public float stabDistance = 0;
    public float stabDuration;
    public bool isStabbing = false;
    
    [SerializeField] private bool canStab;
    [SerializeField] private GameObject parent;
    

    private float tempStabDuration;
    private Vector3 tempPos;
    private Vector3 tempParentAngle;
    
    
    private void FixedUpdate()
    {
        if ( tempDuration > 0)
        {
            timer = cooldown;
            if (!isActive)
            {
                ActivateHitbox();
            }
            Rotation(rotationSpeed * Time.deltaTime);
            tempDuration -= Time.deltaTime;
        }
        else
        {
            if (isActive)
            {
                DesactivateHitbox();
                parent.transform.eulerAngles = tempParentAngle;
            }
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            tempDuration = durationEffect;
        }

        if (canStab)
        {
            if (isStabbing)
            {
                if (tempStabDuration == 0)
                {
                    Stab();
                    Debug.Log("je stab !");
                }
                tempStabDuration += Time.fixedDeltaTime;
                if (tempStabDuration >= stabDuration)
                {
                    transform.localPosition = tempPos;
                    isStabbing = false;
                    tempStabDuration = 0;
                }
            }
        }
        else if (!isStabbing && canStab)
        {
            tempStabDuration = stabDuration;
            transform.localPosition = tempPos;
        }
        
    }

    public override void Setup()
    {
        base.Setup();
        tempStabDuration = 0;
        tempPos = transform.localPosition;
        tempParentAngle = parent.transform.eulerAngles;
    }
    
    
    
    private void Rotation(float angle)
    { 
        parent.transform.Rotate(parent.transform.forward,angle); 
    }

    private void Stab()
    {
        transform.localPosition += new Vector3(0,stabDistance,0);
    }
    
}
