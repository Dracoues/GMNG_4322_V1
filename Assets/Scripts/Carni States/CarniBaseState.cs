using UnityEngine;



public class CarniBaseState 

{

    protected CarniEnemy carni;

    protected string animationName;





    public CarniBaseState( CarniEnemy carni, string animationName )

    {

        this.carni = carni;

        this.animationName = animationName;

    }





    public virtual void Enter()

    {

        carni.anim.SetBool(animationName, true);   

    }



    public virtual void Exit() 

    {

        carni.anim.SetBool(animationName, false);

    }



    public virtual void LogicUpdate() { }

   



    public virtual void PhysicsUpdate() { }



    public virtual void AnimationFinishedTigger() { }

    public virtual void AnimationAttackTrigger() { }





}

