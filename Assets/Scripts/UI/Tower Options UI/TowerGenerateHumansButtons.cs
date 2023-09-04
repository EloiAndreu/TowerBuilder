using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerateHumansButtons : MonoBehaviour
{
    public GameObject buttonPrefab;
    Dictionary<HumanData, int> currentHumansInTown;
    Dictionary<HumanData, int> currentHumansInTower;

    public Transform buttonsParent;
    bool teButtons = false;

    void Update(){
        if(gameObject.activeSelf){
            if(!teButtons){
                teButtons = true;
                OpenTowerOptionsMenu();
            }
        }
        else teButtons = false;
    }

    public void OpenTowerOptionsMenu(){
        currentHumansInTown = HumansManager.Instance.GetHumanTypes();
        GenerateHumanButtons();
    }

    public void GenerateHumanButtons(){
        Debug.Log(currentHumansInTown.Count);
        for(int i=0; i<currentHumansInTown.Count; i++){
            Instantiate(buttonPrefab, buttonsParent);
        }
    }

    public void AddHumanInTower(){
        Debug.Log("Has Afegit un Humà a la Torre");
    }
}
