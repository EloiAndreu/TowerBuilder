using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int dimensionX, dimensionY;
    public int initialCoins;
    public Map map;

    void Awake(){
        Instance = this;
    }

    void Start(){
        map = new Map(dimensionX, dimensionY);
        MapGenerator mapGenerator = GetComponent<MapGenerator>();
        mapGenerator.GenerateMap(map);
        CoinsManager.Instance.SetCoins(initialCoins);

        UiManager.Instance.HideAllUI();
        UiManager.Instance.ShowAllMainSceneElements();
    }

    public void SetGridElement(int x, int y, ConstructionData data){
        string type = data.constructionName;
        GridElement gridElement = new GridElement(x, y, type, 0);
        map.SetElement(x, y, gridElement);
        //Debug.Log("Element afegit al mapa");
    }

    public bool HiHaElement(int x, int y){
        GridElement gridElement = map.GetElement(x, y);
        //Debug.Log(gridElement.type);
        if(gridElement.type != "Land") return true;
        else return false;
    }
}
