using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SceneChanger scenechanger;
    public bool gameRunning = false;
    public bool isGameOver = false;
    public GameObject endScreen;

    public GameObject officePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void isGameOverCheck()
    {
        if (gameRunning == false) return;
        if (staticBarIntergers.climateBar <= 0)
        {
            //game over
            Debug.Log("Game Over: Climate Bar Depleted");
            isGameOver = true;
            // staticBarIntergers.climateBar = 0;
            scenechanger.changeScene(endScreen);
            // endScreen.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (officePanel.activeSelf == true)
        {
            gameRunning = true;
        } else {
            gameRunning = false;
        }
        // Clamp the bar values between 0 and 100
        if (staticBarIntergers.justiceBar > 100)
        {
            staticBarIntergers.justiceBar = 100;
        }
        if (staticBarIntergers.climateBar > 100)
        {
            staticBarIntergers.climateBar = 100;
        }
        if (staticBarIntergers.EconomyBar > 100)
        {
            staticBarIntergers.EconomyBar = 100;
        }
        if (staticBarIntergers.justiceBar < 0)
        {
            staticBarIntergers.justiceBar = 0;
        }
        if (staticBarIntergers.EconomyBar < 0)
        {
            staticBarIntergers.EconomyBar = 0;
        }

        isGameOverCheck();
        

        
    }
}
