using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButonFunctions : MonoBehaviour
{
    public void Info(){
        SelectManager.Instance.InfoOfConstruction();
    }

    public void ObjectOptions(){
        SelectManager.Instance.OpenOptionsMenu();
    }

    public void Upgrade(){
        SelectManager.Instance.UpgradeConstruction();
    }
}
