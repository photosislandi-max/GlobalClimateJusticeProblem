using System;
using UnityEngine;

//This script has our array and will manage our characters in the game
public class characterManager : MonoBehaviour
{
    public scriptableCharacters[]characters; //Array to hold our characters
    public int currentCharacterIndex = 0; //Index to track the current character
    public scriptableCharacters currentCharacter; //Reference to the current character
    public void initCharacterArray()
            {
                characters = Resources.LoadAll<scriptableCharacters>("scriptableObjects/Characters");
                currentCharacter = characters[currentCharacterIndex];
            }
    void Start()
    {
        initCharacterArray();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

