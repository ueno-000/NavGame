using UnityEngine;
using UnityEngine.UI;
public class TextHPSprict :HPController
{
    [SerializeField] Text _hpText;


    /// <summary>Hpをスライダーに表示させるメソッド</summary>
    public override void UpdateSlider(int hp)
    {
        hpSlider.value = hp;
        _hpText.text = hp.ToString();
    }
}
