using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerInputs))]
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _horizontalSpeed = 5F;
    [SerializeField] private Detector gndDetect;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _delay = 0.01f;
    
    [SerializeField] float RotationSmoothTime = 0.12f;
    
    
    private PlayerInputs _inputs;
    private CharacterController _controller;
    
    private float _targetRotation = 0.0f;
    private float _rotationVelocity;
    
    private Camera _mainCamera;
    private Vector3 _verticalVelocity;
    
    float lookX;
    float lookY;
        
    float MoveX;
    float MoveY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mainCamera = Camera.main;
        _inputs = GetComponent<PlayerInputs>();
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnAnimation();
        Gravity();
    }

    private void OnMove()
    {
        lookX = _inputs._look.x;
        lookY = _inputs._look.y;
        
        MoveX = _inputs._move.x;
        MoveY = _inputs._move.y;
        
        
        float lookDirectionX = lookX;
        
        transform.Rotate(0, lookDirectionX, 0);
        
        transform.forward = transform.rotation * Vector3.forward;
        
        _controller.Move((transform.forward * MoveY + transform.right * MoveX + _verticalVelocity) * Time.deltaTime * _horizontalSpeed);
    }

    private void Gravity()
    {
        // Gravity
        if (gndDetect.Detected)
        {
            _verticalVelocity = Vector3.zero;
        }
        else
        {
            _verticalVelocity += Physics.gravity * Time.deltaTime;
        }
    }
    
    

    private void OnAnimation()
    {
        if (MoveY >= 0.01f)
        {
            _animator.SetBool("MoveForward", true);
            _animator.SetFloat("velocity", MoveY);
        }
        else
        {
            _animator.SetBool("MoveForward", false);
            _animator.SetFloat("velocity", MoveY);
        }

        if (MoveX <= -0.01f)
        {
            _animator.SetBool("moveLeft", true);
            _animator.SetFloat("StrafeLeftVelocity", MoveX * -1);
        }
        else
        {
            _animator.SetBool("moveLeft", false);
            _animator.SetFloat("StrafeLeftVelocity", MoveX);
        }        
        if (MoveX >= 0.01f)
        {
            _animator.SetBool("moveRight", true);
            _animator.SetFloat("StrafeRightVelocity", MoveX);
        }
        else
        {
            _animator.SetBool("moveRight", false);
            _animator.SetFloat("StrafeRightVelocity", MoveX);
        }
    }

}
