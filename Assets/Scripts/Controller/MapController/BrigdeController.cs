using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrigdeController : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.05f;
    }
    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Left")
        //{
        //    this.transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
        //    Debug.Log("va chạm");
        //}
        //if (collision.gameObject.tag == "Right")
        //{
        //    this.transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * speed;
        //    Debug.Log("va chạm lần 1");
        //}
    }
}
