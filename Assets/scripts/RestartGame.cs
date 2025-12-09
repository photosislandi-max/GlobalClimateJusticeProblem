using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    public characterManager characterManager;
   public void RestartGame()
    {
        // Nulstil score hvis I vil starte forfra
        staticBarIntergers.climateBar = 70;
        staticBarIntergers.justiceBar = 0;
        staticBarIntergers.EconomyBar = 30;
        characterManager.currentCharacterIndex = 0;
        // Load spillet igen
        SceneManager.LoadScene("MainScene2.0");
    }
}
