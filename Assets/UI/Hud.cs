using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hud : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI coinsTxt;

    [SerializeField]
    private TextMeshProUGUI timerTxt;

    [SerializeField]
    private GameObject defeat_panel;
    [SerializeField]
    private GameObject victory_panel;


    // Update is called once per frame
    void Update()
    {
        coinsTxt.text = GameManager.Instance.PlayerCoins.ToString();
        timerTxt.text = GameManager.Instance.TimerLevel.ToString("0.00");

        ShowPanels();
    }

  

    public void ShowPanels()
    {

        if (GameManager.Instance.TotalCoins == GameManager.Instance.PlayerCoins)
        {
            victory_panel.SetActive(true);
        }
        if (GameManager.Instance.TimerLevel <= 0 )
        {
            defeat_panel.SetActive(true);
        }
    }
}
