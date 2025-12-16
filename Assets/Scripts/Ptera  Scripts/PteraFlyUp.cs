using UnityEngine;

public class PteraFlyUpState : PteraBaseState
{
    public PteraFlyUpState(PteraEnemy ptera, string animationName) : base(ptera, animationName) {}

    public override void Enter()
    {
        base.Enter();
        ptera.rb.linearVelocity = Vector2.zero;
        ptera.anim.SetTrigger("FlyUp");
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        // fly upward
        ptera.rb.linearVelocity = new Vector2(0, ptera.stats.flyUpSpeed);

        // when high enough, return to patrol
        if (ptera.transform.position.y >= ptera.stats.returnHeight)
        {
            ptera.SwitchState(ptera.patrolState);
        }
    }
}
