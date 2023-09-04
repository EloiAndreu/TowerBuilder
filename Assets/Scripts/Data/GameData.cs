using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Map{
    public int width, height;
    [HideInInspector]
    public GridElement[,] gridElements;

    //Constructor amb paràmetres
    public Map(int x, int y){
        this.width = x;
        this.height = y;

        gridElements = new GridElement[width, height];

        for(int i=0; i<width; i++){
            for(int j=0; j<height; j++){
                gridElements[i, j] = new GridElement(i, j, "Land", 0);
            }
        }

        //gridElements = new GridElement[x, y];
    }

    //Obtenir un element del mapa
    public GridElement GetElement(int x, int y){
        if(x >= 0 && x < width && y >= 0 && y < height){
            return gridElements[x, y];
        }
        else{
            Debug.LogError("Posició fora dels límits del mapa, x: " + x + " y: " + y);
            return new GridElement();
        }
    }

    //Determinar un element del mapa
    public void SetElement(int x, int y, GridElement element){
        if(x >= 0 && x < width && y >= 0 && y < height){
            gridElements[x, y] = element;
        }
        else{
            Debug.LogError("Posició fora dels límits del mapa, x: " + x + " y: " + y);
        }
    }
}




public class GridElement{
    public int x, y;
    public string type;
    public int level;

    //Constructor per defecte
    public GridElement(){
        this.x = this.y = -1;
        this.type = "Land";
        this.level = 0;
    }

    //Constructor per paràmetres
    public GridElement(int x, int y, string type, int level){
        this.x = x;
        this.y = y;
        this.type = type;
        this.level = level;
    }
    
    /*
    public void IntanceElement(){
        ConstructionData[] scriptableObjects = Resources.LoadAll<ConstructionData>("Data");

        for(int i=0; i<scriptableObjects.Length; i++){
            if(this.type == scriptableObjects[i].constructionName){
                Instantiate(scriptableObjects[i].evolutions[this.level].prefab, new Vector3(x, 0f, y), Quaternion.Identity);
            }
        }
    }
    */
    
}
