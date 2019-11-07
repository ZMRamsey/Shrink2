using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Health script that also work as respawn script. Attach a game object as respawn point.

public class HealthScript : MonoBehaviour
{
    public int currentHealth = 100;
    
    public GameObject spawnArea;


    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        if (spawnArea != null)
        {
            respawnArea();
        }
        else return;
    }


    // Repawn the this Game Object in the designated area.
    public void respawnArea()
    {
        gameObject.SetActive(true);
        gameObject.transform.position = spawnArea.transform.position;
    }
}
