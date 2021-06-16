using LTAUnityBase.Base.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
public class KnightController : AdventrureController
{
    [SerializeField]
    ButtonController BtnAttack;
    [SerializeField]
    GameObject Slash;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        BtnAttack.OnClick((ButtonController btn) =>
        {
            //currentState = State.ATTACK;
            //animator.Play("Attack");
            JoyStickInput.Attack = true;
            Slash.SetActive(true);
        });
    }
    protected override void Update()
    {
        base.Update();
        switch (currentState)
        {         
            case State.ATTACK:
                Attack();
                break;
            case State.JUMPATTACK:
                JumpAttack();
                break;
        }
    }
   public void JumpAttack()
    {
        if (JoyStickInput.Attack == false)
        {
            currentState = State.JUMP;
            animator.Play("JumpUp");
        }
    }
    public void Attack()
    {
        if (JoyStickInput.Attack == false)
        { 
            ReturnIdle();
        }
    }
    public void EndAttack()
    {
        JoyStickInput.Attack = false;
        Slash.SetActive(false);
    }
    protected override void Idle()
    {
        base.Idle();
        if (JoyStickInput.Attack == true)
        {
            currentState = State.ATTACK;
            animator.Play("Attack");
            return;
        }
    }
    protected override void Jump()
    {
        base.Jump();
        if (JoyStickInput.Attack == true)
        {
            currentState = State.JUMPATTACK;
            animator.Play("JumpAttack");
            return;
        }
    }
    protected override void Run()
    {
        base.Run();
        if (JoyStickInput.Attack == true)
        {
            currentState = State.ATTACK;
            animator.Play("Attack");
            rigidbody2D.velocity = Vector2.zero;
            return;
        }
    }
}

