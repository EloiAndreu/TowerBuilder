using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    public static SelectManager Instance;
    public GameObject uiSelection;
    public GameObject lastConstructionSelected;

    void Awake(){
        Instance = this;
    }

    void Start(){
        uiSelection.SetActive(false);
        RemoveAllChildren(uiSelection.transform);
    }

    public void ActiveSelection(SelectedData data, GameObject obj){
        if(obj.tag == "Construction") lastConstructionSelected = obj;
        else {
            DisableSelection();
            return;
        }

        RemoveAllChildren(uiSelection.transform);
        for(int i=0; i<data.buttons.Length; i++){
            Instantiate(data.buttons[i], uiSelection.transform);
        }
        
        if(Camera.main.GetComponent<CameraController>().enfocat == false){
            uiSelection.SetActive(true);
        }
        else OpenOptionsMenu();

    }

    public void DisableSelection(){
        if(Camera.main.GetComponent<CameraController>().enfocat == false){
            RemoveAllChildren(uiSelection.transform);
        }
    }

    void RemoveAllChildren(Transform parent)
    {
        int childCount = parent.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            Transform child = parent.GetChild(i);
            Destroy(child.gameObject);
        }
    }

    public void InfoOfConstruction(){
        Debug.Log("Estas mostrant informació");
    }

    public void CloseOptionsMenu(){
        Camera.main.gameObject.GetComponent<CameraController>().CameraDesenfocarObjecte();
        lastConstructionSelected.GetComponent<ObjectData>().CloseUiMenu();
    }

    public void OpenOptionsMenu(){
        Camera.main.gameObject.GetComponent<CameraController>().CameraEnfocarObjecte(lastConstructionSelected.transform);
        lastConstructionSelected.GetComponent<ObjectData>().OpenUiMenu();
    }

    public void UpgradeConstruction(){
        ObjectData data = lastConstructionSelected.GetComponent<ObjectData>();
        //Debug.Log(data.currentLevel);

        bool tenimProusCoins = CoinsManager.Instance.RemoveCoins(data.data.GetBuildCost(data.currentLevel+1));
        if(tenimProusCoins){
            GameObject newConstruction = data.data.ReturnPrefab(data.currentLevel+1);

            Instantiate(newConstruction, lastConstructionSelected.transform.position, Quaternion.identity);
            Destroy(lastConstructionSelected);
        }
        
        uiSelection.SetActive(false);
    }

    public void RemoveConstruction(){
        ObjectData data = lastConstructionSelected.GetComponent<ObjectData>();
        CoinsManager.Instance.AddCoins(data.data.GetSellCost(data.currentLevel));
        Destroy(lastConstructionSelected);
        uiSelection.SetActive(false);
    }

    public void EnableSelection(bool enabled){
        uiSelection.SetActive(enabled);
    }

}
