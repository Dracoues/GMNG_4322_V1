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
        UnityEngine.Debug.Log("Entered Carni Charge");
    }

    public override void Exit()

    {
        base.Exit();
        UnityEngine.Debug.Log("Exited Carni Charge");
    }

    public override void LogicUpdate()

    { base.LogicUpdate(); }


    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (Time.time >= carni.stateTime + carni.stats.chargeTime)
        {
            if (carni.CheckForPlayer())
            {
                carni.SwitchState(carni.carniplayerDetectedState);
            }
            else
                carni.SwitchState(carni.patrolState);
        }
        else
        {

            if(carni.CheckForMeleeTarget() && carni.CarnistegoDetector.CarniAggro() && carni.CanAttack())
                carni.SwitchState(carni.carniAttackState);
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

        carni.rb.linearVelocity = new Vector2(carni.stats.chargeSpeed * carni.facingDirection, carni.rb.linearVelocityY);

    }

}

   /* public bool CheckForCarnisForAggro()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(carni.stegoDetector.position, carni.stats.stegoDetectDistance, carni.carniTag);

        carni.stegoCounter = hitColliders.Length;
        UnityEngine.Debug.Log(carni.stegoCounter);

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




