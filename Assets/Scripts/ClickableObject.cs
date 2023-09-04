using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickableObject : MonoBehaviour
{
    public UnityEvent provaEvent;
    public SelectedData uiButtons;

    void Update()
    {
        ComprovarClickRatoli();
        ComprovarClickDit();
    }

    void ComprovarClickDit(){
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);

            // Determinem si s'ha tocat l'objecte
            if (Physics.Raycast(ray, out RaycastHit hit)){
                if (hit.collider.gameObject == gameObject){
                    OnObjectClicked();
                }
                else{
                    SelectManager.Instance.DisableSelection();
                }
            }
        }
    }

    void ComprovarClickRatoli(){
        if (Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit)){
                if (hit.collider.gameObject == gameObject){
                    OnObjectClicked();
                }
            }
        }
    }

    void OnObjectClicked(){
        provaEvent.Invoke();

        SelectManager.Instance.ActiveSelection(uiButtons, gameObject);
    }
}
