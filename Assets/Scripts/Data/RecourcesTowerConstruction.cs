using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recources Tower", menuName = "Constructions/RecourcesTower")]
public class RecourcesTowerConstruction : ConstructionData
{
    public RecourcesEvolution[] evolutions;

    public override GameObject ReturnPrefab(int level){
        return evolutions[level].prefab;
    }

    public override int NumEvolutions(){
        return evolutions.Length;
    }
}

[System.Serializable]
public class RecourcesEvolution : Evolution{
    public float extractVelocity;
}
