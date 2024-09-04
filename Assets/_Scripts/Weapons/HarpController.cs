using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpController : WeaponController
{
    public float attackAngle;
    public string enemyTag = "Enemy";
    private Quaternion[] harpDirections = new Quaternion[]
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
        HarpAttack();
    }

    private void HarpAttack()
    {
        // ity to increase count of whip
        for (int i = 0; i < count; i++)
        {
            // Spawn whip
            GameObject spawnedHarp = Instantiate(prefab, gameObject.transform);   

            //Increased range depending on harp count
            spawnedHarp.transform.localScale *= PlayerController.playerStats.GetStat(Stat.attackAreaModifier);

            // TODO: Depending on the harp count decide which direction to face 
            spawnedHarp.transform.rotation = harpDirections[i % 4];

        }
    }

    public void ResetCooldown()
    {
        currentCooldown = cooldownDuration;
    }

}
