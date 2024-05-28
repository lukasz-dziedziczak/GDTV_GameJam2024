using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SFX : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip pickUpAmmoClip;
    [SerializeField] AudioClip pickUpHealthClip;
    [SerializeField] AudioClip killZombieClip;
    [SerializeField] AudioClip[] bodyHitClips;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Zombie.OnZombieDeath += OnZombieDeath;
    }

    private void OnDisable()
    {
        Zombie.OnZombieDeath -= OnZombieDeath;
    }

    private void OnZombieDeath(Zombie zombie)
    {
        PlayZombieKillSound();
    }

    private void PlayClip(AudioClip clip)
    {
        if (audioSource == null || clip == null) return;
        if(audioSource.isPlaying) audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayPickUpAmmoSound()
    {
        PlayClip(pickUpAmmoClip);
    }

    public void PlayPickUpHealthSound()
    {
        PlayClip(pickUpHealthClip);
    }

    public void PlayZombieKillSound()
    {
        PlayClip(killZombieClip);
    }

    public void PlayBodyHitSound()
    {
        if (bodyHitClips.Length == 0) return;
        PlayClip(bodyHitClips[UnityEngine.Random.Range(0, bodyHitClips.Length)]);
    }
}
