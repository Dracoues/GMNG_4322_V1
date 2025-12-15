using UnityEngine;

public class Player_Idle : Player_Base
{
    public Player_Idle(Player player): base(player) { }

    public override void Enter()
    {
        animator.SetBool("isIdle", true);
    }

    public override void Update()
    {
        base.Update();

        if(JumpPressed)
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
