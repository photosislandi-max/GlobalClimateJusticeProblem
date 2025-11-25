using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public GameObject Introduction;
    public GameObject mainScene;
    public GameObject endScene;
    public GameObject newsRoom;
    public int currentCharacterIndex; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
    
    }
  public void checkGameOver(string nameOfPanel)
  {
        Introduction.SetActive(false);
         newsRoom.SetActive(false);
         mainScene.SetActive(false);
         endScene.SetActive(true);

  }
    public void changeThat(string nameOfPanel)
    {
        Introduction.SetActive(false);
         newsRoom.SetActive(false);
         mainScene.SetActive(true);
         endScene.SetActive(false);

    }
}   