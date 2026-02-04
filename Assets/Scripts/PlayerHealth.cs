using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void LoseHealth()
    {
        health--;
    }
}
