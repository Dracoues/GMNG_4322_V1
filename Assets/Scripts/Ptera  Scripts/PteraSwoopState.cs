using System.Diagnostics;
using System.Numerics;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;



public class PteraSwoopState : PteraBaseState

{
    public PteraSwoopState(PteraEnemy ptera, string animationName) : base(ptera, animationName)
    {  }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered Swoop");
    }

    public override void Exit()
    {   base.Exit();
        Debug.Log("Exited Swoop");
    }

    public override void LogicUpdate()
    { base.LogicUpdate(); }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (Time.time >= ptera.stateTime + ptera.stats.chargeTime)

        {

            if (ptera.CheckForPlayer())
               { ptera.SwitchState(ptera.playerDetectedState); }
            else
                ptera.SwitchState(ptera.patrolState);
        }

        else
        {
            if (ptera.CheckForMeleeTarget() & ptera.CanAttack())
                ptera.SwitchState(ptera.pteraAttackState);
            Swoop();
        }
    }

    void Swoop()
    { ptera.rb.linearVelocity = new UnityEngine.Vector2(ptera.swoopSpeed * ptera.facingDirection, ptera.rb.linearVelocityY);  }

}



