using System;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    
    private TimerScript _timer;
    private ParticleSystem _particle;
    private LeaderBoardManager _leaderBoardManager;
    


    private void Start()
    {
        _timer = GameObject.Find("Start + Timer").GetComponent<TimerScript>();
        _particle = GameObject.Find("GoalParticles").GetComponent<ParticleSystem>();
        _leaderBoardManager = GameObject.Find("LeaderBoardManager").GetComponent<LeaderBoardManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_timer.timerActive) return;
        
        _timer.StopTimer();
        _particle.Play();
        _leaderBoardManager.AddScore();
    }
}
