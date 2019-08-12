using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform playerHead;
    public Weapon weapon;

    void Start()
    {
        weapon.Init();
    }

    void Update()
    {
        Raycast();
    }
    
    private void Raycast()
    {
        Ray ray = new Ray(transform.position, playerHead.forward);
        RaycastHit hit;

        Debug.DrawLine(playerHead.position, playerHead.forward);
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject.CompareTag("Target"))
            {
                MakeShot(hit.collider.GetComponent<Rigidbody>(), hit);
            }
        }
    }

    private void MakeShot(Rigidbody targetRb, RaycastHit hit)
    {
        weapon.Shoot(hit.point, -hit.normal, targetRb);
    }
}
