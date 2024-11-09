using UnityEngine;

public class RaycastHandler
{
    private LayerMask _layerMask;

    public RaycastHandler(LayerMask layerMask)
    {
        _layerMask = layerMask;
    }

    public Vector3? GetPointClick()
    {
        Ray ray = GetRayFromMouse();
        Collider hitInfoCollider;

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _layerMask))
        {
            hitInfoCollider = hitInfo.collider;
            //return hitInfo.transform.position;
            return hitInfo.point;
        }

        return null;
    }

    private Ray GetRayFromMouse() => Camera.main.ScreenPointToRay(Input.mousePosition);
}

