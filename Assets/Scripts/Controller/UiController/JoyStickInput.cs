using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickInput : MonoBehaviour
{
    public static bool Left
    {
        get
        {
            return JoyStick.Instance.direction.x < -0.1f;
        }
    }
    public static bool Right
    {
        get
        {
            return JoyStick.Instance.direction.x > 0.1f;
        }
    }
    public static bool Up
    {
        get
        {
            return JoyStick.Instance.direction.y > 0.1f;
        }
    }
    public static bool Attack = false;
    public static bool Throw = false;
    public static bool Glide = false;
    public static bool Slide = false;
}
