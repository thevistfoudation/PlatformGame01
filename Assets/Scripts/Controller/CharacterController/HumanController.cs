using LTAUnityBase.Base.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class HumanController : MoveController
{
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public CircleCollider2D boxCollider2D;
    public enum State
    {
        IDLE,
        RUN,
        JUMP,
        SLIDE,
        CLIMB,
        GLIDE,
        ATTACK,
        THROW,
        JUMPATTACK,
        JUMPTHROW
    }
   public State currentState = State.IDLE;

    protected virtual void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        switch (currentState)
        {
            case State.IDLE:
                Idle();
                break;
            case State.RUN:
                Run();
                break;
        }
    }
    public void MoveLeft()
    {
        this.rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
        transform.eulerAngles = new Vector3(0, 180, 0);

    }
    public void MoveRight()
    {
        this.rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
    protected virtual void ReturnIdle()
    {
        currentState = State.IDLE;
        rigidbody2D.velocity = Vector3.zero;
        animator.Play("Idle");
        
    }
   
    protected virtual void Idle()
    {
        if (JoyStickInput.Left)
        {
            currentState = State.RUN;
            MoveRight();
            animator.Play("Run");
            return;
        }
        if (JoyStickInput.Right)
        {
            currentState = State.RUN;
            MoveLeft();
            animator.Play("Run");
            return;
        }
    }
    protected virtual void Run()
    {
        
        if (JoyStickInput.Right)
        {
           MoveRight();
            //MoveRight();
            return;
        }
        if (JoyStickInput.Left)
        {
            MoveLeft();
            return;
        }
        ReturnIdle();
    }
}
public class Human : SingletonMonoBehaviour<HumanController>
{

}