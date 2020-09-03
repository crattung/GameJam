using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HitSound : HitEvent
{
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private AudioClip _deathSound;

    private AudioSource _audioSource;
    protected override void Start()
    {
        base.Start();

        _audioSource = GetComponent<AudioSource>();
    }

    protected override void Hit()
    {
        _audioSource.PlayOneShot(_hitSound);
    }

    protected override void Dead()
    {
        if(_deathSound)
        {
            var deathAudio = Instantiate(new GameObject("as", typeof(AudioSource))).GetComponent<AudioSource>();
            deathAudio.PlayOneShot(_deathSound);
            Destroy(deathAudio.gameObject, _deathSound.length);
        }
    }
}