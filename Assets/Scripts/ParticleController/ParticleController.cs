using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] private GameObject deathEffect;
    private void OnEnable()
    {
        Snake.OnPlayerDeath += PlayDeathEffect;
    }
    private void OnDisable()
    {
        Snake.OnPlayerDeath -= PlayDeathEffect;
    }
    private void PlayDeathEffect()
    {
         GameObject effect = Instantiate(deathEffect, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity,this.transform);
        effect.GetComponent<ParticleSystem>().Play();
    }
}
