using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack Tower", menuName = "Constructions/AttackTower")]
public class AttackTowerConstruction : ConstructionData
{
    public AttackEvolution[] evolutions;

    public override GameObject ReturnPrefab(int level){
        return evolutions[level].prefab;
    }

    public override int NumEvolutions(){
        return evolutions.Length;
    }

    public override int GetBuildCost(int level){
        return evolutions[level].buildCost;
    }

    public override int GetSellCost(int level){
        return evolutions[level].sellCost;
    }
}

[System.Serializable]
public class AttackEvolution : Evolution{
    public float damage;
    public float range;
    public float attackVelocity;
}
