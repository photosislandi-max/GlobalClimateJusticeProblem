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
        Introduction.SetActive(false);
        newsRoom.SetActive(false);
        mainScene.SetActive(false);
        endScreen.SetActive(false);
        if (gManager.isGameOver == true)
        {
            newsRoom.SetActive(true);
            gManager.isGameOver = false;
        }
        else
        {
            nameOfPanel.SetActive(true);
        }
       
    }
}   