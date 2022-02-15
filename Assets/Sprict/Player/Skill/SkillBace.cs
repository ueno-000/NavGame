using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBace : MonoBehaviour
{
    public GameObject _setumeiImage;

    // マウスカーソルが対象オブジェクトに重なっている間コールされ続ける
    public virtual void  OnMouseOver()
    {
        Debug.Log("MouseOver!");
        _setumeiImage.SetActive(true);
    }
    // マウスカーソルが対象オブジェクトから退出した時にコールされる
    public virtual void OnMouseExit()
    {
        Debug.Log("MouseExit!");
        _setumeiImage.SetActive(false);
    }

}

