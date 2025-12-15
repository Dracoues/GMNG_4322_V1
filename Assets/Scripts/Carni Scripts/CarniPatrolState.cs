using UnityEngine;

using UnityEngine.UIElements;

using static UnityEngine.RuleTile.TilingRuleOutput;



public class CarniPatrolState : CarniBaseState

{

    public CarniPatrolState(CarniEnemy carni, string animationName) : base(carni, animationName)

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



        if(carni.CheckForPlayer())

            carni.SwitchState(carni.carniplayerDetectedState);



        if (carni.CheckLedgesAndWallsAndCarnis())

            Rotate();

        

        

    }



    public override void PhysicsUpdate()

    {

        base.PhysicsUpdate();



        if (carni.facingDirection == 1)

            carni.rb.linearVelocity = new Vector2(carni.stats.speed, carni.rb.linearVelocityY);

        else

            carni.rb.linearVelocity = new Vector2(-carni.stats.speed, carni.rb.linearVelocityY);

    }



    void Rotate()

    {

        carni.transform.Rotate(0, 180, 0);

        carni.facingDirection = -carni.facingDirection;

    }

}

