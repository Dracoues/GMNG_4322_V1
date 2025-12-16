using UnityEngine;

public class CarniDamagedState : CarniBaseState

{

    public float KBForce;
    public Vector2 KBAngle;

    public CarniDamagedState(CarniEnemy carni, string animationName) : base(carni, animationName)
    {  }

    public override void Enter()

    { base.Enter();
      ApplyKnockback();
    }

    public override void Exit()
    { base.Exit(); }

    public override void LogicUpdate()

    { base.LogicUpdate(); }

    public override void PhysicsUpdate()

    { base.PhysicsUpdate(); }

    public override void AnimationAttackTrigger()

    { base.AnimationAttackTrigger(); }

    public override void AnimationFinishedTigger()

    { base.AnimationFinishedTigger(); }

    private void ApplyKnockback()

    { carni.rb.linearVelocity = KBAngle * KBForce; }
}

