using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "baseCharacter", menuName = "Scriptable Objects/baseCharacter")]
public class baseCharacter : ScriptableObject
{
    public string charactername;
    public string issuedescription;
    public int yesClimateBarInt;
    public int yesEconomyBarInt;
    public int yesJusticeBarInt;
    public Sprite speechBubbleArtwork;
    public Sprite characterArtwork;
    public VideoClip videoNoButton;

    [Range(0,100)]
    public int chanceToAppear = 0; 
}
