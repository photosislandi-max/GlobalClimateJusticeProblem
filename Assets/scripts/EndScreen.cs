using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class EndScreenManager : MonoBehaviour
{
    // UI Elements to display scores and endings
    public TMP_Text climateText;
    public TMP_Text justiceText;
    public characterManager characterManager;
    public TMP_Text endingTitleText;
    public TMP_Text endingDescriptionText;

    void OnEnable()
    {
        // When the end screen is enabled, show scores and ending
        ShowScores();
        ShowEnding();
    }

    void ShowScores()
    {
        // Save scores locally so it's easier to work with
        int c = staticBarIntergers.climateBar;
        Debug.Log("Climate Score: " + c);
        int j = staticBarIntergers.justiceBar;
        int e = staticBarIntergers.EconomyBar;

        // Display scores
        if (c < 0) c = 0; // if climate score is negative, set to 0 to avoid displaying negative values

        climateText.text = "Climate: " + c + "   (" + GetRating(c) + ")";
        justiceText.text = "Justice: " + j + "   (" + GetRating(j) + ")";
    }

    // Return a text rating based on score value
    string GetRating(int value)
    {
        if (value < 40)
            return "Bad";

        if (value > 75)
            return "Good";

        return "Mediocre";
    }

    // Determine and display the appropriate ending based on scores
    void ShowEnding()
    {
        int c = staticBarIntergers.climateBar;
        int j = staticBarIntergers.justiceBar;
        int e = staticBarIntergers.EconomyBar;

        // Find the highest score and set ending accordingly
        if (c >= j && c >= e)
        {
            endingTitleText.text = "Green Future";
            endingDescriptionText.text = "You prioritized the climate";
        }
        else if (j >= c && j >= e)
        {
            endingTitleText.text = "Superior Global Judge!";
            endingDescriptionText.text = "You chose to focus on climatejustice";
        }
        else if (c <= 0)
        {
            endingTitleText.text = "Game Over - Climate Collapse";
            endingDescriptionText.text = "Your neglect of the climate has led to catastrophic consequences.";
        }
        else
        {
            endingTitleText.text = "You chose greed at the expense of climate and justice";
            endingDescriptionText.text = "You focused on the economy.";
        }
        
    }

    //Restart game by switching scene and resetting scores
    public void RestartGame()
    {
        // Reset scores and character index
        staticBarIntergers.climateBar = 50;
        staticBarIntergers.justiceBar = 0;
        staticBarIntergers.EconomyBar = 30;
        characterManager.currentCharacterIndex = 0;
        
        // Load game again
        SceneManager.LoadScene("MainScene3.0");
    }
}
