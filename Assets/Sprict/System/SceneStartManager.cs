using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneStartManager : MonoBehaviour
{
    [SerializeField] Scenemanager _sceneManager;
    [Header("FadePanelをアクティブにしてアタッチ"),SerializeField] Image _image;
    void Start()
    {
        _image.color = Color.black;
        _sceneManager.Fade(true, null);
    }
}
