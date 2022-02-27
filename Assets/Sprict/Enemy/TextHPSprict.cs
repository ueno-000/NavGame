using UnityEngine;
using UnityEngine.UI;
public class TextHPSprict :HPController
{
    [SerializeField] Text _hpText;

    //void Start()
    //{
    //    hpSlider = GetComponent<Slider>();
    //    //スライダーの最大値の設定
    //    hpSlider.maxValue = maxHp;
    //}

    /// <summary>Hpをスライダーに表示させるメソッド</summary>
    public void UpdateSlider(int hp)
    {
        hpSlider.value = hp;
        _hpText.text = hp.ToString();
    }
}
