using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FishingController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public RectTransform[] safeZones;
    public float moveSpeed = 100f;
    public GameObject fishingUI;
    public bool isFishing;
    
    
    private RectTransform pointerTransform;
    private Vector3 targetPosition;
    private int successCount = 0;
    private int qteCount = 0;
    
    void Start()
    {
        pointerTransform = GetComponent<RectTransform>();
        targetPosition = pointB.position;
        for (int i = 0; i < safeZones.Length; i++)
        {
            safeZones[i].gameObject.SetActive(false);
        }
        safeZones[0].gameObject.SetActive(true);
        Restart();
    }
    
    
   public void QTE ()
    {
        
        pointerTransform.position = Vector3.MoveTowards(pointerTransform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(pointerTransform.position, pointA.position) < 0.1f) 
        {
            targetPosition = pointB.position;
        }
        else if (Vector3.Distance(pointerTransform.position, pointB.position) < 0.1f) 
        {
            targetPosition = pointA.position;
        }
       
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            CheckSuccess();
            qteCount++;
            if (qteCount >= 3)
            {
                 fishingUI.SetActive(false);
                 isFishing = false;
                 Restart();
            }
        }
    }
    void CheckSuccess()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(safeZones[successCount], pointerTransform.position, null)) 
        {
            Debug.Log("Success!");
            safeZones[successCount].gameObject.SetActive(false);
            successCount++;

            if (successCount < safeZones.Length)
            {
                safeZones[successCount].gameObject.SetActive(true);
            }

        }
        else
        {
            Debug.Log("Fail!");
        }
    }
    public void Restart()
    {
        if (isFishing == false)
        {
            qteCount = 0;
            successCount = 0;
            
            for (int i = 0; i < safeZones.Length; i++)
            {
                safeZones[i].gameObject.SetActive(false);
            }
            safeZones[0].gameObject.SetActive(true);
        }
    }
}
