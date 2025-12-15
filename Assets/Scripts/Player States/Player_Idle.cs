using UnityEngine;

public class Player_Idle : Player_Base
{
    public Player_Idle(Player player): base(player) { }

    public override void Enter()
    {
        animator.SetBool("isIdle", true);
        player.rb.linearVelocity= new Vector2(0,player.rb.linearVelocity.y);
    }

    public override void Update()
    {
        base.Update();

        if(AttackPressed)
           player.ChangeState(player.attackState);

        else if (JumpPressed && player.isGrounded)
        {
            player.jumpPressed = false;
            player.ChangeState(player.jumpState);

        }
        else if (Mathf.Abs(MoveInput.x)> .1f)
        {
            player.ChangeState(player.moveState);
        }
    }

    public override void Exit()
    {
        animator.SetBool("isIdle", false);
    }

}
