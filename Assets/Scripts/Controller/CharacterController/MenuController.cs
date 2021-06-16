using LTAUnityBase.Base.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    ButtonController Ninja, Kunoichi, Robot, CowBoi, Knight, CowGirl;
    public GameObject ninja;
    public GameObject kunoichi;
    public GameObject robot;
    public GameObject cowboi;
    public GameObject knight;
    public GameObject cowGirl;
    public GameObject Panell;
    public GameObject Throw;
    public GameObject Slide;
    public GameObject Glide;
    public GameObject Attack;
    public GameObject Throww;

  
    // Start is called before the first frame update
    void Start()
    {
        Ninja.OnClick((ButtonController btn) =>
        {
            ninja.SetActive(true);
            PanelOff();
        });
        Kunoichi.OnClick((ButtonController btn) =>
        {
            kunoichi.SetActive(true);
            PanelOff();
        });
        Robot.OnClick((ButtonController btn) =>
        {
            robot.SetActive(true);
            PanelOff();
        });
        CowBoi.OnClick((ButtonController btn) =>
        {
            cowboi.SetActive(true);
            PanelOff();
            Attack.SetActive(false);
            Throww.SetActive(false);
        });
        Knight.OnClick((ButtonController btn) =>
        {
            knight.SetActive(true);
            PanelOff();
            Slide.SetActive(false);
            Throww.SetActive(false);
        });
        CowGirl.OnClick((ButtonController btn) =>
        {
            cowGirl.SetActive(true);
            PanelOff();
            Slide.SetActive(false);
            Throww.SetActive(false);
        });

    }
    public void PanelOff()
    {
        Panell.SetActive(false);
    }
}
