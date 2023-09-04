using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wizzard", menuName = "Humans/Wizzard")]
public class WizardData : HumanData
{
    public WizzardEvolution[] evolutions;

    public override GameObject ReturnPrefab(int level){
        return evolutions[level].prefab;
    }
}

[System.Serializable]
public class WizzardEvolution : HumanEvolution{
    public int fireRange;
    public int fireRate;
}
