using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Transform _transform;

    public Rotator(Transform transform)
    {
        _transform = transform;
    }

    public void RotateTo(Vector3 direction)
    {
        Debug.Log($"Direction: {direction}");
        Quaternion lookRotation = Quaternion.LookRotation(direction.normalized);
        Debug.Log($"Direction normalized: {direction.normalized}");
        _transform.rotation = lookRotation;
    }
}
