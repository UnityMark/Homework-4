using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Text _labelHelath;

    public void Update()
    {
        _labelHelath.text = $"Health: {_player.Health.GetHealth()}";
    }
}
