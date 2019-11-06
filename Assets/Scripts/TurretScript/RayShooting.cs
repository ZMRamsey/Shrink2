using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooting : MonoBehaviour
{
    public int damage = 10;
    public float fireRate = 0.25f;
    public float turretRange = 100.0f;
    public float FOW;
    public Transform projectileSpawn;
    public GameObject target;

    private float nextFire; // Hold time 
    private Camera turretCamera;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private LineRenderer rayLine;
    

    void Start()
    {
        rayLine = GetComponent<LineRenderer>();
        turretCamera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (Time.time > nextFire)
        {
            //Debug.Log("1");
            //.Log(turretCamera);
            nextFire = Time.time + fireRate; // Store the timere of the last shot and use it in the if statement above for check if enogh time is pass.

            float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position));
            
            if (angle < FOW)
            {
                //Debug.Log("2");
                StartCoroutine(ShotEffect());

                Vector3 rayOrigin = turretCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f)); // Center of the turret camera.
                RaycastHit hit; // Store the information if our ray hit a game object with an collider component attached.

                rayLine.SetPosition(0, projectileSpawn.position); // Set the start position of the ray in the projectile spawn position.

                if (Physics.Raycast(rayOrigin, turretCamera.transform.forward, out hit, turretRange))
                {
                    rayLine.SetPosition(1, hit.point);

                    HealthScript health = hit.collider.GetComponent<HealthScript>(); // Check if there is a HealthScript in the object hitted.

                    if (health != null)
                    {
                        health.Damage(damage); // If the statement is true pass damage variable to health.
                    }
                    
                }
                else
                {
                    rayLine.SetPosition(1, rayOrigin + (turretCamera.transform.forward * turretRange));
                }
            } Debug.Log(angle < FOW); Debug.Log(angle); Debug.Log(FOW);
        }
    }
    
    private IEnumerator ShotEffect()
    {
        rayLine.enabled = true;
        yield return shotDuration;
        rayLine.enabled = false;
    }
}
