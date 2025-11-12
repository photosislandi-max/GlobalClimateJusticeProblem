using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChecker : MonoBehaviour
{
       public scriptableCharacters characterData;
    public scriptableCharacters GetCharacterData()
{
    return characterData;
}
    public Button redButton;
    public Button greenButton;
    public Animator animator;

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
        
        staticBarIntergers.climateBar=+ characterData.yesClimateBarInt;
        staticBarIntergers.justiceBar=+ characterData.yesJusticeBarInt;
        staticBarIntergers.EconomyBar=+ characterData.yesEconomyBarInt;
    }
}
