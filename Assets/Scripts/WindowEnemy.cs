using UnityEngine;

public class WindowEnemy : EnemyBase
{
    public float shootBreak = 1;
    float shootTimer = 0;

    private void Update()
    {
        if (!isDead)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer > shootBreak)
            {
                shootTimer = 0;
                Shoot();
            }
        }
    }
}
