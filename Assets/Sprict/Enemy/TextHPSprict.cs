using UnityEngine;
using UnityEngine.UI;
public class TextHPSprict :HPController
{
    [SerializeField] Text _hpText;

    //void Start()
    //{
    //    hpSlider = this.GetComponent<Slider>();
    //    //スライダーの最大値の設定
    //    hpSlider.maxValue = _maxHp;
    //}

    /// <summary>Hpをスライダーに表示させるメソッド</summary>
    public override void UpdateSlider(int hp)
    {
        hpSlider.value = hp;
        _hpText.text = hp.ToString();
    }
}
