using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * 50;    
    }

    int timeCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (timeCount == 100)
        {
            Destroy(this.gameObject);
            return;
        }
        timeCount++;
    }
}
