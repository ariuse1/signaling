using UnityEngine;

public class SignalingLight : MonoBehaviour
{
    [SerializeField] private float _rotatoinSpeed = 250f;
    [SerializeField] private GameObject _staticLights;
    [SerializeField] private GameObject _rotatoinLights;

    private Light IsLightOn { get; set; }
    private Light IsRotatoin { get; set; }

    private void Start()
    {
        IsLightOn = _staticLights.GetComponentInChildren<Light>();
        IsRotatoin = _rotatoinLights.GetComponentInChildren<Light>();      
    }    

    public void Switch(bool isActive)
    {
        IsLightOn.enabled = isActive;
        IsRotatoin.enabled = isActive;
    }

    public void Rotate(bool isActive)
    {
        if (isActive)
        {
            _rotatoinLights.transform.Rotate(0, 0, Time.deltaTime * _rotatoinSpeed);
        }
    }
}
