using UnityEngine;



public class DamagedState : StegoBaseState

{

    public float KBForce;

    public Vector2 KBAngle;



    public DamagedState(StegoEnemy stego, string animationName) : base(stego, animationName)

    {



    }

    public DamagedState(PteraEnemy ptera, string animationName) : base(ptera, animationName)

    {



    }

    public DamagedState(CarniEnemy carni, string animationName) : base(carni, animationName)

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

        stego.rb.linearVelocity = KBAngle * KBForce;

    }



}

