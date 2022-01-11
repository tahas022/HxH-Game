using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    
    public Animator combat;
    public Transform attackPoint;
    public Transform attackPointL;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public int attackDamage = 40;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }  else if (Input.GetKeyDown(KeyCode.X))
        {
            AttackL();
            nextAttackTime = Time.time + 1f / attackRate;
        }  
        }
    }

    void Attack()
    {
        // Play an attack animation
        combat.SetTrigger("Attack");

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them 
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    void AttackL()
    {
        // Play an attack animation
        combat.SetTrigger("AttackL");
        // Detect enemies in range of attack
         Collider2D[] hitEnemiesL = Physics2D.OverlapCircleAll(attackPointL.position, attackRange, enemyLayers);
        // Damage them 
         foreach(Collider2D enemy in hitEnemiesL)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(attackPointL.position, attackRange);
    }
}
