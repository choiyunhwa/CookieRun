using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchButtonManager : MonoBehaviour
{
    public void OnClickPlayButton()
    {
        SceneManager.LoadScene("02 SeclectStage");
        Debug.Log("play");
    }

    public void OnClickCharacterButton()
    {
        Debug.Log("charac");
    }

    public void OnClickMainButton()
    {
        SceneManager.LoadScene("01 Main scene");
    }

    public void OnClickStage1Button()
    {
        SceneManager.LoadScene("03 Stage1");
    }

    public void OnClickStage2Button()
    {
        SceneManager.LoadScene("05 Stage2");
    }

    public void OnClickStage1PlayButton()
    {
        SceneManager.LoadScene("04 Ground1");
    }

    public void OnClickStage2PlayButton()
    {
        SceneManager.LoadScene("06 Ground2");
    }

    public void OnClickStage1Restart()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }    
}
