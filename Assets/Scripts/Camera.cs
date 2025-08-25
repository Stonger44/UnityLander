using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject _ship;
    [SerializeField] private Vector3 _cameraOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_ship == null)
        {
            Debug.LogError("Ship is null!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        FollowShip();
    }

    private void FollowShip()
    {
        this.transform.position = _ship.transform.position + _cameraOffset;
    }
}
