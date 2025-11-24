using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "baseCharacter", menuName = "Scriptable Objects/baseCharacter")]
public class baseCharacter : ScriptableObject
{
    public string charactername;
    public string issuedescription;

    public Sprite characterArtwork;
    public Sprite speechBubbleArtwork;

    public Sprite iconBubbleArtwork;

    public int yesClimateBarInt;
    public int yesJusticeBarInt;
    public int yesEconomyBarInt;


    public VideoClip videoNoButton;
    [Range(0,100)]
    public int chanceToAppear = 0; // Percentage chance to appear
}
