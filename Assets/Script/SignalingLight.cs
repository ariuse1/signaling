using UnityEngine;

public class SignalingLight : MonoBehaviour
{
    [SerializeField] private float _rotatoinSpeed = 250f;
    [SerializeField] private GameObject _staticLights;
    [SerializeField] private GameObject _rotatoinLights;   

    private void Start()
    {       
        _staticLights.GetComponentInChildren<Light>().enabled = false;
        _rotatoinLights.GetComponentInChildren<Light>().enabled = false;
    }

    public void Switch(bool isActive)
    {
        _staticLights.GetComponentInChildren<Light>().enabled = isActive;
        _rotatoinLights.GetComponentInChildren<Light>().enabled = isActive;
    }

    public void Rotate(bool isActive)
    {
        if (isActive)
        { 
            _rotatoinLights.transform.Rotate(0, 0, Time.deltaTime * _rotatoinSpeed); 
        }
    }
}
