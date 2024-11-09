using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    [Header("General")]
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private GameObject _modelsFlag;

    [Header("Animation")]
    [SerializeField] private CharacterView _characterView;

    private RaycastHandler _raycastHandler;
    private Movement _movement;
    private GameObject _flag;
    private Health _health;

    private float _minDistaceForRemoveFlag = 0.4f;
    private float _defaultSpeed = 1.5f;
    private float _injuredSpeed = 1f;
    private float _healthForInjured = 30f;
    private bool _isDie = false;

    private const int RIGHT_MOUSE_BUTTON = 1;

    public Health Health => _health;
    public CharacterView CharacterView => _characterView;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        if (_isDie) return;

        if (IsCloseToFlag())
        {
            RemoveFlag();
            _characterView.EnabledMove(false);
        }

        if (Input.GetMouseButtonDown(RIGHT_MOUSE_BUTTON) && _raycastHandler.GetPointClick() != null) // заменить потом магическое число
        {
            Vector3 pointClick = (Vector3)_raycastHandler.GetPointClick();

            if (_movement.IsPathValid(pointClick))
            {
                _movement.Move(pointClick);
                SetFlag(pointClick);
                _characterView.EnabledMove(true);
            }
        }

        if(_health.GetHealth() <= 0f)
        {
            _isDie = true;
            _characterView.EnabledDie(_isDie);
        }
        else if(_health.GetHealth() <= _healthForInjured)
        {
            EnabledInjured(true);
        }
        else
        {
            EnabledInjured(false);
        }
    }

    private void Init()
    {
        _raycastHandler = new RaycastHandler(_layerMask);
        _movement = new Movement(_agent);
        _health = new Health(100);
    }

    private void EnabledInjured(bool isEnable)
    {
        if (isEnable)
        {
            _characterView.EnabledInjured(1);
            _agent.speed = _injuredSpeed;
            return;
        }

        _characterView.EnabledInjured(0);
        _agent.speed = _defaultSpeed;
    }

    private bool IsCloseToFlag()
    {
        if (_flag == null) return false;

        Vector2 player = new Vector2(this.transform.position.x, this.transform.position.z);
        Vector2 flag = new Vector2(_flag.transform.position.x, _flag.transform.position.z);

        if (Vector2.Distance(player, flag) < _minDistaceForRemoveFlag)
        {
            return true;
        }

        return false;
    }

    private void SetFlag(Vector3 point)
    {
        if(_flag != null)
        {
            Destroy(_flag);
        }

        _flag = Instantiate(_modelsFlag, point, Quaternion.identity);
    }

    private void RemoveFlag() => Destroy(_flag);
}
