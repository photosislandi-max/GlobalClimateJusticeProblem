using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChecker : MonoBehaviour
{
    
    public characterManager Manager;
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
    }

    /* Initializes the character data on start */
    void Start()
    {
        if (Manager == null)
        {
            Manager = Object.FindFirstObjectByType<characterManager>();
        }
        characterData = Manager.currentCharacter;
    }

    /* Updates the character data based on the current character index in the manager */
    void updateCharacterData()
    {
        Manager.currentCharacter = Manager.characters[Manager.currentCharacterIndex];
        characterData = Manager.currentCharacter;
    }
    public void OnRedButtonPressed()
    {
        animator.SetTrigger("redpress");

        staticBarIntergers.climateBar += characterData.noClimateBarInt;
        staticBarIntergers.justiceBar += characterData.noJusticeBarInt;
        staticBarIntergers.EconomyBar += characterData.noEconomyBarInt;
        Manager.currentCharacterIndex++;                                                                          // Increment the character index to move to the next character
        updateCharacterData();                                                                                    // Update character data after incrementing the index
    }

    public void OnGreenButtonPressed()
    {
        animator.SetTrigger("greenpress");

        staticBarIntergers.climateBar += characterData.yesClimateBarInt;
        staticBarIntergers.justiceBar += characterData.yesJusticeBarInt;
        staticBarIntergers.EconomyBar += characterData.yesEconomyBarInt;
        Manager.currentCharacterIndex++;                                                                          // Increment the character index to move to the next character
        updateCharacterData();                                                                                    // Update character data after incrementing the index
        
    }
}
