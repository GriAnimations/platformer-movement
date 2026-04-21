using System;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{

    public float timer;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private KillerManager killerManager;
    
    private bool _timerActive;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 180f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timerActive)
        {
            timer -= Time.deltaTime;
        }
        
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timer <= 0)
        {
            killerManager.KillPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _timerActive = true;
            Debug.Log("Timer Active");
        }
    }

    public void StopTimer()
    {
        _timerActive = false;
    }

    public void ResetTimer()
    {
        _timerActive = false;
        timer = 180f;
    }
}
