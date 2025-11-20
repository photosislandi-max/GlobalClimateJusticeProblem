using UnityEngine;

public class currentCharacterIndexButtonAddition : MonoBehaviour
{
    public characterManager characterManager;  // reference to the manager

    public void nextRoundCharacter()
    {
        videoDecisionManager.Instance.Clear();
        Debug.Log("Current Character Index: " + characterManager.currentCharacterIndex);
        videoDecisionManager.Instance.videosToPlay.Clear();
    }
}
