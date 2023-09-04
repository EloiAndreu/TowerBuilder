using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera mainCamera; // Referència a la càmera principal
    Vector3 initialPosition, lastPosition;
    Transform targetObject; // L'objecte que vols enfocar
    public  Vector3 targetPosition;
    public float focusSpeed = 5f; // Velocitat de desplaçament cap a l'objecte
    public float minOrthographicSize = 3f; // Mida mínima de la càmera
    float initialOrthographicSize = 6f;

    private bool isFocusing = false;
    public bool enfocat = false;

    void Awake(){
        mainCamera = Camera.main;
        initialPosition = mainCamera.transform.position;
        initialOrthographicSize = mainCamera.orthographicSize;
        lastPosition = initialPosition;
    }

    public void CameraEnfocarObjecte(Transform obj){
        targetObject = obj;
        if (!isFocusing){
            StartCoroutine(FocusCoroutine());
        }
    }

    public void CameraDesenfocarObjecte(){
        lastPosition = transform.position;
        if(!isFocusing){
            StartCoroutine(UnfocusCoroutine());
        }
    }

    IEnumerator FocusCoroutine2(){
        isFocusing = true;

        Vector3 objectPosition = targetObject.position;
        targetPosition = new Vector3(initialPosition.x+objectPosition.x, initialPosition.y, initialPosition.z+objectPosition.z);

        while (Vector3.Distance(mainCamera.transform.position, targetPosition) > 0.1f || Mathf.Abs(mainCamera.orthographicSize - minOrthographicSize) > 0.1f){
            // Calcula la nova posició de la càmera cap a l'objecte
            Vector3 newPosition = Vector3.Lerp(initialPosition, targetPosition, focusSpeed * Time.deltaTime);
            mainCamera.transform.position = newPosition;

            // Redueix la mida de la càmera fins al valor mínim
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, minOrthographicSize, focusSpeed * Time.deltaTime);

            yield return null;
        }

        isFocusing = false;
    }


    IEnumerator FocusCoroutine()
    {
        enfocat = true;
        isFocusing = true;

        Vector3 objectPosition = targetObject.position;
        //Vector3(-4.25f, 0f, -6.25f)
        targetPosition = new Vector3(initialPosition.x + objectPosition.x -4.25f, initialPosition.y, initialPosition.z + objectPosition.z-6.25f);

        float initialOrthoSize = mainCamera.orthographicSize;
        float startTime = Time.time;

        while (Time.time - startTime < focusSpeed)
        {
            float t = (Time.time - startTime) / focusSpeed;
            Vector3 newPosition = Vector3.Lerp(lastPosition, targetPosition, t);
            mainCamera.transform.position = newPosition;

            float newOrthoSize = Mathf.Lerp(initialOrthoSize, minOrthographicSize, t);
            mainCamera.orthographicSize = newOrthoSize;

            yield return null;
        }

        lastPosition = targetPosition;
        mainCamera.transform.position = targetPosition;
        mainCamera.orthographicSize = minOrthographicSize;
        isFocusing = false;
    }

    IEnumerator UnfocusCoroutine(){
        isFocusing = true;

        float initialOrthoSize = mainCamera.orthographicSize;
        float startTime = Time.time;

        while (Time.time - startTime < focusSpeed)
        {
            float t = (Time.time - startTime) / focusSpeed;
            Vector3 newPosition = Vector3.Lerp(lastPosition, initialPosition, t);
            mainCamera.transform.position = newPosition;

            float newOrthoSize = Mathf.Lerp(initialOrthoSize, initialOrthographicSize, t);
            mainCamera.orthographicSize = newOrthoSize;

            yield return null;
        }

        lastPosition = initialPosition;
        mainCamera.transform.position = initialPosition;
        mainCamera.orthographicSize = initialOrthographicSize;
        isFocusing = false;
        enfocat = false;
    }
    
}
