using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameContoller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _posY;
    [SerializeField] private TextMeshProUGUI _power;
    [SerializeField] private Button _btn;
    [SerializeField] private FloatingObject[] _cube;

    void Start()
    {
        _btn.onClick.AddListener(() => UpPos());
    }

    void Update()
    {
        _posY.text = _cube[0].transform.position.y.ToString();
    }

    private void UpPos()
    {
        for (int i = 0; i < _cube.Length; i++)
            _cube[i].FloatingPoweUp();
        _power.text = _cube[0].PowerFloating.ToString();
    }
}
