using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class RubyController : MonoBehaviour, ControlsConfig.IGameplayActions
{
    private Rigidbody2D _rigidBody;

    private float HorizontalMovement { get; set; } = 0f;
    private float VerticalMovement { get; set; } = 0f;

    [SerializeField]
    private float _speed = 1f;
    [SerializeField]
    private int _maxHealth = 5;
    private int _currentHealth;
    private ControlsConfig config;

    private void Awake()
    {
        config = new ControlsConfig();
        config.Gameplay.SetCallbacks(this);
    }

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _currentHealth = _maxHealth;
    }

    private void OnEnable()
    {
        config.Gameplay.Enable();
    }

    private void OnDisable()
    {
        config.Gameplay.Disable();
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

    private void ChangeHealth(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, _maxHealth);
    }
}
