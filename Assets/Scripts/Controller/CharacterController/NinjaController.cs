//using LTAUnityBase.Base.UI;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using LTAUnityBase.Base.DesignPattern;

//public class NinjaController : MonoBehaviour
//{
//    Rigidbody2D rigidbody2D;
//    Animator animator;
//    SpriteRenderer spriteRenderer;
//    CircleCollider2D boxCollider2D;
//    [SerializeField]
//    float speed;
//    [SerializeField]
//    GameObject kunai;
//    [SerializeField]
//    Transform kunaiPos;
//    [SerializeField]
//    ButtonController BtnAttack, BtnThrow, BtnSlide, BtnGlide;
//    [SerializeField]
//    GameObject glide;
//    public enum State
//    {
//        IDLE,
//        RUN,
//        JUMP,
//        SLIDE,
//        CLIMB,
//        GLIDE,
//        ATTACK,
//        THROW,
//        JUMPATTACK,
//        JUMPTHROW
//    }
//    State currentState = State.IDLE;

//    private void Start()
//    {
//        rigidbody2D = GetComponent<Rigidbody2D>();
//        animator = GetComponent<Animator>();
//        spriteRenderer = GetComponent<SpriteRenderer>();
//        boxCollider2D = GetComponent<CircleCollider2D>();
//        BtnAttack.OnClick((ButtonController btn) =>
//        {
//            //currentState = State.ATTACK;
//            //animator.Play("Attack");
//            JoyStickInput.Attack = true;
//        });
//        BtnThrow.OnClick((ButtonController btn) =>
//        {
//            JoyStickInput.Throw = true;
//        });
//        BtnSlide.OnClick((ButtonController btn) =>
//        {
//            JoyStickInput.Slide = true;
//        });
//        BtnGlide.OnClick((ButtonController btn) =>
//        {
//            JoyStickInput.Glide = true;

//        });
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        switch (currentState)
//        {
//            case State.IDLE:
//                Idle();
//                break;
//            case State.RUN:
//                Run();
//                break;
//            case State.JUMP:
//                Jump();
//                break;
//            case State.SLIDE:
//                Slide();
//                break;
//            case State.GLIDE:
//                Glide();
//                break;
//            case State.CLIMB:
//                Climb();
//                break;
//            case State.ATTACK:
//                Attack();
//                break;
//            case State.JUMPATTACK:
//                JumpAttack();
//                break;
//            case State.THROW:
//                Throw();
//                break;
//            case State.JUMPTHROW:
//                JumpThrow();
//                break;
//        }
//    }
//    void MoveLeft()
//    {
//        rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
//        transform.eulerAngles = new Vector3(0, 180, 0);
//    }
//    void MoveRight()
//    {
//        rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
//        transform.eulerAngles = new Vector3(0, 0, 0);
//    }
//    void JumpAction()
//    {
//        currentState = State.JUMP;
//        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 8);
//        animator.Play("JumpUp");
//        glide.SetActive(true);
//    }

//    void SlideAction()
//    {
//        currentState = State.SLIDE;
//        animator.Play("Slide");
//        if (transform.eulerAngles.y == 180)
//            rigidbody2D.velocity = new Vector2(-2 * speed, rigidbody2D.velocity.y);
//        else
//            rigidbody2D.velocity = new Vector2(2 * speed, rigidbody2D.velocity.y);
//        StartCoroutine(StopSliding());
//    }
//    void ReturnIdle()
//    {
//        currentState = State.IDLE;
//        rigidbody2D.velocity = Vector3.zero;
//        animator.Play("Idle");
//        glide.SetActive(false);
//    }
//    void Landing()
//    {
//        if (rigidbody2D.velocity.y == 0)
//        {
//            JoyStickInput.Glide = false;
//            ReturnIdle();
//            rigidbody2D.gravityScale = 1f;
//        }
//    }
//    public void EndAttack()
//    {
//        JoyStickInput.Attack = false;

//    }
//    public void ThrowKunai()
//    {
//        Instantiate(kunai, kunaiPos.position, kunaiPos.rotation);
//    }
//    public void EndThrow()
//    {
//        JoyStickInput.Throw = false;

