using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [Header("Bouncy Target")]
    public int maxBouncyTargetsCount = 2;
    private int currBouncyTargetsCount = 0;
    public Transform bouncyRespPoint;
    public GameObject bouncyTargetPrefab;
    [Header("Heavy Target")]
    public int maxHeavyTargetsCount = 2;
    private int currHeavyTargetsCount = 0;
    public Transform heavyRespPoint;
    public GameObject heavyTargetPrefab;

    public void InstantiateBouncyTarget()
    {
        if(currBouncyTargetsCount < maxBouncyTargetsCount)
        {
            Instantiate(bouncyTargetPrefab, bouncyRespPoint.position, bouncyRespPoint.rotation);
            currBouncyTargetsCount++;
        }
    }
    public void InstantiateHeavyTarget()
    {
        if(currHeavyTargetsCount < maxHeavyTargetsCount)
        {
            Instantiate(heavyTargetPrefab, heavyRespPoint.position, heavyRespPoint.rotation);
            currHeavyTargetsCount++;
        }
    }
}
