using UnityEngine;
using UnityEngine.InputSystem;

public class RubyController : MonoBehaviour, ControlsConfig.IGameplayActions
{
    private float HorizontalMovement { get; set; } = 0f;
    private float VerticalMovement { get; set; } = 0f;

    [SerializeField]
    private float _speed = 1f;
    private ControlsConfig config;

    private void Awake()
    {
        config = new ControlsConfig();
        config.Gameplay.SetCallbacks(this);
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

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(HorizontalMovement, VerticalMovement).normalized * Time.deltaTime * _speed);
    }

    public void OnVerticalMovement(InputAction.CallbackContext context)
    {
        VerticalMovement = context.ReadValue<float>();
    }
}
