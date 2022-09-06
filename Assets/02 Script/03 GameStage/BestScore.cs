using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{
    private TextMeshProUGUI bestScore;
    private DataManager dataManager;

    private void Awake()
    {
        bestScore = GetComponent<TextMeshProUGUI>();
        dataManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DataManager>();
    }

    private void Update()
    {
        bestScore.text = NumberComma(dataManager.bestScore).ToString();
    }
    public string NumberComma(int data)
    {
        return string.Format("{0:#,###}", data);
    }
}
