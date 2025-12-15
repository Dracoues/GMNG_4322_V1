using UnityEngine;


public class PteraPlayerDetectedState : PteraBaseState

{

    public PteraPlayerDetectedState(PteraEnemy ptera, string animationName) : base(ptera, animationName)

    {



    }



    public override void Enter()

    {

        base.Enter();

        Debug.Log("Entered PlayerDetected");

    }



    public override void Exit()

    {

        base.Exit();

        Debug.Log("Exited PlayerDetected");

    }

    public override void LogicUpdate()

    {

        base.LogicUpdate();



        if (!ptera.CheckForPlayer())

            ptera.SwitchState(ptera.patrolState);

        else

        {

            if (Time.time >= ptera.stateTime + ptera.stats.playerDetectedWaitTime)

                ptera.SwitchState(ptera.pteraSwoopState);

        }

    }



    public override void PhysicsUpdate()

    {

        base.PhysicsUpdate();

    }

}

