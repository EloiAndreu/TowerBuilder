using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectData : MonoBehaviour
{
    //TOTA LA INFO DE L'OBJECTE INSTANCIAT
    //currentLevel depén unicament de l'intancia, NO de l'scriptableObject
    
    public ConstructionData data;
    public int currentLevel = 0;
    public int x=-1, y=-1;
    public int uiMenuKey = -1;

    public void OpenUiMenu(){
        if(uiMenuKey != -1){
            UiManager.Instance.ShowUI(uiMenuKey);
            SelectManager.Instance.EnableSelection(false);
            UiManager.Instance.HideAllMainSceneElements();
        }
    }

    public void CloseUiMenu(){
        if(uiMenuKey != -1){
            UiManager.Instance.HideUI(uiMenuKey);
            SelectManager.Instance.EnableSelection(true);
            UiManager.Instance.ShowAllMainSceneElements();
        }
    }
}
