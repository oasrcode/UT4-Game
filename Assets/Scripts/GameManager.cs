using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private GameObject uiManager;
    public int TotalCoins {
        get { return totalCoins;}
    }
    [SerializeField]
    private int totalCoins;
    public int PlayerCoins { 
        get { return playerCoins; }
        set { playerCoins += value; }
    }
    private int playerCoins=0;


    [SerializeField]
    private float timerLevel = 20;

    public float TimerLevel
    {
        get { return timerLevel; }
    }

    [SerializeField]
    private string sceneName;

  

    
    private void Awake()
    {
        Time.timeScale = 1;

        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("more than 1 gamemanager");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerLevel -= Time.deltaTime;

        if (timerLevel <= 0 || totalCoins == playerCoins)
        {
            Time.timeScale = 0;
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(2);
    }
}
