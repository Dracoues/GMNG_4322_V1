using UnityEngine;



public class PteraBaseState

{

    protected PteraEnemy ptera;

    protected string animationName;





    public PteraBaseState(PteraEnemy ptera, string animationName)

    {

        this.ptera = ptera;

        this.animationName = animationName;

    }





    public virtual void Enter()

    {

        ptera.anim.SetBool(animationName, true);

    }



    public virtual void Exit()

    {

        ptera.anim.SetBool(animationName, false);

    }



    public virtual void LogicUpdate() { }





    public virtual void PhysicsUpdate() { }



    public virtual void AnimationFinishedTigger() { }

    public virtual void AnimationAttackTrigger() { }





}

