using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject [] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;


    public BGscroller scrollUp;

    public Text ScoreText;
    public Text RestartText;
    public Text GameOverText;
    public Text WinText;
    public Text NameText;
    public Text ModeText;
    public Text WarpText;

    private int score;

    private bool gameOver;
    private bool restart;

    void Start()
    {
        gameOver = false;
        restart = false;
        RestartText.text = "";
        GameOverText.text = "";
        WinText.text = "";
        NameText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if(restart)
        {
            if (Input.GetKeyDown (KeyCode.Space))
            {
                SceneManager.LoadScene("Main");
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && SceneManager.GetActiveScene().name.StartsWith("Main"))
        {
            SceneManager.LoadScene("Endless");
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && SceneManager.GetActiveScene().name.StartsWith("Boss"))
        {
            SceneManager.LoadScene("Endless");
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && SceneManager.GetActiveScene().name.StartsWith("End"))
        {
            SceneManager.LoadScene("Main");
        }
        if (SceneManager.GetActiveScene().name.StartsWith("Main"))
        {
            ModeText.text = "Press Left Shift to \n play Endless Mode";
        }
        if (SceneManager.GetActiveScene().name.StartsWith("Boss"))
        {
            ModeText.text = "Press Left Shift to \n play Endless Mode";
        }
        if (SceneManager.GetActiveScene().name.StartsWith("End"))
        {
            ModeText.text = "Press Left Shift to \n return to Normal Mode";
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver)
            {
                RestartText.text = "Press Spacebar to retry";
                restart = true;
                break;
            }
        }
    }

    IEnumerator BossTime()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Boss");
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 100 && SceneManager.GetActiveScene().name.StartsWith("Main"))
        {
            NameText.text = "IT'S NOT OVER YET! GET READY \n FOR A BOSS FIGHT!";
            gameOver = true;
            scrollUp.scrollSpeed += 5;
            StartCoroutine(BossTime());
        }
        if (score >= 1000000 && SceneManager.GetActiveScene().name.StartsWith("Boss"))
        {
            WinText.text = "You win!";
            NameText.text = "GAME CREATED BY BEN BURRELL";
            gameOver = true;
            restart = true;
            scrollUp.scrollSpeed += 5;
            FindObjectOfType<MusicSounds>().WinSound();
        }
    }

    public void GameOver()
    {
        GameOverText.text = "Game Over";
        gameOver = true;
        FindObjectOfType<MusicSounds>().DeathSound();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}