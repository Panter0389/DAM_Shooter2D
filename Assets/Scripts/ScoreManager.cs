using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public PlayerUI playerUI;

    int score = 0;

    public void OnEnemyKill(int enemyScore)
    {
        score += enemyScore;
        playerUI.UpdateScore(score);
    }
  
}
