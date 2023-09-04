using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Construction")]
public class ConstructionData : ScriptableObject
{
    public string constructionName;
    public GameObject previsualizePrefab;

    public virtual GameObject ReturnPrefab(int level){
        //...
        Debug.LogWarning("Aquest classe no té prefab definit!");
        return null;
    }

    public virtual int NumEvolutions(){
        //...
        Debug.LogWarning("Aquest classe no té prefab definit!");
        return -1;
    }

    
    public virtual int GetBuildCost(int level){
        Debug.LogWarning("Aquest classe no té prefab definit!");
        return -1;
    }

    public virtual int GetSellCost(int level){
        Debug.LogWarning("Aquest classe no té prefab definit!");
        return -1;
    }
    
}

[System.Serializable]
public class Evolution{
    //public int level;
    public int buildCost;
    public int sellCost;
    //public float timeToBuild;
    public GameObject prefab;
}


/*
[CreateAssetMenu(fileName = "New Attack Tower", menuName = "Constructions/AttackTower")]
public class AttackTowerConstruction : ConstructionData {
    public AttackEvolution[] evolutions;

    public override GameObject ReturnPrefab(int level){
        return evolutions[level].prefab;
    }
}


[CreateAssetMenu(fileName = "New Recources Tower", menuName = "Constructions/RecourcesTower")]
public class RecourcesTowerConstruction : ConstructionData {
    public RecourcesEvolution[] evolutions;

    public override GameObject ReturnPrefab(int level){
        return evolutions[level].prefab;
    }
}
*/

/*
[System.Serializable]
public class AttackEvolution : Evolution{
    public float damage;
    public float range;
    public float attackVelocity;
}


[System.Serializable]
public class RecourcesEvolution : Evolution{
    public float extractVelocity;
}
*/