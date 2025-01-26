using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _reflector;
    [SerializeField] private Animator _animator;

    private bool _isOnGround = true;
    private string _moveAxis = "Horizontal";
    private int _speed = Animator.StringToHash(nameof(_speed));

    private void Update()
    {
        transform.Translate(Input.GetAxis(_moveAxis) * _speed * Time.deltaTime,0, 0);

        if (Input.GetAxis(_moveAxis) != 0)
        {
            _reflector.flipX = Input.GetAxis(_moveAxis) < 0;
        }
        else 
        {
            _animator.Play("idle");
        }

        _animator.SetFloat(_speed, Mathf.Abs(Input.GetAxis(_moveAxis)));

        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            _isOnGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground)) 
        {
            _isOnGround = true;
        }
    }
}
