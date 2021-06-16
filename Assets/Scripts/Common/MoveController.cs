using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class MoveController : MonoBehaviour
    {
    public float speed;
    
    // Start is called before the first frame update
    protected virtual void Move(Vector3 direction)
    {
        this.transform.position += direction * Time.deltaTime * speed;
    }
    protected virtual void MoveDown(Vector3 direction)
    {
        this.transform.position -= direction * Time.deltaTime * speed;
    }
   

}


