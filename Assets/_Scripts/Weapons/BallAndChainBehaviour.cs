using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAndChainBehaviour : MeleeWeaponBehaviour
{

    BallAndChainController ballAndChainController;
    
    protected override void Start()
    {
        base.Start();
        ballAndChainController = FindObjectOfType<BallAndChainController>();
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

            enemyController.enemyStats.ChangeStat(Stat.health, -ballAndChainController.damage);
        }
    }

    private void OnDestroy()
    {
        ballAndChainController.ResetCooldown();
    }
}
