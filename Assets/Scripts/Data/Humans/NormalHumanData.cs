using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Normal Human", menuName = "Humans/Normal Human")]
public class NormalHumanData : HumanData
{
    public HumanEvolution[] evolutions;

    public override GameObject ReturnPrefab(int level){
        return evolutions[level].prefab;
    }
}
