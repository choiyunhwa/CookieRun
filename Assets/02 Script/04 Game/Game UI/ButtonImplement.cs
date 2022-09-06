using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonImplement : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pausePenal;
    private void Awake()
    {
        pausePenal.SetActive(false);
    }
    public void OnClickPause()
    {
        pausePenal.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnClickReStart()
    {
        pausePenal.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnClickStop()
    {
        SceneManager.LoadScene("Stage1");
    }
}
