using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public int score = 0;
    public int bestScore = 0;

    public static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        LoadBestScore();
    }

    public int BestScore
    {
        get{ return bestScore; }
    }

    public int myScore
    {
        get { return score; }
        set
        {
            score = value;
            if(score > bestScore)
            {
                bestScore = score;
                SaveBestScore();
            }
        }
    }

    public void SaveBestScore()
    {
        PlayerPrefs.SetInt("Best Score", bestScore);
    }
    public void LoadBestScore()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
    }

}
