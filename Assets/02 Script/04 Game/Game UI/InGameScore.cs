using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameScore : MonoBehaviour
{
    private TextMeshProUGUI score;
    private DataManager dataManager;

    private void Awake()
    {
        score = GetComponent<TextMeshProUGUI>();
        dataManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DataManager>();
    }

    private void Update()
    {
        //score.text = dataManager.score.ToString();
        score.text = NumberComma(dataManager.score).ToString();
    }

    public string NumberComma(int data)
    {
        return string.Format("{0:#,###}", data);
    }

}
