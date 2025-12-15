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

        if (AttackPressed)
            player.ChangeState(player.attackState);

        else if (JumpPressed)
        {
            player.ChangeState(player.jumpState);
            Debug.Log("in player move jump check");
        }
        else if(Mathf.Abs(MoveInput.x)<= 0.1f)
        {
            Debug.Log("in player move to idle");
            player.ChangeState(player.idleState);
            
        }
        else
        {
            animator.SetBool("isWalking", true);
        }
            
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
