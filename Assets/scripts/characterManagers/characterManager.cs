using System;
using UnityEngine;



//This script has our array and will manage our characters in the game
public class characterManager : MonoBehaviour
{
    public SceneChanger sceneChanger;
    public GameObject OfficePanel;
    public GameObject NewsPanel;
    private GameObject endScreen;
    public scriptableCharacters[] characters; //Array to hold our characters
    public int currentCharacterIndex = 0; //Index to track the current character
    public baseCharacter currentCharacter; //Reference to the current character 
    public baseCharacter baseCharacterSO; // Reference to baseCharacter ScriptableObject
    // If true, we previously showed baseCharacter as an inserted extra and must now show
    // the array character for the same index without incrementing the index.
    private bool baseInsertedPending = false;
    public bool rndExists = false;
    public void initCharacterArray()
    {
        Debug.Log("Initializing character array...");
        characters = Resources.LoadAll<scriptableCharacters>("scriptableObjects/characters");
        // Try to load the baseCharacter as a scriptableCharacters (so it has all fields), otherwise fallback
        scriptableCharacters baseAsSC = Resources.Load<scriptableCharacters>("scriptableObjects/characters/baseCharacter");
        if (baseAsSC != null)
            baseCharacterSO = baseAsSC;
        else
            baseCharacterSO = Resources.Load<baseCharacter>("scriptableObjects/characters/baseCharacter");

        if ((characters == null || characters.Length == 0) && baseCharacterSO == null)
        {
            Debug.Log("No characters or baseCharacter found in Resources/scriptableObjects/characters");
            return;
        }
        // Select the initial current character (start with first array entry if available)
        if (characters != null && characters.Length > 0)
        {
            currentCharacterIndex = Mathf.Clamp(currentCharacterIndex, 0, characters.Length - 1);
            currentCharacter = characters[currentCharacterIndex];
        }
        else if (baseCharacterSO != null)
        {
            currentCharacter = baseCharacterSO;
        }
    }
    void Start()
    {
        initCharacterArray();
        Debug.Log("Character Manager initialized with " + (characters == null ? 0 : characters.Length) + " characters.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void checkRoundOver()
    {
        Debug.Log("checking value of rndExist bool"+ rndExists);
            if (currentCharacterIndex == 3 && rndExists == false)
            {
                sceneChanger.changeScene(NewsPanel);
            }
        Debug.Log("Checking if round is over at character index: " + currentCharacterIndex);

            if (currentCharacterIndex == 6 && rndExists == false)
            {
                OfficePanel.SetActive(false);
                NewsPanel.SetActive(true);
                // sceneChanger.changeScene(NewsPanel);
            }
            else if (currentCharacterIndex == 9 && rndExists == false)
            {
                OfficePanel.SetActive(false);
                NewsPanel.SetActive(true);
                // sceneChanger.changeScene(NewsPanel);
            }
    
        Debug.Log("Checking if round is over at character index: " + currentCharacterIndex);
        }  

    public void AdvanceToNextCharacter()
{
        // If we previously inserted the baseCharacter as an extra, next call should show
        // the array character for the same index (do not increment index).
  

        if (baseInsertedPending)
        {
            baseInsertedPending = false;
            if (characters != null && currentCharacterIndex >= 0 && currentCharacterIndex < characters.Length)
                currentCharacter = characters[currentCharacterIndex];
            else if (baseCharacterSO != null)
                currentCharacter = baseCharacterSO;
            Debug.Log("Showing array character after inserted base for index: " + currentCharacterIndex);
            checkRoundOver();
            return;
        }

        // Normal advance: move to next index and decide whether to insert baseCharacter as an extra
       
       
        currentCharacterIndex++;

        if (characters != null && currentCharacterIndex < characters.Length)
        {
            if (baseCharacterSO != null && baseCharacterSO.chanceToAppear > 0)
            {
                int roll = UnityEngine.Random.Range(0, 100);
                if (roll < baseCharacterSO.chanceToAppear)
                {
                    // Insert baseCharacter as an extra popup before showing the array character
                    rndExists = true;
                    currentCharacter = baseCharacterSO;
                    baseInsertedPending = true;
                    Debug.Log($"baseCharacter inserted as extra ({baseCharacterSO.chanceToAppear}%) at index {currentCharacterIndex} (roll={roll})");
                    checkRoundOver();
                    if (rndExists == true)
                    {
                        rndExists = false;
                    }
                    return;
                }
            }

            // No insertion: show the array character for the new index
            currentCharacter = characters[currentCharacterIndex];
        }
        else
        {
            Debug.Log("Advanced past last character index: " + currentCharacterIndex);
        }

        Debug.Log("Advanced to character index: " + currentCharacterIndex);
        checkRoundOver();
}

    // (Removed ChooseCharacterForIndex - insertion is handled by AdvanceToNextCharacter)

    
    }


