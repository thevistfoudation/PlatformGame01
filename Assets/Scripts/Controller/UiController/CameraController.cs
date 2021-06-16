using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    // Update is called once per frame

    void Update()
    {
        Transform playerTransform = Player.Instance.transform;
        Vector3 newPos = new Vector3(playerTransform.position.x, playerTransform.position.y, -10);
        this.transform.position = Vector3.Slerp(this.transform.position, newPos, 0.3f);
    }
}
