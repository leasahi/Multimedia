using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int friendCounter;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject startGameScreen;
    public GameObject inGameUi;
    public GameObject Timer;
    public GameObject pauseIcon;
    public GameObject player1; //main camera of player 1
    public GameObject player2; //main camera of player 2
    public GameObject playerChara1;
    public GameObject playerChara2;
    public bool gamePaused = false;
    public bool started = false;

    private void Update()
    {
        if (!started)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                this.startGame();
                started = true;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            // Aktiviert den anderen Audio Listener
            SwitchAudioListener();
        }
    }

    private void SwitchAudioListener()
    {
        var p1AudioListener = player1.GetComponent<AudioListener>();
        var p2AudioListener = player2.GetComponent<AudioListener>();

        if(p1AudioListener.enabled == false)
        {
            p2AudioListener.enabled = false;
            p1AudioListener.enabled = true;
        }
        else
        {
            p1AudioListener.enabled = false;
            p2AudioListener.enabled = true;
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // Setze die Zeit auf 0, um das Spiel zu pausieren
        gamePaused = true;
        pauseIcon.SetActive(true);
        Debug.Log("Spiel pausiert");
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // Setze die Zeit auf 1, um das Spiel fortzusetzen
        gamePaused = false;
        pauseIcon.SetActive(false);
        Debug.Log("Spiel fortgesetzt");
    }


    // Start is called before the first frame update
    void Start()
    {
         startGameScreen.SetActive(true);
    }

    [ContextMenu("Increase Friend Score")]
    public void addScore()
    {
        friendCounter = friendCounter + 1;
        scoreText.text = friendCounter.ToString();
    }

    public int getScore()
    {
        return friendCounter;
    }

    public void restartGame()
    {
        startGameScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        startGameScreen.SetActive(false);
    }

    public void startGame()
    {
        Debug.Log("START");
        startGameScreen.SetActive(false);
        playerChara1.transform.SetPositionAndRotation(new Vector3(-21,-1,-9), Quaternion.Euler(new Vector3(0,-1330,0)));
        playerChara2.transform.SetPositionAndRotation(new Vector3(-17,-1,-11), Quaternion.Euler(new Vector3(0,301,0)));
        inGameUi.SetActive(true);
        this.started = true;
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        Timer.SetActive(false);
    }
}
