using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubController : WeaponController
{
    public float attackAngle;
    public string enemyTag = "Enemy";
    private Quaternion[] clubDirections = new Quaternion[]
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
        ClubAttack();
    }

    private void ClubAttack()
    {
        // ity to increase count of whip
        for (int i = 0; i < count; i++)
        {
            // Spawn weapon
            GameObject spawnedClub = Instantiate(prefab, gameObject.transform);   

            //Increased range depending on count
            spawnedClub.transform.localScale *= PlayerController.playerStats.GetStat(Stat.attackAreaModifier);

            // TODO: Depending on the count decide which direction to face 
            spawnedClub.transform.rotation = clubDirections[i % 4];

        }
    }

    public void ResetCooldown()
    {
        currentCooldown = cooldownDuration;
    }

}
