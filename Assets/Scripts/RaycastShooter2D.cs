using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastShooter2D : MonoBehaviour
{
    public Camera mainCamera;

    [Header("Shoot Settings")]
    public LayerMask shootLayerMask;

    [Header("Input Actions")]
    public InputAction shootAction;

    public void OnEnable()
    {
        
        shootAction.Enable();
        shootAction.performed += OnShootPerform;
    }

    public void OnDisable()
    {
        shootAction.performed -= OnShootPerform;
    }

    public void OnShootPerform(InputAction.CallbackContext context)
    {
        Vector3 mouseViewPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseViewPosition);

        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition, Vector2.zero, 20,shootLayerMask);

        if (hit.collider != null)
        {
            string layerName = LayerMask.LayerToName(hit.collider.gameObject.layer);
            if(layerName == "Enemy")
            {
                EnemyBase enemy = hit.collider.gameObject.GetComponent<EnemyBase>();
                if(enemy != null)
                {
                    enemy.Hit();
                }
                else
                {
                    Debug.Log("ERROR: hit enemy doesn't have an Enemy Base componet!");
                }

            }
            else if(layerName == "Obstacle")
            {
                Debug.Log("Hai colpito un ostacolo");
            }


        }
    }

}
