using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : WeaponController
{
    public float attackAngle;
    public string enemyTag = "Enemy";
    private Quaternion[] swordDirections = new Quaternion[]
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
        SwordAttack();
    }

    private void SwordAttack()
    {
        // ity to increase count of whip
        for (int i = 0; i < count; i++)
        {
            // Spawn whip
            GameObject spawnedSword = Instantiate(prefab, gameObject.transform);   

            //Increased range depending on whip count
            spawnedSword.transform.localScale *= PlayerController.playerStats.GetStat(Stat.attackAreaModifier);

            // TODO: Depending on the whip count decide which direction to face (e.g. whips in vampire survivor)
            spawnedSword.transform.rotation = swordDirections[i % 4];

        }
    }

    public void ResetCooldown()
    {
        currentCooldown = cooldownDuration;
    }

}
