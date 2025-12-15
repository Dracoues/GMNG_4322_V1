using UnityEngine;

public abstract class Player_Base 
{
    protected Player player;
    protected Animator animator;
    protected bool JumpPressed {get => player.jumpPressed; set => player.jumpPressed = value;}
    protected bool JumpReleased { get => player.jumpReleased; set => player.jumpReleased = value; }
    protected bool WalkPressed => player.walkPressed;
    protected Vector2 MoveInput => player.moveInput;

    public Player_Base(Player player)
    {
        this.player = player;
        this.animator = player.animator;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }

    public virtual void Update() { }
    public virtual void FixedUpdate() { }

}
