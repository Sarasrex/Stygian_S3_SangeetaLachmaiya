using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAndChainController : WeaponController
{
    public float attackAngle;
    public string enemyTag = "Enemy";
    private Quaternion[] ballAndChainDirections = new Quaternion[]
    {
        Quaternion.Euler(0, 0, 0),     // Right
        Quaternion.Euler(0, 0, 180),   // Left
        Quaternion.Euler(0, 0, 90),    // Top
        Quaternion.Euler(0, 0, -90)    // Bottom
    };

    protected new void Start()
    {
        //base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        BallAndChainAttack();
    }

    private void BallAndChainAttack()
    {
        // ity to increase count of whip
        for (int i = 0; i < count; i++)
        {
            // Spawn whip
            GameObject spawnedBallAndChain = Instantiate(prefab, gameObject.transform);   

            //Increased range depending on count
            spawnedBallAndChain.transform.localScale *= PlayerController.playerStats.GetStat(Stat.attackAreaModifier);

            // TODO: Depending on the count decide which direction to face 
            spawnedBallAndChain.transform.rotation = ballAndChainDirections[i % 4];

        }
    }

    public void ResetCooldown()
    {
        currentCooldown = cooldownDuration;
    }

}