//    }
//    IEnumerator StopSliding()
//    {
//        yield return new WaitForSeconds(0.5f);
//        JoyStickInput.Slide = false;
//        ReturnIdle();
//    }


//    void Idle()
//    {
//        if (JoyStickInput.Left)
//        {
//            currentState = State.RUN;
//            MoveRight();
//            animator.Play("Run");
//            return;
//        }
//        if (JoyStickInput.Right)
//        {
//            currentState = State.RUN;
//            MoveLeft();
//            animator.Play("Run");
//            return;
//        }

//        if (JoyStickInput.Up)
//        {
//            JumpAction();
//            return;
//        }
//        if (JoyStickInput.Slide == true)
//        {
//            SlideAction();
//            return;
//        }
//        if (JoyStickInput.Attack == true)
//        {
//            currentState = State.ATTACK;
//            animator.Play("Attack");
//            return;
//        }
//        if (JoyStickInput.Throw == true)
//        {
//            currentState = State.THROW;
//            animator.Play("Throw");
//            return;
//        }
//    }
//    void Run()
//    {
//        if (JoyStickInput.Attack == true)
//        {
//            currentState = State.ATTACK;
//            animator.Play("Attack");
//            rigidbody2D.velocity = Vector2.zero;
//            return;
//        }
//        if (JoyStickInput.Slide == true)
//        {
//            SlideAction();
//            return;
//        }
//        if (JoyStickInput.Up)
//        {
//            JumpAction();
//            return;
//        }
//        if (JoyStickInput.Right)
//        {
//            MoveRight();
//            return;
//        }
//        if (JoyStickInput.Left)
//        {
//            MoveLeft();
//            return;
//        }
//        ReturnIdle();
//    }
//    void Jump()
//    {
//        if (JoyStickInput.Attack == true)
//        {
//            currentState = State.JUMPATTACK;
//            animator.Play("JumpAttack");
//            return;
//        }
//        if (JoyStickInput.Throw == true)
//        {
//            currentState = State.JUMPTHROW;
//            animator.Play("JumpThrow");
//            return;
//        }
//        if (JoyStickInput.Glide == true)
//        {
//            glide.SetActive(false);
//            currentState = State.GLIDE;
//            rigidbody2D.gravityScale = 0.5f;
//            animator.Play("Glide");
//            return;
//        }
//        if (rigidbody2D.velocity.y < 0)
//        {
//            animator.Play("JumpDown");
//        }
//        Landing();

//        if (JoyStickInput.Right)
//        {
//            MoveRight();
//            return;
//        }
//        if (JoyStickInput.Left)
//        {
//            MoveLeft();
//            return;
//        }

//    }
//    void Slide()
//    {
//        //if (currentState == State.JUMP)
//        //{
//        //    EndAttack();
//        //}
//        if (JoyStickInput.Slide == false)
//            ReturnIdle();
//    }
//    void Glide()
//    {
//        if (JoyStickInput.Glide == false)
//            ReturnIdle();
//        Landing();
//        if (JoyStickInput.Right)
//        {
//            MoveRight();
//            return;
//        }
//        if (JoyStickInput.Left)
//        {
//            MoveLeft();
//            return;
//        }
//    }
//    void Climb()
//    {

//    }
//    void Attack()
//    {
//        if (JoyStickInput.Attack == false)
//        {
//            ReturnIdle();
//        }
//    }

//    void JumpAttack()
//    {
//        if (JoyStickInput.Attack == false)
//        {
//            currentState = State.JUMP;
//            animator.Play("JumpUp");
//        }
//    }
//    public void Throw()
//    {
//        if (JoyStickInput.Throw == false)
//            ReturnIdle();
//    }
//    public void JumpThrow()
//    {
//        if (JoyStickInput.Throw == false)
//        {
//            currentState = State.JUMP;
//            animator.Play("JumpUp");
//        }
//    }
//}
//public class Player : SingletonMonoBehaviour<NinjaController>
//{

//}