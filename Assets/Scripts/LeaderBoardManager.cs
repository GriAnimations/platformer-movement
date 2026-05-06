using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoardManager : MonoBehaviour
{

    public List<float> leaderboard;
    [SerializeField] private TimerScript timer;

    private TextMeshProUGUI _rank1Time;
    private TextMeshProUGUI _rank2Time;
    private TextMeshProUGUI _rank3Time;
    private TextMeshProUGUI _rank4Time;
    private TextMeshProUGUI _rank5Time;

    private TextMeshProUGUI _rank1Name;
    private TextMeshProUGUI _rank2Name;
    private TextMeshProUGUI _rank3Name;
    private TextMeshProUGUI _rank4Name;
    private TextMeshProUGUI _rank5Name;

    public string currentName;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rank1Time = GameObject.Find("Rank 1_Time").GetComponent<TextMeshProUGUI>();
        _rank2Time = GameObject.Find("Rank 2_Time").GetComponent<TextMeshProUGUI>();
        _rank3Time = GameObject.Find("Rank 3_Time").GetComponent<TextMeshProUGUI>();
        _rank4Time = GameObject.Find("Rank 4_Time").GetComponent<TextMeshProUGUI>();
        _rank5Time = GameObject.Find("Rank 5_Time").GetComponent<TextMeshProUGUI>();
        
        _rank1Name = GameObject.Find("Rank 1_Name").GetComponent<TextMeshProUGUI>();
        _rank2Name = GameObject.Find("Rank 2_Name").GetComponent<TextMeshProUGUI>();
        _rank3Name = GameObject.Find("Rank 3_Name").GetComponent<TextMeshProUGUI>();
        _rank4Name = GameObject.Find("Rank 4_Name").GetComponent<TextMeshProUGUI>();
        _rank5Name = GameObject.Find("Rank 5_Name").GetComponent<TextMeshProUGUI>();
        
        ToString(leaderboard[0], _rank1Time);
        ToString(leaderboard[1], _rank2Time);
        ToString(leaderboard[2], _rank3Time);
        ToString(leaderboard[3], _rank4Time);
        ToString(leaderboard[4], _rank5Time);
    }

    public void AddScore()
    {
        if (timer.timer > leaderboard[0])
        {
            leaderboard[4] = leaderboard[3];
            leaderboard[3] = leaderboard[2];
            leaderboard[2] = leaderboard[1];
            leaderboard[1] = leaderboard[0];
            leaderboard[0] = timer.timer;
            
            _rank5Name.text = _rank4Name.text;
            _rank4Name.text = _rank3Name.text;
            _rank3Name.text = _rank2Name.text;
            _rank2Name.text = _rank1Name.text;
            _rank1Name.text = currentName;
        }
        else if (timer.timer > leaderboard[1])
        {
            leaderboard[4] = leaderboard[3];
            leaderboard[3] = leaderboard[2];
            leaderboard[2] = leaderboard[1];
            leaderboard[1] = timer.timer;
            
            _rank5Name.text = _rank4Name.text;
            _rank4Name.text = _rank3Name.text;
            _rank3Name.text = _rank2Name.text;
            _rank2Name.text = currentName;
        }
        else if (timer.timer > leaderboard[2])
        {
            leaderboard[4] = leaderboard[3];
            leaderboard[3] = leaderboard[2];
            leaderboard[2] = timer.timer;
            
            _rank5Name.text = _rank4Name.text;
            _rank4Name.text = _rank3Name.text;
            _rank3Name.text = currentName;
        }
        else if (timer.timer > leaderboard[3])
        {
            leaderboard[4] = leaderboard[3];
            leaderboard[3] = timer.timer;
            
            _rank5Name.text = _rank4Name.text;
            _rank4Name.text = currentName;
        }
        else if (timer.timer > leaderboard[4])
        {
            leaderboard[4] = timer.timer;
            
            _rank5Name.text = currentName;
        }
        
        ToString(leaderboard[0], _rank1Time);
        ToString(leaderboard[1], _rank2Time);
        ToString(leaderboard[2], _rank3Time);
        ToString(leaderboard[3], _rank4Time);
        ToString(leaderboard[4], _rank5Time);
    }

    private void ToString(float currentTime, TextMeshProUGUI text)
    {
        currentTime = timer.originalTimer - currentTime;
        
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
