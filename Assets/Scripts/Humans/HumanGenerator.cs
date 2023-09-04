using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanGenerator : MonoBehaviour
{
    public HumanData humanType;
    public Transform humansParent;

    public void GenerateHuman(){
        GameObject prefab = humanType.ReturnPrefab(0);
        bool canAddHuman = HumansManager.Instance.AddHuman(humanType);
        if(canAddHuman){
            GameObject human = Instantiate(prefab, humansParent);
        }
    }
}
