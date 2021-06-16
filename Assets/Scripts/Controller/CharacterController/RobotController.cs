using LTAUnityBase.Base.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
public class RobotController : KnightController
{
    [SerializeField]
    GameObject kunai;
    [SerializeField]
    Transform kunaiPos;
    [SerializeField]
    ButtonController BtnThrow;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        BtnThrow.OnClick((ButtonController btn) =>
        {
            JoyStickInput.Throw = true;
        });
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        switch (currentState)
        {
            case State.THROW:
                Throw();
                break;
            case State.JUMPTHROW:
                JumpThrow();
                break;
        }
    }
    public void ThrowKunai()
    {
        Instantiate(kunai, kunaiPos.position, kunaiPos.rotation);
    }
    public void EndThrow()
    {
        JoyStickInput.Throw = false;

    }
    public void Throw()
    {
        if (JoyStickInput.Throw == false)
            ReturnIdle();
    }
    public void JumpThrow()
    {
        if (JoyStickInput.Throw == false)
        {
            currentState = State.JUMP;
            animator.Play("JumpUp");
        }
    }
    protected override void Idle()
    {
        base.Idle();
        if (JoyStickInput.Throw == true)
        {
            currentState = State.THROW;
            animator.Play("Throw");
            return;
        }
    }
    protected override void Jump()
    {
        base.Jump();
        if (JoyStickInput.Throw == true)
        {
            currentState = State.JUMPTHROW;
            animator.Play("JumpThrow");
            return;
        }
    }
    protected override void Run()
    {
        base.Run();
    }
}
