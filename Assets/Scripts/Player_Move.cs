using UnityEngine;

public class Player_Move : Player_Base
{
    public Player_Move(Player player) : base(player) { }

    public override void Enter()
    {
        base.Enter();

    }
    public override void Update()
    {
        base.Update();

        if(JumpPressed)
        {
            player.ChangeState(player.jumpState);
        }
        else if(Mathf.Abs(MoveInput.x)<.1f)
        {
            player.ChangeState(player.idleState);
        }

            animator.SetBool("isWalking", true);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        float speed = player.moveSpeed;
        player.rb.linearVelocity = new Vector2(speed * player.isFaceingRight, player.rb.linearVelocity.y);

    }

    public override void Exit()
    {
        base.Exit();

        animator.SetBool("isWalking", false);
    }

}
