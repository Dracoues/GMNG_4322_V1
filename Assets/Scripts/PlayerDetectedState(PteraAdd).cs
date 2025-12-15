using UnityEngine;



public class PlayerDetectedState : StegoBaseState

{

    public PlayerDetectedState(StegoEnemy stego, string animationName) : base(stego, animationName)

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

public class PlayerDetectedState : CarniBaseState

{

    public PlayerDetectedState(CarniEnemy carni, string animationName) : base(carni, animationName)

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

public class PlayerDetectedState : PteraBaseState

{

    public PlayerDetectedState(PteraEnemy ptera, string animationName) : base(ptera, animationName)

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

