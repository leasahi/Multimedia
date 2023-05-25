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
    public GameObject Timer;
    bool again = false;


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

    public void restartGame()
    {
        again = true;
        startGameScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        startGameScreen.SetActive(false);
    }

    public void startGame()
    {
          
        startGameScreen.SetActive(false);
        
    }

    public void gameOver()
    {
        again = true;
        gameOverScreen.SetActive(true);
        Timer.SetActive(false);
    }
}
