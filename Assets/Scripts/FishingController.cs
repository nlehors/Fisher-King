using UnityEngine;
using UnityEngine.InputSystem;

public class FishingController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public RectTransform[] safeZones;
    public float moveSpeed = 100f;
    public GameObject fishingUI;
    public FishingManager fishingManager;
    
    private RectTransform pointerTransform;
    private Vector3 targetPosition;
    private int successCount = 0;
    private int qteCount = 0;
    
    public Player player;
    
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
        
        pointerTransform.position = Vector3.MoveTowards(pointerTransform.position, targetPosition, moveSpeed * Time.deltaTime*fishingUI.transform.localScale.x);

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
                if (successCount>=1)
                {
                    player.playerMoney++;
                }
                
                fishingUI.SetActive(false);
                player.isOnFishingZone = false;
                Restart();
            }
        }
    }
    void CheckSuccess()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(safeZones[successCount], pointerTransform.position, null)) 
        {
            safeZones[successCount].gameObject.SetActive(false);
            successCount++;

            if (successCount < safeZones.Length)
            {
                safeZones[successCount].gameObject.SetActive(true);
            }

        }
    }
    public void Restart()
    {
        if (!player.isOnFishingZone)
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

//[Intro]
//Life could be a dream
//Life could be a dream
//Doo doo doo doo, sh-boom
//
//[Chorus]
//Life could be a dream (Sh-boom)
//If I could take you up in paradise up above (Sh-boom)
//If you would tell me I'm the only one that you love
//Life could be a dream, sweetheart
//Hello, hello again, sh-boom and hopin' we'll meet again, boom (Ba-boom)
//
//[Refrain]
//Day dong da ding-dong
//A-lang-da-lang-da-lang
//Ah, woah, woah, bip
//Ah bi-ba-do-da-dip, woah
//
//[Verse]
//Life could be a dream (Sh-boom)
//If only all my precious plans would come true (Sh-boom)
//If you would let me spend my whole life lovin' you
//Life could be a dream, sweetheart
//(Doo doo doo doo, sh-boom)
//
//[Bridge]
//Every time I look at you
//Something is on my mind
//If you do what I want you to
//Baby, we'd be so fine
//You might also like
//The Tortured Poets Department
//Taylor Swift
//loml
//Taylor Swift
//thanK you aIMee
//Taylor Swift
//[Chorus]
//Oh, life could be a dream, sh-boom
//If I could take you up in paradise up above, sh-boom
//You'd tell me, darlin', I'm the only one that you love
//Life could be a dream, sweetheart
//Hello, hello again, sh-boom and hope we'll meet again, boom (Ba-boom)
//
//[Refrain]
//Day dong da ding-dong
//Sha-lang-a-la-lang-a-la-lang-a-la-lang-a-la
//Woah, woah, bip
//Ah bo da do da dip, woah
//
//[Bridge]
//Life could be a dream
//Life could be a dream, sweetheart
//(Doo doo doo doo, sh-boom)
//(Doo doo doo doo, sh-boom)
//(Doo doo doo doo, sh-boom)
//(Doo doo doo doo, sh-boom)
//(Doo doo doo doo, sh-boom)
//(Doo doo doo doo, sh-boom)
//(Doo doo doo doo, sh-boom)
//
//[Chorus]
//Woah, life could be a dream, sh-boom
//If I could take you up in paradise up above, sh-boom
//You'd tell me, darlin', I'm the only one that you love
//Life could be a dream, sweetheart
//Hello, hello again, sh-boom and hope we'll meet again, boom (Ba-boom)
//[Outro]
//Day dong da ding-dong
//A-lang-a-la-lang-a-la-lang-a-la-lang-a-la
//Woah, woah, bip
//Ah bo da do da dip, woah
//Life could be a dream, life could be a dream
//Do do do do, sh-boom