using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public GameObject Introduction;
    public GameObject mainScene;
    // public GameObject endScene;
    public GameObject newsRoom;
    public GameManager gManager;
    public int currentCharacterIndex; 

    public GameObject endScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
    
    }
    public void changeScene(GameObject nameOfPanel)
    {
        // Deactivate all panels
        Introduction.SetActive(false);
        newsRoom.SetActive(false);
        mainScene.SetActive(false);
        endScreen.SetActive(false);
    
        // Activate the specified panel
        nameOfPanel.SetActive(true);
    }
}   