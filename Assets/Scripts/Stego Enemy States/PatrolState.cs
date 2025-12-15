using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PatrolState : StegoBaseState
{
    public PatrolState(StegoEnemy stego, string animationName) : base(stego, animationName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered Patrol");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exited Patrol");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(stego.CheckForPlayer())
            stego.SwitchState(stego.playerDetectedState);

        if (stego.CheckLedgesAndWallsAndStegos())
            Rotate();
        
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (stego.facingDirection == 1)
            stego.rb.linearVelocity = new Vector2(stego.stats.speed, stego.rb.linearVelocityY);
        else
            stego.rb.linearVelocity = new Vector2(-stego.stats.speed, stego.rb.linearVelocityY);
    }

    void Rotate()
    {
        stego.transform.Rotate(0, 180, 0);
        stego.facingDirection = -stego.facingDirection;
    }
}
