using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Sceneが切り替わった時のフェイドアウト処理
/// </summary>
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
