using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public GameObject gameOverPanel;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
    }

    public void UpdateHp(int hp)
    {
        hpText.text = hp.ToString();
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
