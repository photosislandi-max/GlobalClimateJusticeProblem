// GameDecisionManager.cs
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoDecisionManager : MonoBehaviour
{
    public static videoDecisionManager Instance { get; private set; }

    // Keeps videos in the order they were added
    public List<VideoClip> videosToPlay = new List<VideoClip>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // ensure single instance
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddNoVideo(VideoClip clip)
    {
        if (clip != null)
            videosToPlay.Add(clip);
    }

    public void Clear()
    {
        videosToPlay.Clear();
    }
}

