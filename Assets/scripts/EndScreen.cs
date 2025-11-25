using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    // UI-tekstfelter som du tr�kker ind fra Unity
    public TMP_Text climateText;
    public TMP_Text justiceText;
    public TMP_Text economyText;
    
    public characterManager characterManager;
    public TMP_Text endingTitleText;
    public TMP_Text endingDescriptionText;

    void OnEnable()
    {
        // N�r scenen starter, vis scores og ending
        ShowScores();
        ShowEnding();
    }

    void ShowScores()
    {
        // Gem scores lokalt s� det er lettere at arbejde med
        int c = staticBarIntergers.climateBar;
        Debug.Log("Climate Score: " + c);
        int j = staticBarIntergers.justiceBar;
        int e = staticBarIntergers.EconomyBar;

        // Vis tallene
        climateText.text = "Climate: " + c + "   (" + GetRating(c) + ")";
        justiceText.text = "Justice: " + j + "   (" + GetRating(j) + ")";
        economyText.text = "Economy: " + e + "   (" + GetRating(e) + ")";
    }

    // Returnerer en tekst baseret p� scoren
    string GetRating(int value)
    {
        if (value < 40)
            return "Bad";

        if (value > 75)
            return "Good";

        return "Mediocre";
    }

    void ShowEnding()
    {
        int c = staticBarIntergers.climateBar;
        int j = staticBarIntergers.justiceBar;
        int e = staticBarIntergers.EconomyBar;

        // Find den h�jeste score og v�lg ending
        if (c >= j && c >= e)
        {
            endingTitleText.text = "Green Future";
            endingDescriptionText.text = "You prioritized the climate";
        }
        else if (j >= c && j >= e)
        {
            endingTitleText.text = "Jutice!";
            endingDescriptionText.text = "You chose to focus on climatejustice";
        }
        else
        {
            endingTitleText.text = "Economical Boom";
            endingDescriptionText.text = "You focused on the economy.";
        }
    }

    public void RestartGame()
    {
        // Nulstil score hvis I vil starte forfra
        staticBarIntergers.climateBar = 70;
        staticBarIntergers.justiceBar = 0;
        staticBarIntergers.EconomyBar = 3;
        characterManager.currentCharacterIndex = 0;
        // Load spillet igen
        SceneManager.LoadScene("jeppeScene");
    }
}
