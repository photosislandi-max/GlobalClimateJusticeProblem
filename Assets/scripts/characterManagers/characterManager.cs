using System;
using UnityEngine;

//This script has our array and will manage our characters in the game
public class characterManager : MonoBehaviour
{
    public GameObject OfficePanel;
    public GameObject NewsPanel;
    public scriptableCharacters[] characters; //Array to hold our characters
    public int currentCharacterIndex = 0; //Index to track the current character
    public baseCharacter currentCharacter; //Reference to the current character (can be baseCharacter or scriptableCharacters)
    public baseCharacter baseCharacterSO; // Reference to baseCharacter ScriptableObject
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
        // Select the initial current character, applying the baseCharacter replacement chance per character
        if (characters != null && characters.Length > 0)
        {
            currentCharacter = ChooseCharacterForIndex(currentCharacterIndex);
        }
        else if (baseCharacterSO != null)
        {
            // Fallback: no characters array but a baseCharacter exists
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
            if (currentCharacterIndex == 3)
            {
                OfficePanel.SetActive(false);
                NewsPanel.SetActive(true);
            }
        Debug.Log("Checking if round is over at character index: " + currentCharacterIndex);

            if (currentCharacterIndex == 6)
            {
                OfficePanel.SetActive(false);
                NewsPanel.SetActive(true);
            }
            else if (currentCharacterIndex == 9)
            {
                OfficePanel.SetActive(false);
                NewsPanel.SetActive(true);
            }
    
        Debug.Log("Checking if round is over at character index: " + currentCharacterIndex);
        }  

    public void AdvanceToNextCharacter()
{
    currentCharacterIndex++;

        if (characters != null && currentCharacterIndex < characters.Length)
            currentCharacter = ChooseCharacterForIndex(currentCharacterIndex);

    Debug.Log("Advanced to character index: " + currentCharacterIndex);
    checkRoundOver();
}

    // Choose a character for a given index, with a chance for the baseCharacter to replace it.
    private baseCharacter ChooseCharacterForIndex(int index)
    {
        if (baseCharacterSO != null && baseCharacterSO.chanceToAppear > 0)
        {
            int roll = UnityEngine.Random.Range(0, 100); // 0-99
            if (roll < baseCharacterSO.chanceToAppear)
            {
                Debug.Log($"baseCharacter chosen by chance ({baseCharacterSO.chanceToAppear}%) for index {index} (roll={roll})");
                return baseCharacterSO;
            }
        }

        // If replacement didn't happen or there's no baseCharacter, return the array character
        if (characters != null && index >= 0 && index < characters.Length)
        {
            return characters[index];
        }

        return null;
    }

    
    }


