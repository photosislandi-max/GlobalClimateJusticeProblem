using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Video;

public class buttonActivator : MonoBehaviour
{
    public GameObject nextRoundButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if  (videoDecisionManager.Instance.videosToPlay.Count > 0)
        {
            nextRoundButton.SetActive(false);
        }
        
        else if (videoDecisionManager.Instance.videosToPlay.Count == 0)
        {
            nextRoundButton.SetActive(true);
        }
    }
    public void addthree()
    {
        // increment the EconomyBar by 3
        staticBarIntergers.EconomyBar += 30;
        Debug.Log("Economy increased by 3. New value: " + staticBarIntergers.EconomyBar);
    }
}

