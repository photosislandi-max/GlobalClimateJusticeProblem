using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
using DialougeSystem;

public class characterDisplay : DialougeBaseClass

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
    //No Button Effect
    public TMP_Text noeconomyEffect;
    public TMP_Text noclimateEffect;
    public TMP_Text noglobalJusticeEffect;


    [SerializeField] private TMP_FontAsset tmp_Font;

    private int lastCharacterIndex = -1;
    private baseCharacter lastBaseCharacter = null;

    void Start()
    {
        
        characterData = Manager.currentCharacter as scriptableCharacters;
        lastBaseCharacter = Manager.currentCharacter;
        lastCharacterIndex = Manager.currentCharacterIndex;
        
        StartCoroutine(WriteText(characterData.issuedescription, issueDescription, tmp_Font));
    }

    void Update()
    {
        var data = Manager.currentCharacter;

        // Hvis karakteren har ændret sig, start typewriter effekten igen
      if (data != lastBaseCharacter)
        {
        lastBaseCharacter = data;
        lastCharacterIndex = Manager.currentCharacterIndex; 
        StopAllCoroutines();
        StartCoroutine(WriteText(data.issuedescription, issueDescription, tmp_Font));
        }

        characterArtwork.sprite = data.characterArtwork;
        speechBubbleArtwork.sprite = data.speechBubbleArtwork;

        baseCharacter baseChar = Manager.currentCharacter;
        if (baseChar == null)
            return;
            
        yeseconomyEffect.text = baseChar.yesEconomyBarInt.ToString();

        

        
    }
}