using UnityEngine;

public class Player_Jump : Player_Base
{
    public Player_Jump(Player player) : base(player) { }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Player Jumped");
        animator.SetBool("isJumping", true);

        if (player.isGrounded)
        {
            player.rb.linearVelocity = new Vector2(player.rb.linearVelocity.x, player.jumpForce);
            player.PlaySFX(player.JumpClip);
        }
        else if (player.extraJumps > 0)
        {
            player.rb.linearVelocity = new Vector2(player.rb.linearVelocity.x, player.jumpForce);
            player.extraJumps--;
            player.PlaySFX(player.JumpClip);
            JumpPressed = false;
        }

    }

    public override void Update()
    {
        base.Update();
        if (player.isGrounded && player.rb.linearVelocity.y < 0)
            player.ChangeState(player.idleState);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

    }

    public override void Exit()
    {
        base.Exit();
        animator.SetBool("isJumping", false);
    }

}
