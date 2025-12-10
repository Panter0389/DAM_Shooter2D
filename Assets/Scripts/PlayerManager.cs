using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerUI playerUI;

    public int maxHp = 3;
    int currentHp;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Awake()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);

        currentHp = maxHp;
        playerUI.UpdateHp(currentHp);
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
