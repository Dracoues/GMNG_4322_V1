using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class StegoChargeState : StegoBaseState
{
    public StegoChargeState(StegoEnemy stego, string animationName) : base(stego, animationName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered Charge");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exited Charge");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (Time.time >= stego.stateTime + stego.stats.chargeTime)
        {
            if (stego.CheckForPlayer())
            {
                //stego.SwitchState(stego.stegoPlayerDetectedState);
            }
            else
                stego.SwitchState(stego.patrolState);
        }
        else
        {
            if(stego.CheckForMeleeTarget() && stego.detector.StegoAggro())
                stego.SwitchState(stego.stegoAttackState);
            Charge();
        }

    }

   /* public bool CheckForStegosForAggro()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(stego.stegoDetector.position, stego.stats.stegoDetectDistance, stego.stegoTag);
        foreach (Collider2D hitCollider in hitColliders)
        {
            stego.stegoCounter++;
            Debug.Log(stego.stegoCounter);
        }

        if (stego.stegoCounter >= 2)
            return true;
        else
            return false;

    }*/

    void Charge()
    {
        stego.rb.linearVelocity = new Vector2(stego.stats.chargeSpeed * stego.facingDirection, stego.rb.linearVelocityY);
    }
}
