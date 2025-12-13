using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject endSceneButton;
    public characterManager manager;
    public int currentCharacterIndex; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endSceneButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    
    {
        bool charactersDone = manager.currentCharacterIndex == 12;
        bool noVideosLeft = videoDecisionManager.Instance.videosToPlay.Count == 0;
    
        if (charactersDone && noVideosLeft || staticBarIntergers.climateBar <= 0)
        {
            endSceneButton.SetActive(true);
        }
      
    }
}
