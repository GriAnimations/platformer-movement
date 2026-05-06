using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class TimerScript : MonoBehaviour
{

    public float timer;
    public float originalTimer;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private KillerManager killerManager;
    
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
    }
}
