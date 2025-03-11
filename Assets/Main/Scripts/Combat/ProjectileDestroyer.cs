using UnityEngine;
public class ProjectileDestroyer : MonoBehaviour
{
    private Vector3 spawnPosition;
    private float maxDistance;

    public void Initialize(Vector3 spawnPos, float maxDist)
    {
        spawnPosition = spawnPos;
        maxDistance = maxDist;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, spawnPosition) > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}