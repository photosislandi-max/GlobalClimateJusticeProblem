using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.UIElements;

public class BarScript : MonoBehaviour
{
    public Slider climateSlider;
    public Slider justiceSlider;
    public Slider economySlider;

    public int maxValue = 100;

    void Start()
    {
        // Debug.Log($"climateSlider: {climateSlider}");
        // Slider[] allSliders = GetComponentsInChildren<Slider>();
        // if (allSliders.Length >= 3)
        // {
        //     climateSlider = allSliders[0];
        //     justiceSlider = allSliders[1];
        //     economySlider = allSliders[2];

        //     climateSlider.maxValue = maxValue;
        //     justiceSlider.maxValue = maxValue;
        //     economySlider.maxValue = maxValue;
        // }
        // else
        // {
        //     Debug.LogError("Not enough sliders found in children.");
        // }
        climateSlider.maxValue = maxValue;
        justiceSlider.maxValue = maxValue;
        economySlider.maxValue = maxValue;
    }

    void Update()
    {
        // if (climateSlider != null && justiceSlider != null && economySlider != null)
        // {
        //     climateSlider.value = staticBarIntergers.climateBar;
        //     justiceSlider.value = staticBarIntergers.justiceBar;
        //     economySlider.value = staticBarIntergers.EconomyBar;
        // }
        // else
        // {
        //     Debug.LogError("One or more sliders are not assigned.");
        // }
        climateSlider.value = staticBarIntergers.climateBar;
        justiceSlider.value = staticBarIntergers.justiceBar;
        economySlider.value = staticBarIntergers.EconomyBar;
    }
}
