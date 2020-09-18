using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class RubyController : MonoBehaviour, ControlsConfig.IGameplayActions, HealthCollector
{
    private Rigidbody2D _rigidBody;
    private ControlsConfig _config;

    [SerializeField]
    private float _speed = 1f;
    [SerializeField]
    private int _maxHealth = 5;

    private float HorizontalMovement { get; set; } = 0f;
    private float VerticalMovement { get; set; } = 0f;
    public int Health
    {
        get;
        private set;
    }

    private void Awake()
    {
        _config = new ControlsConfig();
        _config.Gameplay.SetCallbacks(this);
    }

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        Health = _maxHealth;
    }

    private void OnEnable()
    {
        _config.Gameplay.Enable();
    }

    private void OnDisable()
    {
        _config.Gameplay.Disable();
    }

    public void OnHorizontalMove(InputAction.CallbackContext context)
    {
        HorizontalMovement = context.ReadValue<float>();
    }

    public void OnVerticalMovement(InputAction.CallbackContext context)
    {
        VerticalMovement = context.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        Vector2 position = _rigidBody.position;
        position += new Vector2(HorizontalMovement, VerticalMovement).normalized * _speed * Time.deltaTime;
        _rigidBody.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        Health = Mathf.Clamp(Health + amount, 0, _maxHealth);
    }

    public bool NeedHealth()
    {
        return Health < _maxHealth;
    }
}
