using UnityEngine;
using UnityEngine.Events;

public class SignalingBox : MonoBehaviour
{
    private UnityEvent _worked = new UnityEvent();

    public bool IsWork { get; private set; } = false;

    public event UnityAction Worked
    {
        add => _worked.AddListener(value);
        remove => _worked.RemoveListener(value);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsWork)
            return;

        if (other.TryGetComponent<Animal>(out Animal animal))
        {
            IsWork = true;
            _worked.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!IsWork)
            return;

        if (other.TryGetComponent<Animal>(out Animal animal))
        {
            IsWork = false;
            _worked.Invoke();
        }
    }
}
