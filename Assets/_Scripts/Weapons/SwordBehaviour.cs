using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MeleeWeaponBehaviour
{

    SwordController swordController;
    
    protected override void Start()
    {
        base.Start();
        swordController = FindObjectOfType<SwordController>();
    }

    void Update()
    {
        //Direction of attack
        Vector3 attackDirection = transform.right;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyController enemyController = null;
            try
            {
                enemyController = collision.GetComponent<EnemyController>();
            }
            catch
            {
                Debug.LogWarning($"Enemy {collision.gameObject.name} does not have an EnemyController component.");
                return;
            }

            enemyController.enemyStats.ChangeStat(Stat.health, -swordController.damage);
        }
    }

    private void OnDestroy()
    {
        swordController.ResetCooldown();
    }
}
