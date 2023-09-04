using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ajuntament", menuName = "Constructions/Ajuntament")]
public class AjuntamentTowerConstruction : ConstructionData
{
    public AjuntamentEvolution[] evolutions;

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
public class AjuntamentEvolution : Evolution{
    public int people;
    public int constructions;
}
