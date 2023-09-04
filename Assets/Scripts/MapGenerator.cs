using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject mapParent;
    public GameObject landPrefab;
    public ConstructionData[] scriptableObjects;

    //A partir d'un mapa, generem instancies cada ConstructionData prefab
    public void GenerateMap(Map map){
        scriptableObjects = Resources.LoadAll<ConstructionData>("Data");
        
        //Per cada element del mapa...
        for(int i=0; i<map.width; i++){
            for(int j=0; j<map.height; j++){
                
                //Obtenim l'element
                GridElement gridElement = map.gridElements[i, j];

                int level = gridElement.level;
                string type = gridElement.type;
                int x = gridElement.x;
                int y = gridElement.y;

                if(type=="Land"){ //En cas que sigui Land (null)...
                    GameObject land = Instantiate(landPrefab, new Vector3(x, landPrefab.transform.position.y, y), Quaternion.identity, mapParent.transform);
                    land.GetComponent<ObjectData>().x = x;
                    land.GetComponent<ObjectData>().y = y;
                }
                else{
                    for(int k=0; k<scriptableObjects.Length; k++){

                        if(type == scriptableObjects[i].constructionName){
                            GameObject prefab = scriptableObjects[i].ReturnPrefab(level);
                            if(prefab != null){
                                Instantiate(prefab, new Vector3(x, 0f, y), Quaternion.identity);
                            }
                        }
                    }
                }
            }
        }
    }
}
