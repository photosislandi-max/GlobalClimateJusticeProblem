using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChecker : MonoBehaviour
{
    // public characterManager ManagerInput; 
    public characterManager characterManager;
    public scriptableCharacters characterData;
    public scriptableCharacters GetCharacterData()
    {
        return characterData;
    }
    public Button redButton;
    public Button greenButton;
    public Animator animator;

    void Awake()
    {
        if (characterManager == null)
        {
            characterManager = Object.FindFirstObjectByType<characterManager>();
        }

        if (characterManager != null)
        {
            // Ensure currentCharacter is set to the character at currentCharacterIndex if it's null
            if (characterManager.currentCharacter == null && characterManager.characters != null && characterManager.characters.Length > 0)
            {
                characterManager.currentCharacterIndex = Mathf.Clamp(characterManager.currentCharacterIndex, 0, characterManager.characters.Length - 1);
                characterManager.currentCharacter = characterManager.characters[characterManager.currentCharacterIndex];
            }
            characterData = characterManager.currentCharacter;
        }
    }
    
    public void OnRedButtonPressed()
    {
        animator.SetTrigger("redpress");

        // Use the currently shown character's values first   

        characterData = characterManager.currentCharacter;
        UnityEngine.Debug.Log("Red Button Pressed. Current Character: " + characterManager.currentCharacterIndex);
        staticBarIntergers.climateBar += characterData.noClimateBarInt;
        staticBarIntergers.justiceBar += characterData.noJusticeBarInt;
        staticBarIntergers.EconomyBar += characterData.noEconomyBarInt;

        characterManager.AdvanceToNextCharacter();
        characterManager.currentCharacter = characterManager.characters[characterManager.currentCharacterIndex];

    }

    public void OnGreenButtonPressed()
    {
        animator.SetTrigger("greenpress");

        characterData = characterManager.currentCharacter;
        
        staticBarIntergers.climateBar += characterData.yesClimateBarInt;
        staticBarIntergers.justiceBar += characterData.yesJusticeBarInt;
        staticBarIntergers.EconomyBar += characterData.yesEconomyBarInt;
        
        characterManager.AdvanceToNextCharacter();
        characterManager.currentCharacter = characterManager.characters[characterManager.currentCharacterIndex];
    }
}
