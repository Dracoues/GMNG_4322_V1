using UnityEngine;

public class Combat : MonoBehaviour
{
    public Player player;

    [Header("Attack Settings")]
    public int damage;
    public float attackRadius = .5f;
    public Transform attackPoint;
    public LayerMask enemyLayer, stegoLayer;
    public float attackCooldown = 1f;

    public bool CanAttack => Time.time > attackCooldown;
    private float nextAttackTime;

    public void CombatAttackAnimationFinished()
    {
        player.AttackAnimationFinished();
    }

    public void Attack()
    {
         if (!CanAttack)
             return;

         nextAttackTime = Time.time + attackCooldown;

         Collider2D enemy = Physics2D.OverlapCircle(attackPoint.position, attackRadius, enemyLayer);

         IDamageable damageable = enemy.GetComponent<IDamageable>();

         if (damageable != null)
             damageable.Damage(damage, 5, new Vector2(1, 1));

    }
}
