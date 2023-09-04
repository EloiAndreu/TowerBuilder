using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanController : MonoBehaviour
{
    public enum HumanStats{
        Resting,
        Building,
        InTower
    }

    //HumanStats currentState;
    NavMeshAgent navMeshAgent;
    public float temmpsEspera = 5f;

    void Start(){
        //currentState = HumanStats.Resting;
        navMeshAgent = GetComponent<NavMeshAgent>();
        Resting();
    }

    /*
    void Update(){
        if(currentState == HumanStats.Resting) Resting();
        else if(currentState == HumanStats.Building) Building();
        else if(currentState == HumanStats.InTower) InTower();
    }
    */

    public void Resting(){

        Vector3 randomPosition = new Vector3(0f, 0f, 0f);

        int randomX = Random.Range(0, GameManager.Instance.dimensionX);
        int randomZ = Random.Range(0, GameManager.Instance.dimensionY);

        randomPosition = new Vector3(randomX, -0.3f, randomZ);
        
        StartCoroutine(MoveToTarget(randomPosition));
    }

    IEnumerator MoveToTarget(Vector3 targetPosition){
        navMeshAgent.SetDestination(targetPosition);

        while (navMeshAgent.pathPending || navMeshAgent.remainingDistance > 0.1f)
        {
            yield return null;
        }

        yield return new WaitForSeconds(temmpsEspera);

        Resting();
    }

    public virtual void Building(){
        
    }

    public virtual void InTower(){
        
    }
}
