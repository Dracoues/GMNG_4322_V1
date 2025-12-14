using UnityEngine;

public class PlayerDetectedState : StegoBaseState
{
    public PlayerDetectedState(StegoEnemy stego, string animationName) : base(stego, animationName)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
       // stego.rb.linearVelocity = Vector2.zero;
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!stego.CheckForPlayer())
            stego.SwitchState(stego.patrolState);
        else
        {
            if (Time.time >= stego.stateTime + stego.stats.playerDetectedWaitTime)
                stego.SwitchState(stego.stegoChargeState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
