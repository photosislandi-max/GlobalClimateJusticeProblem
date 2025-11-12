using UnityEngine;
using TMPro;

public class barIntergersDisplay : MonoBehaviour
{
    public TMP_Text climateint;
    public TMP_Text justiceint;
    public TMP_Text economyint;

    public void Start()
    {
    }
    void Update()
    {
        climateint.text = staticBarIntergers.climateBar.ToString();
        justiceint.text = staticBarIntergers.justiceBar.ToString();
        economyint.text = staticBarIntergers.EconomyBar.ToString();
    }
}
