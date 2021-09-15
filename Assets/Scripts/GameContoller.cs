using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameContoller : MonoBehaviour
{
    [SerializeField] private Button _exit;

    void Start()
    {
        _exit.onClick.AddListener(() => ExitGame());
    }

  
    private void ExitGame()
    {
        Application.Quit();
    }
}
