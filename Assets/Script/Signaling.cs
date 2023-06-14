using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using static UnityEngine.Rendering.DebugUI;

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

        Debug.Log(_signaling.enabled);
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
        }

        ChangeVolume();
    }

    private void ChangeVolume()
    {
        float maxVolume = 1;
        float correctionValue = 0.1f;
        float soundCorrection = correctionValue * Time.deltaTime; ;

        if (_isWork && _signaling.volume < maxVolume)
            _signaling.volume += soundCorrection;
        else if (_isWork == false && _signaling.volume > 0)
            _signaling.volume -= soundCorrection;
        else
            _signaling.enabled = false;
    }

    private void PlayLight()
    {
        bool isWork = _signaling.volume > 0;

        _light.Rotate(isWork);
        _light.Switch(isWork);
    }
}
