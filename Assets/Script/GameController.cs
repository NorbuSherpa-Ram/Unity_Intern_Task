using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController instance;


    // public 
    public static Vector2 checkPointPosition;

    [Header ("Pause & Game Over")]
    public bool isPause = false;
    public static bool isOver = false;
    //to respown 
    public int respownCount;
    public static bool reload = true;

    public GameObject pausePanel;
    public GameObject overPanel;
    public Button reapownButton;
    // to show respown count
    public Text spownTxt;

    //private void Awake()
    //{
    //    //    if(instance == null)
    //    //    {
    //    //        instance = this;
    //    //    DontDestroyOnLoad(instance );
    //    //    }
    //    //    else
    //    //    {
    //    //        Destroy(gameObject );
    //    //    }
    //    overPanel.SetActive(false);
    //    pausePanel.SetActive(false);
    //}

    private void Start()
    {
        Time.timeScale = 1;
        if (reload) { respownCount = 1; }
        else { respownCount = 0; }
    }
    private void OnEnable()
    {
        CheckPoint.onCheckPointTrigger += setCheckPointPos;
        PauseMenu.onPause += Pause;
    }
    private void Update()
    {

        spownTxt.text = "RESPOWN COUNT :" + respownCount.ToString();

        if (isOver)
        {
            overPanel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }
    }
    void ReloadScene()
    {
        if (respownCount > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            reload = false;
            isOver = false;
        }
    }
    public void RestartScene()
    {
        checkPointPosition = Vector2.zero;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        reload = true;
        isOver = false;
    }
    public void Pause()
    {
        if (isOver) return;

        isPause = !isPause;
        if (isPause)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }
    }

    void setCheckPointPos(Vector3 pos)
    {
        checkPointPosition = pos;
    }

    private void OnDisable()
    {
        CheckPoint.onCheckPointTrigger -= setCheckPointPos;
        PauseMenu.onPause -= Pause;
    }
}
