using System.Collections;
using UnityEngine;

public class HitParticle : HitEvent
{
    [SerializeField]
    private GameObject _deathParticlePrefab;
    [SerializeField]
    private GameObject _hitParticlePrefab;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Hit()
    {
        if(_hitParticlePrefab)
            InstanciateTempParticle(_hitParticlePrefab);
    }

    protected override void Dead()
    {
        if(_deathParticlePrefab)
            InstanciateTempParticle(_deathParticlePrefab);
    }
    private void InstanciateTempParticle(GameObject particlePrefab)
    {
        var particle = Instantiate(particlePrefab, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        if(!particle)
            Debug.LogError("ヽ(｀⌒´メ)ノ not a particle");
        Destroy(particle.gameObject, particle.main.duration);
    }
    
}