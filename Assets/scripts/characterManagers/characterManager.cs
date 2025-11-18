using System;
using UnityEngine;

//This script has our array and will manage our characters in the game
public class characterManager : MonoBehaviour
{
    public GameObject OfficePanel;
    public GameObject NewsPanel;
    public scriptableCharacters[]characters; //Array to hold our characters
    public int currentCharacterIndex = 0; //Index to track the current character
    public scriptableCharacters currentCharacter; //Reference to the current character
    public void initCharacterArray()
    {
        Debug.Log("Initializing character array...");
        characters = Resources.LoadAll<scriptableCharacters>("scriptableObjects/Characters");
        if (characters == null || characters.Length == 0)
        {
            Debug.Log("No characters found in Resources/scriptableObjects/Characters");
            return;
        }
                
        currentCharacter = characters[currentCharacterIndex];
    }
    void Start()
    {
        initCharacterArray();
        Debug.Log("Character Manager initialized with " + characters.Length + " characters.");
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

    if (currentCharacterIndex < characters.Length)
        currentCharacter = characters[currentCharacterIndex];

    Debug.Log("Advanced to character index: " + currentCharacterIndex);
    checkRoundOver();
}

    
    }


