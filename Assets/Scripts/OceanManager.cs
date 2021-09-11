using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanManager : MonoBehaviour
{
    [SerializeField] private float _wavesHeight;
    [SerializeField] private float _wavesFrequency;
    [SerializeField] private float _wavesSpeed;
    [SerializeField] private Transform _ocean;
    private Material _mat;
    private Texture2D _textureOcean;
    void Awake()
    {
        _mat = _ocean.GetComponent<Renderer>().material;
        _textureOcean = (Texture2D)_mat.GetTexture("_Water");
    }

    public float WaterHeightAtPos(Vector3 pos)
    {
        return _ocean.position.y + _textureOcean.GetPixelBilinear(pos.x + _wavesFrequency, pos.z + _wavesFrequency + Time.time * _wavesSpeed).g
            * _wavesHeight * _ocean.localScale.x;

    }
    private void OnValidate()
    {
        if (!_mat) return;
        _mat.SetFloat("_wavesHeight", _wavesHeight);
        _mat.SetFloat("_wavesFrequency", _wavesFrequency);
        _mat.SetFloat("_wavesSpeed", _wavesSpeed);
    }

}
