using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectView : MonoBehaviour
{
    [SerializeField] private Transform _fpsTransform;
    [SerializeField] private Transform _thirdPersonTransformView;
    [SerializeField] private bool _isFpsView = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _isFpsView = !_isFpsView;
        }

        transform.position = _isFpsView ? _fpsTransform.position : _thirdPersonTransformView.position;
    }
}
