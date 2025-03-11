using UnityEngine;

public class ShootTowardsCenter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float maxRayDistance = 100f;
    [SerializeField] private float maxDistanceFromPlayer = 50f;
    [SerializeField] private LayerMask hitLayer;
    [SerializeField] private Camera mainCamera;

    public void Fire()
    {
        if (projectilePrefab == null || spawnPoint == null || mainCamera == null)
        {
            return;
        }

        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Vector3 targetPoint = ray.GetPoint(maxRayDistance);

        if (Physics.Raycast(ray, out RaycastHit hit, maxRayDistance, hitLayer))
        {
            targetPoint = hit.point;
        }

        Vector3 shootDirection = (targetPoint - spawnPoint.position).normalized;

        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        projectile.transform.rotation = Quaternion.LookRotation(-shootDirection);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = shootDirection * projectileSpeed;
        }

        ProjectileDestroyer destroyer = projectile.AddComponent<ProjectileDestroyer>();
        destroyer.Initialize(spawnPoint.position, maxDistanceFromPlayer);
    }
}
