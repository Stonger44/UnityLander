using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour
{
    [Header("Body")]
    [SerializeField] private Rigidbody rb;

    [Header("Movement")]
    [SerializeField] private float _thrustStrength = 10;
    [SerializeField] private float _torqueStrength = 10;

    [Header("Input")]
    [SerializeField] private InputActionReference _thrust;
    [SerializeField] private InputActionReference _rotate;
    [SerializeField] private bool _isThrusting;
    private float _rotateInput;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularDamping = 25;
    }

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
            _isThrusting = true;
        }
        if (_thrust.action.WasReleasedThisFrame())
        {
            _isThrusting = false;
        }

        Thrust(_isThrusting);
    }

    private void Thrust(bool isThrusting = false)
    {
        if (isThrusting)
        {
            rb.AddForce(this.transform.up * _thrustStrength);
        }
    }

    private void CheckRotation()
    {
        _rotateInput = _rotate.action.ReadValue<float>();
        // print($"Rotate Input: {_rotateInput}");
        
        rb.AddTorque(Vector3.back * _rotateInput * _torqueStrength);
    }
}
