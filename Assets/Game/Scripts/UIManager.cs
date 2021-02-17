using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] liveSprites;
    public Image livesImageDisplayed;
    public GameObject titleScreen;
   
    public Text scoreText;
    public int score;

    public void UpdateLives(int currentLives)
    {
        livesImageDisplayed.sprite = liveSprites[currentLives];
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = $"Score: {score}";
    }

    public void ShowTitleScreen()
    {
        titleScreen.SetActive(true);
    }

    public void HideTitleScreen()
    {
        titleScreen.SetActive(false);
        score = 0;
        scoreText.text = "Score: ";
    }

}