using UnityEngine;

[CreateAssetMenu(fileName = "newCharacter", menuName = "createCharacter")]
public class scriptableCharacters : ScriptableObject
{
    public string charactername;
    public string issuedescription;

    public Sprite characterArtwork;
    public Sprite speechBubbleArtwork;

    public int yesClimateBarInt;
    public int yesJusticeBarInt;
    public int yesEconomyBarInt;
    public int noClimateBarInt;
    public int noJusticeBarInt;
    public int noEconomyBarInt;
}
