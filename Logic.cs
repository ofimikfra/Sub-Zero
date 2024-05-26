using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Logic : MonoBehaviour
{
    public GameObject deathScreen;
    public int score = 0;
    public float scorePerSecond = 0.1f;
    private float timeElapsed = 0f;
    public TextMeshProUGUI scoreUI;
    public Submarine sub;
    public TextMeshProUGUI inst;
    public TextMeshProUGUI inst1;

    IEnumerator DisplayMessage()
    {
        inst.text = "ARROW KEYS to move \n X to shoot";
        inst1.text = "ARROW KEYS to move \n X to shoot";
        yield return new WaitForSeconds(4f); // Display message for 5 seconds
        inst.text = ""; // Hide message
        inst1.text = "";
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void gameOver()
    {
        deathScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void quitGame()
    {
        Application.Quit();
    }

    void Start()
    {
        StartCoroutine(UpdateTimer());
        StartCoroutine(DisplayMessage());
    }

    private IEnumerator UpdateTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            timeElapsed += 0.1f;
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        // Calculate the score based on the time elapsed
        score = Mathf.RoundToInt(timeElapsed * scorePerSecond);
        scoreUI.text = "Score: " + score.ToString();
    }
}
