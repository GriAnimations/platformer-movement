using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class TimerScript : MonoBehaviour
{

    public float timer;
    private float _timerUp;
    public float originalTimer;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private KillerManager killerManager;
    [SerializeField] private LeaderBoardManager leaderBoardManager;
    
    public bool timerActive;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            timer -= Time.deltaTime;
            _timerUp = originalTimer - timer;
            
            timerText.text = TimeSpan.FromSeconds(_timerUp).ToString("ss\\.fff") + " / 1 minute!";
        }

        if (!(timer <= 0) || !timerActive) return;
        killerManager.KillPlayer();
        timerText.text = "Times Up!";
        leaderBoardManager.DisplayLeaderBoard("Can you make it on the LeaderBoard?");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            timerActive = true;
        }
    }

    public void StopTimer()
    {
        timerActive = false;
    }

    public void ResetTimer()
    {
        timerActive = false;
        timer = originalTimer;
        
        timerText.text = "00.000 / 1 minute!";
    }
}
