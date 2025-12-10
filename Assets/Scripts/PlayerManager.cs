using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerUI playerUI;

    public int maxHp = 3;
    int currentHp;

    private void Awake()
    {
        currentHp = maxHp;

        //playerUI = FindFirstObjectByType<PlayerUI>();
    }

    public void Hit()
    {
        currentHp--;
        if(currentHp < 0)
            currentHp = 0;

        playerUI.UpdateHp(currentHp);

        if (currentHp == 0)
        {
            Death();
        }
    }

    void Death()
    {
        Time.timeScale = 0;
        playerUI.ShowGameOver();
    }



}
