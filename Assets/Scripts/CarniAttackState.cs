using UnityEngine;



public class CarniAttackState : CarniBaseState

{

    public CarniAttackState(CarniEnemy carni, string animationName) : base(carni, animationName)

    {



    }



    public override void Enter()

    {

        base.Enter();



        Debug.Log("Entered Attack");



    }



    public override void Exit()

    {

        base.Exit();

        Debug.Log("Exited Attack");

    }



    public override void LogicUpdate()

    {

        base.LogicUpdate();

    }



    public override void PhysicsUpdate()

    {

        base.PhysicsUpdate();

    }



    public override void AnimationAttackTrigger()

    {

        base.AnimationAttackTrigger();

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(carni.ledgeDetector.position, carni.stats.meleeDetectDistance, carni.damageableLayer);



        foreach (Collider2D hitCollider in hitColliders)

        {

            IDamageable damageable = hitCollider.GetComponent<IDamageable>();



            if ((damageable != null))

            {

                hitCollider.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(carni.stats.knockbackAngle.x * carni.facingDirection,

                    carni.stats.knockbackAngle.y) * carni.stats.knockbackForce;

                damageable.Damage(carni.stats.damageAmount);

            }

        }

    }



    public override void AnimationFinishedTigger()

    {

        base.AnimationFinishedTigger();

        carni.SwitchState(carni.patrolState);

    }



}

