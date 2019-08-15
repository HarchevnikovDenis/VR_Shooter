using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingTarget : MonoBehaviour
{
    private NavMeshAgent navMesh;
    private Transform currDestination;
    private Transform[] waypoints;
    private int health;
    public GameObject[] healthImages;
    public GameObject destroyedTargetPrefab;

    public void Init(Transform[] _waypoints)
    {
        waypoints = _waypoints;
    }

    private void Start()
    {
        navMesh = gameObject.GetComponent<NavMeshAgent>();
        health = healthImages.Length;
        SetRandomNavMeshAgentDestination();
    }
    void Update()
    {
        float dist = navMesh.remainingDistance;
        if(dist != Mathf.Infinity && navMesh.pathStatus == NavMeshPathStatus.PathComplete && dist < 0.1f)
        {
            SetRandomNavMeshAgentDestination();
        }
    }

    private void SetRandomNavMeshAgentDestination()
    {
        int waypointIndex = Random.Range(0, waypoints.Length);
        currDestination = waypoints[waypointIndex];
        navMesh.SetDestination(currDestination.position);
    }

    public void TakeDamage()
    {
        health--;
        healthImages[health].SetActive(false);
        if(health <= 0)
        {
            Transform currentTransform = transform;
            GameObject go = Instantiate(destroyedTargetPrefab, currentTransform.position, currentTransform.rotation);
            Destroy(gameObject);
            Destroy(go, 5.0f);
        }
    }

}
