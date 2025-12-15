using UnityEngine;



public class PteraDamagedState : PteraBaseState

{

    public float KBForce;

    public Vector2 KBAngle;



    public PteraDamagedState(PteraEnemy ptera, string animationName) : base(ptera, animationName)

    {



    }



    public override void Enter()

    {

        base.Enter();

        ApplyKnockback();



    }



    public override void Exit()

    {

        base.Exit();

    }



    public override void LogicUpdate()

    {

        base.LogicUpdate();

    }



    public override void PhysicsUpdate()

    {

        base.PhysicsUpdate();

    }



    public override void AnimationAttackTrigger()

    {

        base.AnimationAttackTrigger();

    }



    public override void AnimationFinishedTigger()

    {

        base.AnimationFinishedTigger();

    }



    private void ApplyKnockback()

    {

        ptera.rb.linearVelocity = KBAngle * KBForce;

    }



}

