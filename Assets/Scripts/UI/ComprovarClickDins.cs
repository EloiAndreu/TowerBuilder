using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ComprovarClickDins : MonoBehaviour, IPointerDownHandler
{
    RectTransform areaDinsClic; // Àrea fora dels botons d'UI.
    public GameObject uiObject; // UI que vols amagar.
    
    void Awake(){
        areaDinsClic = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Comprova si es fa clic a l'UI.
        if (RectTransformUtility.RectangleContainsScreenPoint(areaDinsClic, eventData.position))
        {
            //Debug.Log("Ha Clicat dinss");
            // No s'ha clicat a cap botó d'UI.
            //uiObject.SetActive(false); // Amaga l'UI.
        }
        else{
            //Debug.Log("Ha Clicat fora");
            uiObject.SetActive(false);
        }
    }
}
