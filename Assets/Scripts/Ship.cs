using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _impulseStrength = 10f;
    [SerializeField] private float _torqueStrength = 10f;

    [Header("Input")]
    [SerializeField] private InputActionReference _thrust;
    [SerializeField] private InputActionReference _rotate;
    private float _rotateInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        CheckThrust();
        CheckRotation();
    }

    private void CheckThrust()
    {
        if (_thrust.action.WasPerformedThisFrame())
        {
            Debug.Log("Thrusting!");
        }
        if (_thrust.action.WasReleasedThisFrame())
        {
            Debug.Log("Stop Thrusting!");
        }
    }

    private void CheckRotation()
    {
        _rotateInput = _rotate.action.ReadValue<float>();

        if (_rotateInput < 0)
        {   
            Debug.Log("Rotating Left");
        }
        else if (_rotateInput > 0)
        {
            Debug.Log("Rotating Right");
        }
    }
}
