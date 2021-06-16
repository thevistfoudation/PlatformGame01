using LTAUnityBase.Base.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class EnemyController : MonoBehaviour
{


    Rigidbody2D rigidbody2D;
    Animator animator;
    SpriteRenderer spriteRenderer;
    CircleCollider2D boxCollider2D;
    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
        transform.eulerAngles = new Vector3(0, 180, 0);
    }
}