using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            _audioSource.Play();
        }
    }

    public void LoseHealth()
    {
        health--;
    }
}
