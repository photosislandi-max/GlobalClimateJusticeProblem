using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "baseCharacter", menuName = "Scriptable Objects/baseCharacter")]
public class baseCharacter : ScriptableObject
{
    public string charactername;
    public string issuedescription;
// Sprite should be replaced by Image
    public Sprite characterArtwork;
    public Sprite speechBubbleArtwork;

    public int yesClimateBarInt;
    public int yesEconomyBarInt;
    public int yesJusticeBarInt;


    public VideoClip videoNoButton;

    [Range(0,100)]
    public int chanceToAppear = 0; 
}
