using UnityEngine;

public class WindowCivil : EnemyBase
{
    public float screenTime = 1;
    float screenTimer = 0;

    private void Update()
    {
        screenTimer += Time.deltaTime;
        if (screenTimer > screenTime)
        {
            screenTimer = 0;
            RemoveEnemy();
        }
    }
}
