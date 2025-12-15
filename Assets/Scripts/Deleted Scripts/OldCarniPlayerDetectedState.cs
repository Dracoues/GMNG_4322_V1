/*using UnityEngine;

//carni

public class OldCarniPlayerDetectedState : CarniBaseState

{

    public CarniPlayerDetectedState(CarniEnemy carni, string animationName) : base(carni, animationName)

    {    }



    public override void Enter()

    {

        base.Enter();

        Debug.Log("Entered PlayerDetected");

    }



    public override void Exit()

    {

        base.Exit();

        Debug.Log("Exited PlayerDetected");

        // carni.rb.linearVelocity = Vector2.zero;

    }

    public override void LogicUpdate()

    {

        base.LogicUpdate();



        if (!carni.CheckForPlayer())

            carni.SwitchState(carni.patrolState);

        else

        {

            if (Time.time >= carni.stateTime + carni.stats.playerDetectedWaitTime)

                carni.SwitchState(carni.carniChargeState);

        }

    }



    public override void PhysicsUpdate()

    {

        base.PhysicsUpdate();

    }

}

//carni end
*/