using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class characterDisplay : MonoBehaviour

{
    public scriptableCharacters characterData;
    public scriptableCharacters GetCharacterData()
{
    return characterData;
}

    public TMP_Text issueDescription;

    public Image characterArtwork;
    public Image speechBubbleArtwork;

//Yes button effect
    public TMP_Text yesclimateEffect;
    public TMP_Text yesglobalJusticeEffect;
    public TMP_Text yeseconomyEffect;

    //NO Button Effect
    public TMP_Text noclimateEffect;
    public TMP_Text noglobalJusticeEffect;
    public TMP_Text noeconomyEffect;

    void Start()
    {
        issueDescription.text = characterData.issuedescription;

        characterArtwork.sprite = characterData.characterArtwork;

        speechBubbleArtwork.sprite = characterData.speechBubbleArtwork;

        yesclimateEffect.text = characterData.yesClimateBarInt.ToString();
        
        yesglobalJusticeEffect.text = characterData.yesJusticeBarInt.ToString();

        yeseconomyEffect.text = characterData.yesEconomyBarInt.ToString();


        noclimateEffect.text = characterData.noClimateBarInt.ToString();

        noglobalJusticeEffect.text = characterData.noJusticeBarInt.ToString();

        noeconomyEffect.text = characterData.noEconomyBarInt.ToString();
    }
}
