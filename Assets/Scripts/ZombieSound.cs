using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSource.pitch = Random.Range(0.90f, 1.10f);
    }

    public void OnDeath()
    {
        audioSource.Stop();
    }
}
