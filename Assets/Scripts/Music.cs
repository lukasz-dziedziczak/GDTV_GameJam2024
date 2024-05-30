using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music Instance;

    [SerializeField] AudioClip matchClip;
    [SerializeField] AudioClip menuClip;
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void PlayClip(AudioClip clip)
    {
        if (audioSource == null || clip == null) return;
        if (audioSource.clip == clip) return;
        if (audioSource.isPlaying) audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    public static void PlayMatchMusic()
    {
        Instance.PlayClip(Instance.matchClip);
    }

    public static void PlayMeunMusic()
    {
        Instance.PlayClip(Instance.menuClip);
    }
}
