using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
public class scoreDisplay : MonoBehaviour
{
    public TMP_Text climateScoreText;
    public TMP_Text justiceScoreText;   
    public TMP_Text economyScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        climateScoreText.text = staticBarIntergers.climateBar.ToString();
        justiceScoreText.text = staticBarIntergers.justiceBar.ToString();
        economyScoreText.text = staticBarIntergers.EconomyBar.ToString();
    }
}
