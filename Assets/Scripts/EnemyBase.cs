using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int TotalHP = 1;

    protected int currentHP;
    EnemySpawner spawner;

    public void Awake()
    {
        currentHP = TotalHP;
    }

    public void Initialize(EnemySpawner _spawner)
    {
        spawner = _spawner;
    }

    protected virtual void Move()
    {
        
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
