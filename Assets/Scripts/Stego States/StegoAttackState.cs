using UnityEngine;

public class StegoAttackState : StegoBaseState
{
    public StegoAttackState(StegoEnemy stego, string animationName) : base(stego, animationName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Entered Attack");

    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exited Attack");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (stego.CheckForMeleeTarget() && stego.detector.StegoAggro())
        {
        stego.SwitchState(stego.stegoAttackState);
        }

    }

    public override void AnimationAttackTrigger()
    {
        base.AnimationAttackTrigger();
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(stego.ledgeDetector.position, stego.stats.meleeDetectDistance, stego.damageableLayer);

        foreach (Collider2D hitCollider in hitColliders)
        {
            IDamageable damageable = hitCollider.GetComponent<IDamageable>();

            if ((damageable != null))
            {
                hitCollider.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(stego.stats.knockbackAngle.x * stego.facingDirection,
                    stego.stats.knockbackAngle.y) * stego.stats.knockbackForce;
                damageable.Damage(stego.stats.damageAmount);
            }
        }
    }

    public override void AnimationFinishedTigger()
    {
        base.AnimationFinishedTigger();
        stego.SwitchState(stego.patrolState);
    }

}
