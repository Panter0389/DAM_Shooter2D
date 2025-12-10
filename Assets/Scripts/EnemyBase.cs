using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int TotalHP = 1;

    [Header("Components")]
    public GameObject shootFX;

    protected int currentHP;
    EnemySpawner spawner;

    public virtual void Awake()
    {
        currentHP = TotalHP;
        shootFX.SetActive(false);
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
        Debug.Log("NEMICO COLPITO");
        currentHP--;
        if(currentHP <= 0)
        {
            currentHP = 0;
            Death();
        }
    }

    protected virtual void Death()
    {
        spawner.EnemyDie(this);

        Debug.Log("NEMICO MORTO");
        Destroy(gameObject);
    }


   

}
