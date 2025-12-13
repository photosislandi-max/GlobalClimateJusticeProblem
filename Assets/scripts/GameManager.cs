using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SceneChanger scenechanger;
    public GameObject newsPanel;
    public bool isGameOver = false;
    public GameObject officePanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        if (officePanel.activeSelf == true && staticBarIntergers.climateBar <= 0) // Check if the office panel is active and climate bar is 0 or less (should only trigger when in office and Game Over condition met)
        {
            isGameOver = true;
            scenechanger.changeScene(newsPanel);
        }

        // Clamp the bar values between 0 and 100
        if (staticBarIntergers.justiceBar > 100)
        {
            staticBarIntergers.justiceBar = 100;
        }
        if (staticBarIntergers.climateBar > 100)
        {
            staticBarIntergers.climateBar = 100;
        }
        if (staticBarIntergers.EconomyBar > 100)
        {
            staticBarIntergers.EconomyBar = 100;
        }
        if (staticBarIntergers.justiceBar < 0)
        {
            staticBarIntergers.justiceBar = 0;
        }
        if (staticBarIntergers.EconomyBar < 0)
        {
            staticBarIntergers.EconomyBar = 0;
        }
    }
}
