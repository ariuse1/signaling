using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _signaling;
    [SerializeField] private SignalingLight _light;

    private bool _isWork = false;

    private SignalingBox[] _signalings;

    private void Start()
    {
        _signaling.volume = 0;
        _signaling.enabled = false;
    }

    private void Update()
    {
        PlaySignaling();
        PlayLight();
    }

    private void OnEnable()
    {
        _signalings = gameObject.GetComponentsInChildren<SignalingBox>();

        foreach (var signaling in _signalings)
            signaling.Worked += Switch;
    }

    private void OnDisable()
    {
        _signalings = gameObject.GetComponentsInChildren<SignalingBox>();

        foreach (var signaling in _signalings)
            signaling.Worked -= Switch;
    }

    private void Switch()
    {
        foreach (var signaling in _signalings)
        {
            if (signaling.IsWork)
            {
                _isWork = true;
                return;
            }

            _isWork = false;
        }
    }

    private void PlaySignaling()
    {
        if (_isWork == false && _signaling.enabled == false)
            return;

        if (_signaling.enabled == false)
        {
            _signaling.enabled = true;
            _signaling.Play();
            StartCoroutine(ChangeVolume());
        }
    }

    private IEnumerator ChangeVolume()
    {
        float maxVolume = 1;
        float correctionValue = 0.1f;
        float soundCorrection = correctionValue * Time.deltaTime; ;

        while (_signaling.enabled)
        {
            if (_isWork && _signaling.volume < maxVolume)
                _signaling.volume += soundCorrection;
            else if (_isWork == false && _signaling.volume > 0)
                _signaling.volume -= soundCorrection;
            else if(_signaling.volume <= 0)
                _signaling.enabled = false;

            yield return null;
        }        
    }

    private void PlayLight()
    {
        bool isWork = _signaling.volume > 0;

        _light.Rotate(isWork);
        _light.Switch(isWork);
    }
}
