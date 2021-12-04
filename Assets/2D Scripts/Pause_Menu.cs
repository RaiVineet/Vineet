using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    private static Pause_Menu instance;
    public PlayerControl pc;
    private Fade fade;
    public Camerascript Camera;

    // Don't destroy on loading
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
   
    public void Resume()
    {

        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;   // play the game when resume hits
        GameIsPaused = false;


    }
    
    public void Pause()
    {
        Debug.Log("Paused");
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;  // freez the time at the background
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Title");
        pc.LoadTitle();
        //pc.DestroyObj();
        //Camera.DestroyObj();
        Debug.Log("Loading...... Main Menu");
    }
}
