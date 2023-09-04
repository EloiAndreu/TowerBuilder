using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Ui Buttons", menuName = "Ui/Selection Buttons")]
public class SelectedData : ScriptableObject
{
    public string uiName;
    public GameObject[] buttons;
}
