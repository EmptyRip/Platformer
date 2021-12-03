using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;

    private Rigidbody2D _rigidBody;
    private Animator _animator;

    private const string _isRunning = "isRunning";
    private float _groundRadius = 0.3f;
    private bool _facingRight = true;
    private bool _isGrounded;       

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        _rigidBody.MovePosition(_rigidBody.position + Vector2.right * moveX * _speed * Time.deltaTime);
        if (_facingRight == false && moveX > 0)
        {
            Flip();
        }
        else if (_facingRight == true && moveX < 0)
        {
            Flip();
        }
        if (moveX == 0)
        {
            _animator.SetBool(_isRunning, false);
        }
        else
        {
            _animator.SetBool(_isRunning, true);
        }

        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _groundMask);


        if (Input.GetKeyDown (KeyCode.Space) && _isGrounded)
        {
            _rigidBody.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
