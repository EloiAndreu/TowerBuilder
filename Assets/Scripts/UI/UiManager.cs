using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    public GameObject[] uiPanels;
    public GameObject[] mainSceneElements;

    void Awake(){
        Instance = this;
    }

    public void ShowUI(int uiKey){
        HideAllUI();
        uiPanels[uiKey].SetActive(true);
    }

    public void HideAllUI(){
        for(int i=0; i<uiPanels.Length; i++){
            uiPanels[i].SetActive(false);
        } 
    }

    public void HideUI(int uiKey){
        uiPanels[uiKey].SetActive(false);
    }

    public void HideAllMainSceneElements(){
        for(int i=0; i<mainSceneElements.Length; i++){
            mainSceneElements[i].SetActive(false);
        } 
    }

    public void ShowAllMainSceneElements(){
        for(int i=0; i<mainSceneElements.Length; i++){
            mainSceneElements[i].SetActive(true);
        } 
    } 

    
}
