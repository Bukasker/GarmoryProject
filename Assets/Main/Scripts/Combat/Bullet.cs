using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        {
            if (col.CompareTag("Enemy"))
            {
                var enemyScript = col.GetComponent<Enemy>();
                enemyScript.Interact();
                Debug.Log($"{gameObject.name} collided with {col.name}");
            }
            Destroy(gameObject);
        }
    }
}
