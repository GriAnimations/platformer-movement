using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoardManager : MonoBehaviour
{
    [SerializeField] private GameObject leaderBoardDisplay;
    [SerializeField] private TextMeshProUGUI newHighScore;
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
    
    private SpriteRenderer _rank1Highlight;
    private SpriteRenderer _rank2Highlight;
    private SpriteRenderer _rank3Highlight;
    private SpriteRenderer _rank4Highlight;
    private SpriteRenderer _rank5Highlight;

    public string currentName;
    
    private KillerManager _killerManager;

    [SerializeField] private GameObject newNameObj;
    private bool _selectingName;
    private int _letterNumber;
    [SerializeField] private TextMeshProUGUI letter1;
    [SerializeField] private TextMeshProUGUI letter2;
    [SerializeField] private TextMeshProUGUI letter3;
    
    private char[] _alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    private int _broken;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _killerManager = GameObject.Find("Player").GetComponent<KillerManager>();
        
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

        _rank1Highlight = GameObject.Find("Rank 1_Highlight").GetComponent<SpriteRenderer>();
        _rank2Highlight = GameObject.Find("Rank 2_Highlight").GetComponent<SpriteRenderer>();
        _rank3Highlight = GameObject.Find("Rank 3_Highlight").GetComponent<SpriteRenderer>();
        _rank4Highlight = GameObject.Find("Rank 4_Highlight").GetComponent<SpriteRenderer>();
        _rank5Highlight = GameObject.Find("Rank 5_Highlight").GetComponent<SpriteRenderer>();

        ToString(leaderboard[0], _rank1Time);
        ToString(leaderboard[1], _rank2Time);
        ToString(leaderboard[2], _rank3Time);
        ToString(leaderboard[3], _rank4Time);
        ToString(leaderboard[4], _rank5Time);

        ToStringEmpty(_rank1Time, _rank1Name);
        ToStringEmpty(_rank2Time, _rank2Name);
        ToStringEmpty(_rank3Time, _rank3Name);
        ToStringEmpty(_rank4Time, _rank4Name);
        ToStringEmpty(_rank5Time, _rank5Name);
        
        //StartCoroutine(WaitForInput());
        leaderBoardDisplay.SetActive(false);
    }

    public void AddScore()
    {
        _killerManager.KillPlayer();
        
        DisplayLeaderBoard("No new Highscore :(");
        _rank1Highlight.enabled = false;
        _rank2Highlight.enabled = false;
        _rank3Highlight.enabled = false;
        _rank4Highlight.enabled = false;
        _rank5Highlight.enabled = false;
        
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

            DisplayLeaderBoard("NEW HIGHSCORE!!");
            _rank1Highlight.enabled = true;

            StartCoroutine(NewName(1));
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
            
            DisplayLeaderBoard("Second Place!");
            _rank2Highlight.enabled = true;
            
            StartCoroutine(NewName(2));
        }
        else if (timer.timer > leaderboard[2])
        {
            leaderboard[4] = leaderboard[3];
            leaderboard[3] = leaderboard[2];
            leaderboard[2] = timer.timer;
            
            _rank5Name.text = _rank4Name.text;
            _rank4Name.text = _rank3Name.text;
            _rank3Name.text = currentName;
            
            DisplayLeaderBoard("Third Place!");
            _rank3Highlight.enabled = true;
            
            StartCoroutine(NewName(3));
        }
        else if (timer.timer > leaderboard[3])
        {
            leaderboard[4] = leaderboard[3];
            leaderboard[3] = timer.timer;
            
            _rank5Name.text = _rank4Name.text;
            _rank4Name.text = currentName;
            
            DisplayLeaderBoard("Fourth Place!");
            _rank4Highlight.enabled = true;
            
            StartCoroutine(NewName(4));
        }
        else if (timer.timer > leaderboard[4])
        {
            leaderboard[4] = timer.timer;
            
            _rank5Name.text = currentName;
            
            DisplayLeaderBoard("Fifth Place!");
            _rank5Highlight.enabled = true;
            
            StartCoroutine(NewName(5));
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
        text.text = TimeSpan.FromSeconds(currentTime).ToString("ss\\.fff");
        
        if (text.text == "00.000")
        {
            text.text = "-";
        }
    }

    private void ToStringEmpty(TextMeshProUGUI time, TextMeshProUGUI name)
    {
        name.text = "-";
        time.text = "-";
    }


    public void DisplayLeaderBoard(string message)
    {
        leaderBoardDisplay.SetActive(true);
        newHighScore.text = message;
        
        StartCoroutine(WaitForInput());
    }

    private IEnumerator WaitForInput()
    {
        var wait = true;

        yield return new WaitForSeconds(2.5f);
        
        while (wait)
        {
            if (Input.anyKeyDown && !_selectingName)
            {
                wait = false;
            }

            yield return null;
        }
        
        _killerManager.RespawnTrigger(0);
        leaderBoardDisplay.SetActive(false);
    }

    private IEnumerator NewName(int rank)
    {
        newNameObj.SetActive(true);

        letter1.text = "_";
        letter2.text = "_";
        letter3.text = "_";
        
        _selectingName = true;
        _letterNumber = 1;
        
        int currIndex = 0;
        
        letter1.text = "A";
        
        while (_letterNumber < 4)
        {
            while (_letterNumber == 1)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    currIndex++;
                    if (currIndex >= _alpha.Length)
                        currIndex = 0;
                    letter1.text = _alpha[currIndex].ToString();
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    currIndex--;
                    if (currIndex <= 0)
                        currIndex = 0;
                    letter1.text = _alpha[currIndex].ToString();
                }

                if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.C) || Input.GetKeyUp(KeyCode.J))
                {
                    _letterNumber++;
                    letter2.text = "A";
                }

                yield return null;
            }
            
            while (_letterNumber == 2)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    currIndex++;
                    if (currIndex >= _alpha.Length)
                        currIndex = 0;
                    letter2.text = _alpha[currIndex].ToString();
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    currIndex--;
                    if (currIndex <= 0)
                        currIndex = 0;
                    letter2.text = _alpha[currIndex].ToString();
                }

                if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.C) || Input.GetKeyUp(KeyCode.J))
                {
                    _letterNumber++;
                    letter3.text = "A";
                }
                if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.K))
                {
                    currIndex = 0;
                    letter2.text = "_";
                    letter1.text = "A";
                    _letterNumber--;
                }

                yield return null;
            }
            
            while (_letterNumber == 3)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    currIndex++;
                    if (currIndex >= _alpha.Length)
                        currIndex = 0;
                    letter3.text = _alpha[currIndex].ToString();
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    currIndex--;
                    if (currIndex <= 0)
                        currIndex = 0;
                    letter3.text = _alpha[currIndex].ToString();
                }

                if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.C) || Input.GetKeyUp(KeyCode.J))
                {
                    _letterNumber++;
                }
                if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.K))
                {
                    currIndex = 0;
                    letter3.text = "_";
                    letter2.text = "A";
                    _letterNumber--;
                }

                yield return null;
            }
        }
        
        
        currentName = letter1.text + letter2.text + letter3.text;

        switch (rank)
        {
            case 1:
                _rank1Name.text = currentName;
                break;
            case 2:
                _rank2Name.text = currentName;
                break;
            case 3:
                _rank3Name.text = currentName;
                break;
            case 4:
                _rank4Name.text = currentName;
                break;
            case 5:
                _rank5Name.text = currentName;
                break;
        }
        
        newNameObj.SetActive(false);
        
        yield return new WaitForSeconds(2.5f);
        
        _selectingName = false;
    }
}
