using UnityEngine;

public class BossEnnemi : Ennemi
{
    public override void Death()
    {
        gameManager.isBossKilled = true;
        
        gameManager.NukeMe(gameObject);
        Destroy(gameObject);
    }
}
