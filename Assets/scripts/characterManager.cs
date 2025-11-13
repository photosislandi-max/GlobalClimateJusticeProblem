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
            characters = Resources.LoadAll<scriptableCharacters>("scriptableObjects/Characters");
            if (characters == null || characters.Length == 0)
            {
                Debug.Log("No characters found in Resources/scriptableObjects/Characters");
                return;
            }
            
            //Randomize character order
            // for (int i = characters.Length - 1; i > 0; i--)
            // {
            //     int j = UnityEngine.Random.Range(0, i + 1);
            //     var tmp = characters[i];
            //     characters[i] = characters[j];
            //     characters[j] = tmp;
            // }
            // currentCharacterIndex = 0; 
            
            currentCharacter = characters[currentCharacterIndex];
        }
    void Start()
    {
        initCharacterArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCharacterIndex == 3)
        {
            OfficePanel.SetActive(false);
            NewsPanel.SetActive(true);
        }
    }
}

