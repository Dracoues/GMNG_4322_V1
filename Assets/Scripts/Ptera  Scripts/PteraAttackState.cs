using System.Diagnostics;
using System.Numerics;
using UnityEngine;



public class PteraAttackState : PteraBaseState

{

    public PteraAttackState(PteraEnemy ptera, string animationName) : base(ptera, animationName)

    {  }

    public override void Enter()

    { 
      base.Enter();
      //start cooldown
      ptera.lastAttackTime = Time.time;
      //stop movement
      ptera.rb.linearVelocity = UnityEngine.Vector2.zero;
      //trigger animation
      ptera.anim.SetTrigger("Attack");
        UnityEngine.Debug.Log("Entered Attack");
    }

    public override void Exit()

    {
        base.Exit();
        UnityEngine.Debug.Log("Exited Attack");
    }

    public override void LogicUpdate()

    { base.LogicUpdate(); }

    public override void PhysicsUpdate()

    {
        base.PhysicsUpdate();

        if (ptera.CheckForMeleeTarget())
        {
        ptera.SwitchState(ptera.pteraAttackState);
        AnimationAttackTrigger();
        }

    }



    public override void AnimationAttackTrigger()

    {
        base.AnimationAttackTrigger();
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(ptera.ledgeDetector.position, ptera.stats.meleeDetectDistance, ptera.damageableLayer);

        foreach (Collider2D hitCollider in hitColliders)

        {
            IDamageable damageable = hitCollider.GetComponent<IDamageable>();

            if ((damageable != null))

            {
                hitCollider.GetComponent<Rigidbody2D>().linearVelocity = new UnityEngine.Vector2(ptera.stats.knockbackAngle.x * ptera.facingDirection, ptera.stats.knockbackAngle.y) * ptera.stats.knockbackForce;
                damageable.Damage(ptera.stats.damageAmount);
            }

        }

    }

    public override void AnimationFinishedTigger()

    {
        base.AnimationFinishedTigger();
        ptera.SwitchState(ptera.flyUpState);
    }



}

