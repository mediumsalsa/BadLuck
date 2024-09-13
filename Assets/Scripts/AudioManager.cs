using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip music;
    public AudioClip runSound;
    public AudioClip jumpSound;
    public AudioClip attackSound;
    public AudioClip hitSound;
    public AudioClip playerHitSound;
    public AudioClip brickSound;
    public AudioClip winSound;
    public AudioClip deathSound;

    private void Start()
    {
        musicSource.clip = music;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }


}
