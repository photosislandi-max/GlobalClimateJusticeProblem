using System.Collections.Generic;
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
        // If Manager wasn't wired in the inspector, try to find one in the scene
        // if (Manager == null)
        //   Manager = FindObjectOfType<characterManager>();

        // Now it's safe to read Manager.currentCharacter
        characterData = Manager != null ? Manager.currentCharacter : null; // Get the current character data
        //Debug.Log("Character Data Loaded: " + (characterData != null ? characterData.charactername : "No Data"));
    }


    void Start()
    {
        
    }
    public void OnRedButtonPressed()
    {
        animator.SetTrigger("redpress");

        staticBarIntergers.climateBar+= characterData.noClimateBarInt;
        staticBarIntergers.justiceBar+= characterData.noJusticeBarInt;
        staticBarIntergers.EconomyBar+= characterData.noEconomyBarInt;
    }

    public void OnGreenButtonPressed()
    {
        animator.SetTrigger("greenpress");
        
        staticBarIntergers.climateBar+= characterData.yesClimateBarInt;
        staticBarIntergers.justiceBar+= characterData.yesJusticeBarInt;
        staticBarIntergers.EconomyBar += characterData.yesEconomyBarInt;
        
    }
}
