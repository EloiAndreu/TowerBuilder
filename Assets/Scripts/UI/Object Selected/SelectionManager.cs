using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance;

    public GameObject uiSelection;
    GameObject upgradeButton;
    GameObject removeButton;

    public GameObject lastConstructionSelected;

    void Awake(){
        Instance = this;
    }

    void Start(){
        upgradeButton = uiSelection.transform.GetChild(0).gameObject;
        removeButton = uiSelection.transform.GetChild(1).gameObject;
        uiSelection.SetActive(false);
    }

    public void AvtiveSelection(GameObject obj){
        if(obj.tag == "Construction"){
            lastConstructionSelected = obj;

            ConstructionData data = obj.GetComponent<ObjectData>().data;
            //if(data is AttackTowerConstruction){
                //AttackTowerConstruction newData = (AttackTowerConstruction)data;
                int currentLevel = obj.GetComponent<ObjectData>().currentLevel;
                if(data.NumEvolutions()-1 == currentLevel ){
                    upgradeButton.SetActive(false);
                }
                else{
                    int difDeCost = CoinsManager.Instance.currentCoins - data.GetBuildCost(currentLevel+1);
                    if(difDeCost >= 0){
                        upgradeButton.SetActive(true);
                    }
                    else upgradeButton.SetActive(false);
                }
            //}

            Vector3 posicioUI = Camera.main.WorldToScreenPoint(obj.transform.position);
            uiSelection.transform.position = posicioUI;
            uiSelection.SetActive(true);
        }
    }

    public void RemoveConstruction(){
        ObjectData data = lastConstructionSelected.GetComponent<ObjectData>();
        CoinsManager.Instance.AddCoins(data.data.GetSellCost(data.currentLevel));
        Destroy(lastConstructionSelected);
        uiSelection.SetActive(false);
    }

    public void UpgradeConstruction(){
        ObjectData data = lastConstructionSelected.GetComponent<ObjectData>();
        //Debug.Log(data.currentLevel);

        bool tenimProusCoins = CoinsManager.Instance.RemoveCoins(data.data.GetBuildCost(data.currentLevel+1));
        if(tenimProusCoins){
            GameObject newConstruction = data.data.ReturnPrefab(data.currentLevel+1);

            Instantiate(newConstruction, lastConstructionSelected.transform.position, Quaternion.identity);
            Destroy(lastConstructionSelected);
        }
        
        uiSelection.SetActive(false);
    }
}
