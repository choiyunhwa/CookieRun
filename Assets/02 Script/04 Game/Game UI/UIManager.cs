using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject setPanel;
    public GameObject closeButton;

    public void Awake()
    {
        setPanel.SetActive(false);
    }
    public void OnClickSetOnMenu()
    {
        setPanel.SetActive(true);
    }
    public void OnClickSetOffMenu()
    {
        setPanel.SetActive(false);
    }
}
