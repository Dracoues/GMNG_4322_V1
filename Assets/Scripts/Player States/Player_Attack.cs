using UnityEngine;

public class Player_Attack : Player_Base
{

    public Player_Attack(Player player) : base(player) { }

    public bool CanAttack => Time.time >= nextAttackTime;
    private float nextAttackTime;

    public override void Enter()
    {
        base.Enter();
        animator.SetBool("attack", true);
        player.rb.linearVelocity = new Vector2(0, player.rb.linearVelocity.y);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Update()
    {
        base.Update();

    }
    
    public override void AttackAnimationFinished()
    {
        if (Mathf.Abs(MoveInput.x) > .1f)
        {
            player.ChangeState(player.moveState);
        }
        else
            player.ChangeState(player.idleState);
    }
    public override void Exit()
    {
        base.Exit();
        animator.SetBool("attack", false);

    }

}
