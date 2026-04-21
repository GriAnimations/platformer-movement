using System;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    
    [SerializeField] private TimerScript timer;
    [SerializeField] private ParticleSystem particle;

    private void OnTriggerEnter2D(Collider2D other)
    {
        timer.StopTimer();
        particle.Play();
    }
}
