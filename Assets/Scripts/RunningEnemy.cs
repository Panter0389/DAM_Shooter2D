using UnityEngine;

public class RunningEnemy : EnemyBase
{
    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public bool isSpriteFacingRight;

    public float shootBreak = 1;
    float shootTimer = 0;

    public float runningSpeed = 5;
    float signedRunningSpeed;

    public override void Awake()
    {
        base.Awake();

        if (transform.position.x < 0)
        {
            signedRunningSpeed = runningSpeed;
            spriteRenderer.flipX = !isSpriteFacingRight;
        }
        else
        {
            signedRunningSpeed = -runningSpeed;
            spriteRenderer.flipX = isSpriteFacingRight;
        }
        rigidBody.linearVelocityX = signedRunningSpeed;
    }

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
    protected override void Death()
    {
        base.Death();

        rigidBody.linearVelocityX = 0;
        animator.Play("Death");

    }
}
