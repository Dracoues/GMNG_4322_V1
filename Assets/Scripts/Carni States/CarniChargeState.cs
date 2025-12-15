using System.Diagnostics;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

using UnityEngine;



public class CarniChargeState : CarniBaseState

{

    public CarniChargeState(CarniEnemy carni, string animationName) : base(carni, animationName)

    {    }


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

    { base.LogicUpdate(); }

    public override void PhysicsUpdate()

    {
        base.PhysicsUpdate();

        if (Time.time >= carni.stateTime + carni.stats.chargeTime)

        {
            if (carni.CheckForPlayer())
                carni.SwitchState(carni.carniplayerDetectedState);

            else
                carni.SwitchState(carni.patrolState);
        }

        else
        {
            if (carni.CheckForMeleeTarget() /*&& CheckForCarnisForAggro()*/)
                carni.SwitchState(carni.carniAttackState);
            Charge();
        }
    }

    public bool CheckForCarnisForAggro()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(carni.stegoDetector.position, carni.stats.carniDetectDistance, carni.carniTag);

        carni.stegoCounter = hitColliders.Length;
        Debug.Log(carni.stegoCounter);

        return carni.stegoCounter <= 2;
    }


    /* public bool CheckForCarnisForAggro()

     { Collider2D[] hitColliders = Physics2D.OverlapCircleAll(carni.stegoDetector.position, carni.stats.carniDetectDistance, carni.carniTag);

         foreach (Collider2D hitCollider in hitColliders)
         {
             carni.stegoCounter--;
             Debug.Log(carni.stegoCounter);
         }

         if (carni.stegoCounter <= 2)
             return true;
         else
             return false;
     }*/



    void Charge()

    {

        carni.rb.linearVelocity = new Vector2(carni.stats.chargeSpeed * carni.facingDirection, carni.rb.linearVelocityY);

    }

}
