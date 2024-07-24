using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Puan değeri
    public int points = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Oyuncunun puan script'ini bul
            PlayerScore playerScore = other.GetComponent<PlayerScore>();

            if (playerScore != null)
            {
                // Puan ekle
                playerScore.AddScore(points);

                // Collectible'ı yok et
                Destroy(gameObject);
            }
        }
    }
}
