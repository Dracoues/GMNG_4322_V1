using UnityEngine;

public class Player_Jump : Player_Base
{
    public Player_Jump(Player player) : base(player) { }

    public override void Enter()
    {
        player.extraJumps = player.extraJumpsValue;
        base.Enter();
        Debug.Log("Player Jumped");
        animator.SetBool("isJumping", true);
  
        player.rb.linearVelocity = new Vector2(player.rb.linearVelocity.x, player.jumpForce);
        JumpPressed = false;
        JumpReleased = false;

        player.PlaySFX(player.JumpClip);
        Debug.Log("Jump If");

        /*if (player.isGrounded)
        {
            player.rb.linearVelocity = new Vector2(player.rb.linearVelocity.x, player.jumpForce);
            player.PlaySFX(player.JumpClip);
            Debug.Log("Jump If");
        }*/

    }

    public override void Update()
    {
        base.Update();

        /*if (player.extraJumps > 0 && JumpPressed)
        {
            player.rb.linearVelocity = new Vector2(player.rb.linearVelocity.x, player.jumpForce);
            player.extraJumps--;
            player.PlaySFX(player.JumpClip);
            JumpReleased = true;
            Debug.Log("Jump else");
 
            player.ChangeState(player.idleState);
        }*/

        if (player.isGrounded && player.rb.linearVelocity.y < 0)
            player.ChangeState(player.idleState);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        player.ApplyVariableGravity();



        float speed = player.moveSpeed;
        float moveInput = MoveInput.x;

        player.rb.linearVelocity = new Vector2(speed * moveInput, player.rb.linearVelocity.y);

        if (JumpReleased && player.rb.linearVelocity.y > 0)
        {
            player.rb.linearVelocity = new Vector2(player.rb.linearVelocity.x, player.rb.linearVelocity.y * player.jumpCutMultiplier);
            JumpReleased = false;
        }


    }

    public override void Exit()
    {
        base.Exit();
        animator.SetBool("isJumping", false);
    }

}
