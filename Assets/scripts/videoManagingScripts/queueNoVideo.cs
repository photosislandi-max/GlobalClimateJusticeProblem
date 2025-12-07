using UnityEngine;
using UnityEngine.Video;

public class QueueNoVideo : MonoBehaviour
{
    public characterManager manager;   // assign this in inspector

    // This is called by the NO button's OnClick event
    public void QueueCurrentCharacterNoVideo()
    {
        // if (manager == null)
        // {
        //     Debug.LogError("QueueNoVideo: No characterManager assigned!"); //only important for debugging
        //     return;
        // }

        // get the active character
        var current = manager.currentCharacter;

        // if (current == null)
        // {
        //     Debug.LogWarning("QueueNoVideo: No current character found."); //only important for debugging
        //     return;
        // }

        // ensure it has a video
        // if (current.videoNoButton == null) //only important for debugging
        // {
        //     Debug.LogWarning($"QueueNoVideo: Character {current.charactername} has no NO video assigned.");
        //     return;
        // }

        // queue the video using your persistent manager
        if (videoDecisionManager.Instance != null)
        {
            videoDecisionManager.Instance.AddVideo(current.videoNoButton);
            Debug.Log($"Queued NO video for character: {current.charactername}");
        }
        // else
        // {
        //     Debug.LogError("QueueNoVideo: GameDecisionManager instance not found. Make sure it exists in the first scene."); //only important for debugging
        // }
    }
}
