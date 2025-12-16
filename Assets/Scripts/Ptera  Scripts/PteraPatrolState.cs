using System.Diagnostics;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;




public class PteraPatrolState : PteraBaseState

{

    public PteraPatrolState(PteraEnemy ptera, string animationName) : base(ptera, animationName)
    { }

    public override void Enter()
    {
        base.Enter();
        UnityEngine.Debug.Log("Entered Patrol");
    }

    public override void Exit()
    {
        base.Exit();
        UnityEngine.Debug.Log("Exited Patrol");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (ptera.CheckForPlayer())
        { ptera.SwitchState(ptera.playerDetectedState); }

        if (ptera.CheckLedgesAndWalls())
        {  }
           //head back up
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (ptera.facingDirection == 1)
            ptera.rb.linearVelocity = new UnityEngine.Vector2(ptera.stats.speed, ptera.rb.linearVelocityY);

        else
            ptera.rb.linearVelocity = new UnityEngine.Vector2(-ptera.stats.speed, ptera.rb.linearVelocityY);
    }

    //public move back upward
}

