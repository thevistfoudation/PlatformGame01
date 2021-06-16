using LTAUnityBase.Base.DesignPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapsController : MonoBehaviour
{
    public GameObject TileMap0;
    // Start is called before the first frame update
    public void TurnDown()
    {
        TileMap0.GetComponent<Transform>().localScale = new Vector3(1, -1, 1);
    }
    public void TurnUp()
    {
        TileMap0.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
    }

   
}
public class TileMaps : SingletonMonoBehaviour<TileMapsController>
{

}
