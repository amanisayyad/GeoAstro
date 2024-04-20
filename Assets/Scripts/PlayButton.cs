using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public Button btn;

    void Start()
    {
        btn.onClick.AddListener(() => SceneManager.LoadScene("Earth"));
    }
}

