using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rb;
    private Vector3 _direction;
    private float _horizontal;
    private float _vertical;
   
   
    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        if (_vertical > 0) _direction = transform.forward;
        else if (_vertical < 0) _direction = -transform.forward;
        if (_horizontal > 0) _direction = transform.right;
        else if (_horizontal < 0) _direction = -transform.right;
        if (_vertical == 0 && _horizontal == 0) _direction = Vector3.zero;
        transform.Translate(_direction * Time.deltaTime * _speed, Space.World);
    }
}
