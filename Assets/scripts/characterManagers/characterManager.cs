using System;
using Unity.VisualScripting;
using UnityEngine;


public class characterManager : MonoBehaviour
{
    public SceneChanger sceneChanger;
    public GameObject OfficePanel;
    public GameObject NewsPanel;
    public GameObject endScene;
    public scriptableCharacters[] characters; //Array to hold our characters
    public int currentCharacterIndex = 0; //Index to track the current character
    public baseCharacter currentCharacter; //Reference to the current character 
    public baseCharacter baseCharacterRND; // Reference to baseCharacter ScriptableObject
    // If true, we previously showed baseCharacter as an inserted extra and must now show
    // the array character for the same index without incrementing the index.
    public bool baseInsertedPending = false;
    public bool rndExists = false;
    public void initCharacterArray()
    {
        Debug.Log("Initializing character array...");
        characters = Resources.LoadAll<scriptableCharacters>("scriptableObjects/characters");
        scriptableCharacters baseCharacterAsScriptableCharacters = Resources.Load<scriptableCharacters>("scriptableObjects/characters/baseCharacter");
        if (baseCharacterAsScriptableCharacters != null)
            baseCharacterRND = baseCharacterAsScriptableCharacters;
        else
            baseCharacterRND = Resources.Load<baseCharacter>("scriptableObjects/characters/baseCharacter");

            if ((characters == null || characters.Length == 0) && baseCharacterRND == null)
        {
            Debug.Log("No characters or baseCharacter found in Resources/scriptableObjects/characters");
     return;
        }


        if (characters != null && characters.Length > 0)
        {
            currentCharacterIndex = Mathf.Clamp(currentCharacterIndex, 0, characters.Length - 1);
            currentCharacter = characters[currentCharacterIndex];
        }
        else if (baseCharacterRND != null)
        {
            currentCharacter = baseCharacterRND;
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
            if (currentCharacterIndex == 0 || currentCharacterIndex == 1 || currentCharacterIndex == 2)
            {
                baseCharacterRND.chanceToAppear = 0;
                Debug.Log("Increased baseCharacter chanceToAppear to 0%");
            }

            if (currentCharacterIndex == 3)
            {
                baseCharacterRND.chanceToAppear = 15;
                Debug.Log("Increased baseCharacter chanceToAppear to 15%");
            }

        Debug.Log("checking value of rndExist bool"+ rndExists);
            if (currentCharacterIndex == 6 && rndExists == false)
            {
                sceneChanger.changeScene(NewsPanel);
            }
        Debug.Log("Checking if round is over at character index: " + currentCharacterIndex);

            if (currentCharacterIndex == 9 && rndExists == false)
            {
                OfficePanel.SetActive(false);
                NewsPanel.SetActive(true);
                // sceneChanger.changeScene(NewsPanel);
            }
            else if (currentCharacterIndex == 12 && rndExists == false)
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
            else if (baseCharacterRND != null)
                currentCharacter = baseCharacterRND;
            Debug.Log("Showing array character after inserted base for index: " + currentCharacterIndex);
            checkRoundOver();
            return;
        }

        // Normal advance: move to next index and decide whether to insert baseCharacter as an extra
       
       
        currentCharacterIndex++;

        if (characters != null && currentCharacterIndex < characters.Length)
        {
            if (baseCharacterRND != null && baseCharacterRND.chanceToAppear > 0)
            {
                int roll = UnityEngine.Random.Range(0, 100);
                if (roll < baseCharacterRND.chanceToAppear)
                {
                    // Insert baseCharacter as an extra popup before showing the array character
                    rndExists = true;
                    currentCharacter = baseCharacterRND;
                    baseInsertedPending = true;
                    Debug.Log($"baseCharacter inserted as extra ({baseCharacterRND.chanceToAppear}%) at index {currentCharacterIndex} (roll={roll})");
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


