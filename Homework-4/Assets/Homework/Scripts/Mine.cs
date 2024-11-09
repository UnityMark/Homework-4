using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private BoxCollider _colider;
    [SerializeField] private Vector3 _offsetPositionGizmo;
    [SerializeField] private Vector3 _offsetScaleGizmo;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position + _offsetPositionGizmo, _offsetScaleGizmo);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if(player != null)
        {
            player.Health.ReduceHealth(_damage);
            player.CharacterView.DoHit();
            Destroy(this.gameObject);
        }
    }
}
