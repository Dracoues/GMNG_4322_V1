using UnityEngine;

public class StegoBaseState 
{
    protected StegoEnemy stego;
    protected string animationName;


    public StegoBaseState( StegoEnemy stego, string animationName )
    {
        this.stego = stego;
        this.animationName = animationName;
    }


    public virtual void Enter()
    {
        stego.anim.SetBool(animationName, true);   
    }

    public virtual void Exit() 
    {
        stego.anim.SetBool(animationName, true);
    }

    public virtual void LogicUpdate() { }
   

    public virtual void PhysicsUpdate() { }

    public virtual void AnimationFinishedTigger(){ }
    public virtual void AnimationAttackTrigger(){ }


}
