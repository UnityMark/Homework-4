using UnityEngine;
using UnityEngine.AI;

public class Movement
{
    private NavMeshAgent _agent;

    public Movement(NavMeshAgent agent)
    {
        _agent = agent;
    }

    public void Move(Vector3 point)
    {
        if (IsPathValid(point) == false) return;
        _agent.SetDestination(point);
    }

    public bool IsPathValid(Vector3 point)
    {
        NavMeshPath navMeshPath = new NavMeshPath();
        return _agent.CalculatePath(point, navMeshPath) && navMeshPath.status != NavMeshPathStatus.PathInvalid;
    }
}
