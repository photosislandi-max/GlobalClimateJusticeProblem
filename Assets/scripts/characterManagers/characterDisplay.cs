using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class characterDisplay : MonoBehaviour

{
    public characterManager Manager;
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

    public VideoClip characterVideo;

    public RenderTexture videoTexture;

    void Start()
    {
        characterData = Manager.currentCharacter as scriptableCharacters;
    }
    
    void Update()
    {
        // Always display base fields (these exist on baseCharacter)
        baseCharacter baseChar = Manager.currentCharacter;
        if (baseChar == null)
            return;

        issueDescription.text = baseChar.issuedescription;
        characterArtwork.sprite = baseChar.characterArtwork;
        speechBubbleArtwork.sprite = baseChar.speechBubbleArtwork;

        yesclimateEffect.text = baseChar.yesClimateBarInt.ToString();
        yesglobalJusticeEffect.text = baseChar.yesJusticeBarInt.ToString();
        yeseconomyEffect.text = baseChar.yesEconomyBarInt.ToString();

        // Try to display No-button fields from subclass; otherwise show empty or 0
        scriptableCharacters sc = baseChar as scriptableCharacters;
        if (sc != null)
        {
            noclimateEffect.text = sc.noClimateBarInt.ToString();
            noglobalJusticeEffect.text = sc.noJusticeBarInt.ToString();
            noeconomyEffect.text = sc.noEconomyBarInt.ToString();
        }
        else
        {
            noclimateEffect.text = "0";
            noglobalJusticeEffect.text = "0";
            noeconomyEffect.text = "0";
        }

        // characterData = Manager.currentCharacter;

        // issueDescription.text = characterData.issuedescription;

        // characterArtwork.sprite = characterData.characterArtwork;

        // speechBubbleArtwork.sprite = characterData.speechBubbleArtwork;

        // yesclimateEffect.text = characterData.yesClimateBarInt.ToString();

        // yesglobalJusticeEffect.text = characterData.yesJusticeBarInt.ToString();

        // yeseconomyEffect.text = characterData.yesEconomyBarInt.ToString();


        // noclimateEffect.text = characterData.noClimateBarInt.ToString();

        // noglobalJusticeEffect.text = characterData.noJusticeBarInt.ToString();

        // noeconomyEffect.text = characterData.noEconomyBarInt.ToString();
    }
}