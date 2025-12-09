using System;
using Unity.VisualScripting;
using UnityEngine;


public class characterManager : MonoBehaviour
{
    public SceneChanger sceneChanger;
    public GameObject OfficePanel;
    public GameObject NewsPanel;
    public GameObject endScene;
    public scriptableCharacters[] characters; 
    public int currentCharacterIndex = 0; 
    public baseCharacter currentCharacter; 
    public baseCharacter baseCharacterRND; 
    public bool baseInsertedPending = false;
    public bool rndExists = false;
    private int RNDChance = 15;
    public void initCharacterArray()
    {
        Debug.Log("Initializing character array...");
        characters = Resources.LoadAll<scriptableCharacters>("scriptableObjects/characters");
        scriptableCharacters baseCharacterAsScriptableCharacters = Resources.Load<scriptableCharacters>("scriptableObjects/characters/baseCharacter");
        if (baseCharacterAsScriptableCharacters != null)
            baseCharacterRND = baseCharacterAsScriptableCharacters;
        else
            baseCharacterRND = Resources.Load<baseCharacter>("scriptableObjects/characters/baseCharacter");

        if (characters != null && characters.Length > 0)
        {
            // currentCharacterIndex = Mathf.Clamp(currentCharacterIndex, 0, characters.Length - 1);
            currentCharacter = characters[currentCharacterIndex];
        }
        else if (baseCharacterRND != null)
        {
            // currentCharacter = baseCharacterRND;
        }
        
    }
    void Start()
    {
        initCharacterArray();
        Debug.Log("Character Manager initialized with " + (characters == null ? 0 : characters.Length) + " characters.");
    }

    void Update()
    {
        
    }
    public void checkRoundOver()
    {   
            Debug.Log("checking chance to appear and index" + currentCharacterIndex);
            if (currentCharacterIndex <= 0)              //currentCharacterIndex == 1 || currentCharacterIndex == 2)
            {
                baseCharacterRND.chanceToAppear = 0;
                Debug.Log("Increased baseCharacter chanceToAppear to 0%");
            }

            if (currentCharacterIndex == 1)
            {
                baseCharacterRND.chanceToAppear = RNDChance;
                Debug.Log("Increased baseCharacter chanceToAppear to 15%");
            }
        Debug.Log("chance to appear" + baseCharacterRND.chanceToAppear);
        Debug.Log("checking value of rndExist bool"+ rndExists);
        
            if (currentCharacterIndex == 4 && rndExists == false)
            {
                sceneChanger.changeScene(NewsPanel);
            }
        Debug.Log("Checking if round is over at character index: " + currentCharacterIndex);

            if (currentCharacterIndex == 7 && rndExists == false)
            {
                sceneChanger.changeScene(NewsPanel);
            }
            if (currentCharacterIndex == 10 && rndExists == false)
            {
                sceneChanger.changeScene(NewsPanel);
            }
            else if (currentCharacterIndex == 12 && rndExists == false)
            {
                sceneChanger.changeScene(NewsPanel);
            }
    
        Debug.Log("Checking if round is over at character index: " + currentCharacterIndex);
        }  

    public void AdvanceToNextCharacter()
{
        if (baseInsertedPending)
        {
            baseInsertedPending = false;
            if (characters != null && currentCharacterIndex >= 0 && currentCharacterIndex < characters.Length)
                currentCharacter = characters[currentCharacterIndex];
            //  else if (baseCharacterRND != null)
            //      currentCharacter = baseCharacterRND;
            Debug.Log("Showing array character after inserted base for index: " + currentCharacterIndex);
            checkRoundOver();
            return;
        }
       
        currentCharacterIndex++;

        if (characters != null && currentCharacterIndex < characters.Length)
        {
            if (baseCharacterRND != null && baseCharacterRND.chanceToAppear > 0)
            {
                int roll = UnityEngine.Random.Range(0, 100);
                if (roll < baseCharacterRND.chanceToAppear)
                {
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
            currentCharacter = characters[currentCharacterIndex];
        }
        else
        {
            Debug.Log("Advanced past last character index: " + currentCharacterIndex);
        }

        Debug.Log("Advanced to character index: " + currentCharacterIndex);
        checkRoundOver();
}    
    }


