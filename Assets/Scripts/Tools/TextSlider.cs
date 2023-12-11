using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextSlider : MonoBehaviour 
{
    [SerializeField]private Slider slider;
    [SerializeField] private TextMeshProUGUI txt;

    private void Start()
    {
        slider.value = 0;
        txt.text = "1";
    }

    public void UpgradeSlider(float current, float max)
    {
        slider.value = current / max;
    }

    public void SetText(string txt)
    {
        this.txt.text = txt;
    }
}

