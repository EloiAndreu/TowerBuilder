using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickableCard : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    RectTransform rectTransform;
    CanvasGroup canvasGroup;
    Vector2 originalPosition;
    VerticalLayoutGroup verticalLayoutGroup;
    HorizontalLayoutGroup horizontalLayoutGroup;

    public ConstructionData constructionData;
    GameObject prefabSelected;

    Vector3 towerPosition;
    int x, y;
    //bool cartaPosada = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        verticalLayoutGroup = transform.parent.GetComponent<VerticalLayoutGroup>();
        if(verticalLayoutGroup == null){
            horizontalLayoutGroup = transform.parent.GetComponent<HorizontalLayoutGroup>();
        }

        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; // Fer la carta més transparent quan es comença a arrossegar
        canvasGroup.blocksRaycasts = false; // Permetre interactuar amb altres objectes que estiguin darrere de la carta
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta; // Moure la carta segons el desplaçament del ratolí o el dit
        
        Vector3 inputPosition;
        if (Input.touchCount > 0){
            inputPosition = Input.GetTouch(0).position;
        }
        else{
            inputPosition = Input.mousePosition;
        }

        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject.tag == "Land"){
                AmagarCarta_MostrarCostruccio();

                //Obtenir pos x i y
                x = hit.collider.gameObject.GetComponent<ObjectData>().x;
                y = hit.collider.gameObject.GetComponent<ObjectData>().y;
                //Debug.Log("x: " + x + " y: " + y);

                if(!GameManager.Instance.HiHaElement(x, y)){
                    //Generem la instancia de previsualització
                    towerPosition = hit.collider.gameObject.transform.position;
                    if(prefabSelected == null){
                        prefabSelected = Instantiate(constructionData.previsualizePrefab, towerPosition, Quaternion.identity);
                    }
                    else prefabSelected.transform.position = towerPosition;  
                }   
                           
            }
            else{
                MostrarCarta_AmagarCostruccio();
                Destroy(prefabSelected);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        MostrarCarta_AmagarCostruccio();
        canvasGroup.alpha = 1f; // Tornar a la transparència original quan es deixa d'arrossegar
        canvasGroup.blocksRaycasts = true; // Tornar a bloquejar la interacció amb altres objectes

        if(verticalLayoutGroup != null){
            verticalLayoutGroup.enabled = false;
            rectTransform.anchoredPosition = originalPosition; // Tornar la carta a la seva posició original si no es solta sobre una àrea d'acceptació
            verticalLayoutGroup.enabled = true;
        }
        else{
            horizontalLayoutGroup.enabled = false;
            rectTransform.anchoredPosition = originalPosition; // Tornar la carta a la seva posició original si no es solta sobre una àrea d'acceptació
            horizontalLayoutGroup.enabled = true;
        }
        
        if(prefabSelected != null && !GameManager.Instance.HiHaElement(x, y)){
            bool tenimProusCoins = CoinsManager.Instance.RemoveCoins(constructionData.GetBuildCost(0));
            if(tenimProusCoins){

                //Afegir la construccio al Map
                //Debug.Log("x: " + x + " y: " + y);
                GameManager.Instance.SetGridElement(x, y, constructionData);
                
                //Generem instància definitiva
                GameObject construction = Instantiate(constructionData.ReturnPrefab(0), prefabSelected.transform.position, Quaternion.identity);

            }
            Destroy(prefabSelected);
        }

        prefabSelected = null;
    }

    void AmagarCarta_MostrarCostruccio(){
        canvasGroup.alpha = 0f;
        
    }

    void MostrarCarta_AmagarCostruccio(){
        canvasGroup.alpha = 0.6f;
    }
}

