using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform playerHead;
    public Weapon weapon;
    private float shootTimer = 0.0f;
    private WaitForSeconds lineRendererLifeTime;

    void Start()
    {
        weapon.Init();
        lineRendererLifeTime = new WaitForSeconds(weapon.fireRate * 0.4f);
    }

    void Update()
    {
        Raycast();

        shootTimer += Time.deltaTime;
    }
    
    private void Raycast()
    {
        Ray ray = new Ray(transform.position, playerHead.forward);
        RaycastHit hit;

        Debug.DrawLine(playerHead.position, playerHead.forward);
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject.CompareTag("Target") && shootTimer >= weapon.fireRate)
            {
                MakeShot(hit.collider.GetComponent<Rigidbody>(), hit);
                StartCoroutine(HandleLineRenderer());
            }
        }
    }

    private void MakeShot(Rigidbody targetRb, RaycastHit hit)
    {
        weapon.Shoot(hit.point, -hit.normal, targetRb);
        shootTimer = 0.0f;
    }

    private IEnumerator HandleLineRenderer()
    {
        yield return lineRendererLifeTime;
        weapon.ClearShootTrace();
    }
}
