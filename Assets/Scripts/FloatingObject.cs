using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingObject : MonoBehaviour
{
    [SerializeField] private Transform[] _floaters;
    [SerializeField] private float _underWaterDrag = 3f;
    [SerializeField] private float _underWaterAngularDrag = 1f;
    [SerializeField] private float _airDrag = 0f;
    [SerializeField] private float _airAngularDrag = 0.05f;
    [SerializeField] private float _floatingPower = 100f;
    [SerializeField]  private Rigidbody _rb;
    private int _floatersUnderWater; 
    private bool _isUnderWater;
    private OceanManager _ocean;

    private void Awake()
    {
        _ocean = FindObjectOfType<OceanManager>();
    }
    
    void FixedUpdate()
    {
        _floatersUnderWater = 0;

        for (int i = 0; i < _floaters.Length; i++)
        {
            float difference = _floaters[i].position.y - _ocean.WaterHeightAtPos(_floaters[i].position);

            if (difference < 0)
            {
                _rb.AddForceAtPosition(Vector3.up * _floatingPower * Mathf.Abs(difference), _floaters[i].position, ForceMode.Force);
                _floatersUnderWater += 1;

                if (!_isUnderWater)
                {
                    _isUnderWater = true;
                    SwichState(true);
                }
            }

        }


        if (_isUnderWater && _floatersUnderWater == 0)
        {
            _isUnderWater = false;
            SwichState(false);
        }
    }
    private void SwichState(bool activ)
    {
        if (activ)
        {
            _rb.drag = _underWaterDrag;
            _rb.angularDrag = _underWaterAngularDrag;
        }
        else
        {
            _rb.drag = _airDrag;
            _rb.angularDrag = _airAngularDrag;
        }
    }

   
}
