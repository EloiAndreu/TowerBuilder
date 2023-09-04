using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HumansManager : MonoBehaviour
{
    public static HumansManager Instance;
    public int maxHumans = 3;
    //public int currentHumans = 0;

    public List<HumanData> currentHumans;

    public TextMeshProUGUI scoreText;

    void Awake(){
        Instance = this;
    }

    void Update(){
        scoreText.text = "HUMANS: " + currentHumans.Count.ToString() + " / " + maxHumans.ToString();
    }

    public bool AddHuman(HumanData human){
        if(currentHumans.Count>=maxHumans){
            return false;
        }
        else{
            currentHumans.Add(human);
            return true;
        }
    }

    public Dictionary<HumanData, int> GetHumanTypes(){
        Dictionary<HumanData, int> currentHumanTypes = new Dictionary<HumanData, int>();
        for(int i=0; i<currentHumans.Count; i++){
            if(currentHumanTypes.ContainsKey(currentHumans[i])){
                currentHumanTypes[currentHumans[i]]++;
            }
            else currentHumanTypes[currentHumans[i]]=1;
        }

        return currentHumanTypes;
    }

    /*
    public void RemoveHuman(){
        if(currentHumans.Count<=0){
            Debug.LogWarning("No pots eliminar si no queda cap HUMAN");
            return;
        }
        else currentHumans--;
    }
    */
}
