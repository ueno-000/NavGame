using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Buttonのベース処理
/// </summary>

public class OnMouseBace : MonoBehaviour
{
    [SerializeField] public GameObject[] _image;
  //  [SerializeField] AudioClip _audio;
    // マウスカーソルが対象オブジェクトに重なっている間コールされ続ける
    public virtual void  OnMouseOver()
    {
        Debug.Log("MouseOver!");
        _image[1].SetActive(true);
    }
    // マウスカーソルが対象オブジェクトから退出した時にコールされる
    public virtual void OnMouseExit()
    {
        Debug.Log("MouseExit!");
        _image[1].SetActive(false);
    }

}

