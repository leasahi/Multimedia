using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int friendCounter;
    public int wait = 0;
    public Text scoreText;
    public GameObject gameOverScreenPandaWins;
    public GameObject gameOverScreenPenguinWins;
    public GameObject gameOverScreenNobodyWins;
    public GameObject videoPandaWins;
    public GameObject videoPenguinWins;

    public GameObject startGameScreen;
    public GameObject inGameUi;
    public GameObject explanationScreen1;
    public GameObject explanationScreen2;
    public GameObject Timer;
    public GameObject pauseIcon;
    public GameObject player1; //main camera of player 1
    public GameObject player2; //main camera of player 2
    public GameObject playerChara1;
    public GameObject playerChara2;
    public bool gamePaused = false;
    public bool started = false;
    public bool pandaWins = false;
    public bool penguinWins = false;

    public FriendCountScript friendsCounter;

    private void Update()
    {
        if (friendsCounter.friends1 > friendsCounter.friends2)
        {
            pandaWins = false;
            penguinWins = true;
        }
        if (friendsCounter.friends1 < friendsCounter.friends2)
        {
            penguinWins = false;
            pandaWins = true;
        }
        if (friendsCounter.friends1 == friendsCounter.friends2)
        {
            penguinWins = false;
            pandaWins = false;
        }

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
        if (Input.GetKeyDown(KeyCode.Plus))
        {
            //skippt zum start
            restartGame();
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
		if (gamePaused) {
			this.ResumeGame();
		}
        startGameScreen.SetActive(false);
        gameOverScreenPandaWins.SetActive(false);
        gameOverScreenPenguinWins.SetActive(false);
        gameOverScreenNobodyWins.SetActive(false);
        videoPenguinWins.SetActive(false);
        videoPandaWins.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        startGameScreen.SetActive(false);
    }

    public void startGame()
    {
        Debug.Log("START");
        startGameScreen.SetActive(false);
        explanationScreen1.SetActive(false);
        explanationScreen2.SetActive(false);
        playerChara1.transform.SetPositionAndRotation(new Vector3(-21,-1,-9), Quaternion.Euler(new Vector3(0,-1330,0)));
        playerChara2.transform.SetPositionAndRotation(new Vector3(-17,-1,-11), Quaternion.Euler(new Vector3(0,301,0)));
        inGameUi.SetActive(true);
        this.started = true;
        //this.soundsOnOff(true);
    }

    public void gameOver()
    {
        if (pandaWins)
        {
            gameOverScreenPandaWins.SetActive(true);
            StartCoroutine(Wait());
            if(wait == 1)
            {
                wait = 0;
                videoPandaWins.SetActive(true);
            }
        }
        else if(penguinWins)
        {
            gameOverScreenPenguinWins.SetActive(true);
            StartCoroutine(Wait());
            if (wait == 1)
            {
                wait = 0;
                videoPenguinWins.SetActive(true);
            }
        } else if(Random.Range(0, 2) == 1)
        {
            gameOverScreenNobodyWins.SetActive(true);
            videoPenguinWins.SetActive(false);
            videoPandaWins.SetActive(true);
        } else {
            gameOverScreenNobodyWins.SetActive(true);
            videoPandaWins.SetActive(false);
            videoPenguinWins.SetActive(true);
        }

        Timer.SetActive(false);
    }

    public void gameExplanation1()
    {
        startGameScreen.SetActive(false);
        explanationScreen1.SetActive(true);
    }
    
    public void gameExplanation2()
    {
        //startGameScreen.SetActive(false);
        explanationScreen1.SetActive(false);
        explanationScreen2.SetActive(true);
    }

    public void showStartScreen()
    {
        explanationScreen1.SetActive(false);
        explanationScreen2.SetActive(false);
        startGameScreen.SetActive(true);
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        wait = 1;
    }
}
