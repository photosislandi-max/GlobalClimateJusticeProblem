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

//Yes button cost
    public TMP_Text yeseconomyEffect;

    public VideoClip characterVideo;

    public RenderTexture videoTexture;

    void Start()
    {
        characterData = Manager.currentCharacter;
    }
    
    void Update()
    {
        var data = Manager.currentCharacter;

        issueDescription.text = data.issuedescription;

        characterArtwork.sprite = data.characterArtwork;
        speechBubbleArtwork.sprite = data.speechBubbleArtwork;


        
        yeseconomyEffect.text = data.yesEconomyBarInt.ToString();

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