using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    public Slider climateSlider;
    public Slider justiceSlider;
    public Slider economySlider;

    public int maxValue = 100;

    void Start()
    {
        climateSlider.maxValue = maxValue;
        justiceSlider.maxValue = maxValue;
        economySlider.maxValue = maxValue;
    }

    void Update()
    {
        climateSlider.value = staticBarIntergers.climateBar;
        justiceSlider.value = staticBarIntergers.justiceBar;
        economySlider.value = staticBarIntergers.EconomyBar;
    }
}
