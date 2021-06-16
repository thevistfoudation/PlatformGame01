using LTAUnityBase.Base.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class Ninja1Controller : RobotController
{
    [SerializeField]
    ButtonController BtnGlide;
    [SerializeField]
    GameObject glide;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        BtnGlide.OnClick((ButtonController btn) =>
        {
            JoyStickInput.Glide = true;

        });
    }

    // Update is called once per frame
   protected override void Update()
    {
        base.Update();
        switch (currentState)
        {
            case State.GLIDE:
                Glide();
                break;
        }
    }
    void Glide()
    {
        if (JoyStickInput.Glide == false)
            ReturnIdle();
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
    protected override void Jump()
    {
        base.Jump();
        if (JoyStickInput.Glide == true)
        {
            glide.SetActive(false);
            currentState = State.GLIDE;
            rigidbody2D.gravityScale = 0.5f;
            animator.Play("Glide");
            return;
        }
        if (rigidbody2D.velocity.y < 0)
        {
            animator.Play("JumpDown");
        }
        Landing();
      }
    protected override void ReturnIdle()
    {
        base.ReturnIdle();
        glide.SetActive(false);
    }
    protected override void Landing()
    {
        if (rigidbody2D.velocity.y == 0)
        {
            JoyStickInput.Glide = false;
            ReturnIdle();
            rigidbody2D.gravityScale = 1f;
        }
    }
    protected override void JumpAction()
    {
        base.JumpAction();
        glide.SetActive(true);
    }
}
