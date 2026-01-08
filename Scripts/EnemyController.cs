using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    public Transform player;
    public Transform myPlatform;
    public float enemySpeed;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = enemySpeed;
    }

    void Update()
    {
        if (player != null && myPlatform != null)
        {
            if (IsPlayerOnPlatform())
            {
                agent.SetDestination(player.position);
            }
            else
            {
                agent.ResetPath();
            }

        }
    }

    bool IsPlayerOnPlatform()
    {
        Collider platformCollider = myPlatform.GetComponent<Collider>();
        if (platformCollider != null)
        {
            // console out
            
            // Get the bounds of the platform
            Bounds bounds = platformCollider.bounds;
            
            // Expand the bounds upwards to detect the player standing on top
            // We expand significantly on Y to ensure we catch the player even if they jump or the pivot is weird
            bounds.Expand(new Vector3(0, 5f, 0));

            // Check if the player's position is inside these bounds
            return bounds.Contains(player.position);
        }

        // Fallback if the platform has no collider: check distance (e.g., within 5 units)
        return Vector3.Distance(player.position, myPlatform.position) < 5f;
    }
}
