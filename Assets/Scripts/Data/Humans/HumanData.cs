using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanData : ScriptableObject
{
    public string humanName;

    public virtual GameObject ReturnPrefab(int level){
        //...
        Debug.LogWarning("Aquest classe no té prefab definit!");
        return null;
    }
}

[System.Serializable]
public class HumanEvolution{
    public int damage;
    public int atackRate;
    public int velocity;
    public int health;
    public int evolutionCost;
    public GameObject prefab;
}