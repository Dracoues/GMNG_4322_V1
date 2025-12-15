using UnityEngine;

public class Player_Jump : Player_Base
{
    public Player_Jump(Player player) : base(player) { }

    public override void Enter()
    {

        player.rb.linearVelocity = new Vector2(player.rb.linearVelocity.x, player.jumpForce);
        player.PlaySFX(player.JumpClip);

        player.extraJumps = player.extraJumpsValue;

        base.Enter();
        Debug.Log("Player Jumped");
        animator.SetBool("isJumping", true);
  

        Debug.Log("Jump If");


    }

    public override void Update()
    {
        base.Update();

        if (player.extraJumps > 0 && JumpPressed)
        {
            player.rb.linearVelocity = new Vector2(player.rb.linearVelocity.x, player.jumpForce);
            player.extraJumps--;
            player.PlaySFX(player.JumpClip);
            JumpPressed = false;
            JumpReleased = false;
            Debug.Log("Jump else");
        }

        if (player.isGrounded && player.rb.linearVelocity.y <= 0)
            player.ChangeState(player.idleState);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        player.ApplyVariableGravity();



        float speed = player.moveSpeed;
        float moveInput = MoveInput.x;

        if (JumpReleased && player.rb.linearVelocity.y > 0)
        {
            player.rb.linearVelocity = new Vector2(player.rb.linearVelocity.x, player.rb.linearVelocity.y * player.jumpCutMultiplier);
            JumpReleased = false;
        }


        player.rb.linearVelocity = new Vector2(speed * moveInput, player.rb.linearVelocity.y);



    }

    public override void Exit()
    {
        base.Exit();
        animator.SetBool("isJumping", false);
    }

}
