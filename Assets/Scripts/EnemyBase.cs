using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int TotalHP = 1;
    public int scoreOnKill = 5;
    public int destroyTime = 0;
    public AudioClip deathSfx;

    [Header("Components")]
    public GameObject shootFX;
    public AudioSource audioSource;

    protected int currentHP;
    EnemySpawner spawner;
    protected bool isDead = false;

    public virtual void Awake()
    {
        currentHP = TotalHP;
        if (shootFX != null)
        {
            shootFX.SetActive(false);
        }
    }

    public void Initialize(EnemySpawner _spawner)
    {
        spawner = _spawner;
    }

    protected virtual void Move()
    {
        
    }

    protected virtual void Shoot()
    {
        shootFX.SetActive(true);
        PlayerManager playerManager = FindFirstObjectByType<PlayerManager>();
        playerManager.Hit();
        Invoke("HideFx", 0.12f);
    }

    void HideFx()
    {
        shootFX.SetActive(false);
    }

    public virtual void Hit()
    {
        if (isDead)
            return;

        Debug.Log("NEMICO COLPITO");
        currentHP--;
        if(currentHP <= 0)
        {
            currentHP = 0;
            Death();
        }
    }

    protected virtual void RemoveEnemy()
    {
        spawner.RemoveEnemy(this);
        Invoke("DestroyMe", destroyTime);
    }
    protected virtual void DestroyMe()
    {
        Destroy(gameObject);
    }
    protected virtual void Death()
    {
        ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.OnEnemyKill(scoreOnKill);
        }
        else
        {
            Debug.Log("ScoreManager not found");
        }
        isDead = true;

        AudioManager audioManager = FindFirstObjectByType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.PlaySFX(deathSfx);
        }

        RemoveEnemy();
    }


   

}
