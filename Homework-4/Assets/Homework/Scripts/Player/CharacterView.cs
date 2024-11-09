using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly int IsMove = Animator.StringToHash("IsMove");
    private readonly int IsHit = Animator.StringToHash("IsHit");
    private readonly int IsDie = Animator.StringToHash("IsDie");

    private int _injuredLayer;

    private void Awake()
    {
        _injuredLayer = _animator.GetLayerIndex("Injured");
    }

    public void EnabledMove(bool isEnable) => _animator.SetBool(IsMove, isEnable);
    public void EnabledDie(bool isEnable) => _animator.SetBool(IsDie, isEnable);
    public void DoHit() => _animator.SetTrigger(IsHit);
    public void EnabledInjured(int value)
    {
        if (value > 1) value = 1;
        else if (value < 0) value = 0;
        
        _animator.SetLayerWeight(_injuredLayer, value);
    } 
    
}
