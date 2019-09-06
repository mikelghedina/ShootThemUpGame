using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject[] asteroids;
    public Vector3 spawnValues;
    public int asteroidCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text gameOverText;
    public Text restartText;

    private bool gameOver;
    private bool restartGame;

    private int score;
    private void Start()
    {
        gameOver = false;
        restartGame = false;
        restartText.text = "";
        gameOverText.text = "";

        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }
    public void Update()
    {
        if (restartGame)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }           
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {        
            for (int i =0; i < asteroidCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                int asteroidType = Random.Range(0, asteroids.Length);
                Instantiate(asteroids[asteroidType], spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartText.text = "Press R to restart";
                restartGame = true;
                break;
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
