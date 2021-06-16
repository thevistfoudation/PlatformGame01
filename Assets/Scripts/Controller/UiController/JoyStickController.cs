using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using LTAUnityBase.Base.DesignPattern;


public class JoyStickController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Vector3 direction;
    public Vector3 posJoyStick;
    [SerializeField]
    Transform JoyStick;
    [SerializeField]
    Transform BgJoyStick;
    public static JoyStickController Instance;



    Vector3 OriginalPos;
    internal float y;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        OriginalPos = BgJoyStick.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        BgJoyStick.position = eventData.position;
        direction = Vector3.zero;

    }


    public void OnDrag(PointerEventData eventData)
    {
        MoveJoyStick(eventData.position);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        JoyStick.transform.localPosition = Vector3.zero;
        BgJoyStick.position = OriginalPos;
        posJoyStick = OriginalPos;
        direction = Vector3.zero;
    }

    void MoveJoyStick(Vector3 touchPos)
    {
        Vector2 offSet = touchPos - BgJoyStick.position;
        Vector3 realdirection = Vector2.ClampMagnitude(offSet, 70.0f);
        direction = realdirection.normalized;
        JoyStick.position = new Vector3(BgJoyStick.position.x + realdirection.x, BgJoyStick.position.y + realdirection.y);
        posJoyStick = JoyStick.localScale;
    }
    // Update is called once per frame
    void Update()
    {
        //imgJoyStick.color = Color.Lerp(imgJoyStick.color, CurrentColor, 0.5f);
        //ImBgJoyStick.color = Color.Lerp(ImBgJoyStick.color, CurrentColor, 0.5f);
    }
    private void Awake()
    {
        if (JoyStickController.Instance == null)
        {
            Instance = this;
        }
    }
}
public class JoyStick : SingletonMonoBehaviour<JoyStickController>
{

}

