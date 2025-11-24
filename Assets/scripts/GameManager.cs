using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SceneChanger scenechanger;
    private GameObject endScreen;
    public bool isGameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (staticBarIntergers.climateBar < 0)
        {
            //game over
            Debug.Log("Game Over: Climate Bar Depleted");
            isGameOver = true;
            // staticBarIntergers.climateBar = 0;
            scenechanger.changeScene(endScreen);
            // endScreen.SetActive(true);
        }
    }
}
