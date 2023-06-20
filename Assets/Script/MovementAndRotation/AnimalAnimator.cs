using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimalAnimator : MonoBehaviour
{
    private Animator _animator;
    private Vector3 _transformRight;
    private Vector3 _transformForward;   
    private float _standing = 0f;
    private float _walking = 1f;
    private float _run = 2f;
    private int _speed = Animator.StringToHash("Speed");
    private int _isStanding = Animator.StringToHash("isStanding");

    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat(_speed, _standing);
    }

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        _transformRight = transform.right * Input.GetAxis("Horizontal");
        _transformForward = Input.GetAxis("Vertical") * transform.forward;       

        if ((_transformRight + _transformForward).magnitude > 0.1f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
                ExecuteMovement(_run);
            else
                ExecuteMovement(_walking);
        }
        else
        {
            ExecuteMovement(_standing);
        }       
    }

    private void ExecuteMovement(float targetSpeed)
    {        
        _animator.SetFloat(_speed, targetSpeed);
        _animator.SetBool(_isStanding, targetSpeed == 0);        
    }   
}
