using LTAUnityBase.Base.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class AdventrureController : HumanController
{
    [SerializeField]
    ButtonController  BtnSlide;
    protected override void Start()
    {
        BtnSlide.OnClick((ButtonController btn) =>
        {
            JoyStickInput.Slide = true;
        });
    }
    protected override void Update()
    {
        base.Update();
        switch (currentState)
        {
            case State.JUMP:
                Jump();
                break;
            case State.SLIDE:
                Slide();
                break;
        }
    }
    protected virtual void JumpAction()
    {
        currentState = State.JUMP;
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 8);
        animator.Play("JumpUp");
    }
    protected override void Idle()
    {
        base.Idle();
        if (JoyStickInput.Up)
        {
            JumpAction();
            return;
        }
        if (JoyStickInput.Slide == true)
        {
            SlideAction();
            return;
        }
    }
    protected override void Run()
    {
        base.Run();
        if (JoyStickInput.Up)
        {
            JumpAction();
            return;
        }
        if (JoyStickInput.Slide == true)
        {
            SlideAction();
            return;
        }
    }
    protected virtual void Jump()
    {
        if (rigidbody2D.velocity.y < 0)
        {
            animator.Play("JumpDown");
        }
        Landing();

        if (JoyStickInput.Right)
        {
            MoveRight();
            return;
        }
        if (JoyStickInput.Left)
        {
            MoveLeft();
            return;
        }
    }
    protected virtual void Slide()
    {
        if (JoyStickInput.Slide == false)
            ReturnIdle();
    }
    protected virtual void Landing()
    {
        if (rigidbody2D.velocity.y == 0)
        {
            JoyStickInput.Glide = false;
            ReturnIdle();
            rigidbody2D.gravityScale = 1f;
        }
    }
    protected virtual void SlideAction()
    {
        currentState = State.SLIDE;
        animator.Play("Slide");
        if (transform.eulerAngles.y == 180)
            rigidbody2D.velocity = new Vector2(-2 * speed, rigidbody2D.velocity.y);
        else
            rigidbody2D.velocity = new Vector2(2 * speed, rigidbody2D.velocity.y);
        StartCoroutine(StopSliding());
    }
    IEnumerator StopSliding()
    {
        yield return new WaitForSeconds(0.5f);
        JoyStickInput.Slide = false;
        ReturnIdle();
    }
}
