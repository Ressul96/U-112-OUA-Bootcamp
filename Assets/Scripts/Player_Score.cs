using UnityEngine;
using UnityEngine.UI; // Eğer UI üzerinde puanı gösterecekseniz

public class PlayerScore : MonoBehaviour
{
    public int score = 0;
    public Text scoreText; // UI üzerinde puanı göstermek için

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
