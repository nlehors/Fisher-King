using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishingController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public RectTransform safeZone;
    public float moveSpeed = 100f;

    private float direction = 1f;
    private RectTransform pointerTransform;
    private Vector3 targetPosition;
    private Vector3 scaleChange;
    
    void Start()
    {
        pointerTransform = GetComponent<RectTransform>();
        targetPosition = pointB.position;
    }

    private void Awake()
    {
        scaleChange = new Vector3(-0.35f,0,0);
    }

    void Update()
    {
        QTE();
    }
    
    void QTE ()
    {
        
        pointerTransform.position = Vector3.MoveTowards(pointerTransform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(pointerTransform.position, pointA.position) < 0.1f) 
        {
            targetPosition = pointB.position;
            direction = -1f;
        }
        else if (Vector3.Distance(pointerTransform.position, pointB.position) < 0.1f) 
        {
            targetPosition = pointA.position;
            direction = 1f;
        }
       
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            CheckSuccess();
        }
    }
    void CheckSuccess()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(safeZone, pointerTransform.position, null)) 
        {
            Debug.Log("Success!");
            safeZone.transform.localScale += scaleChange;
            if (safeZone.transform.localScale.x < 0f)
            {
                safeZone.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Fail!");
        }
    }
}
