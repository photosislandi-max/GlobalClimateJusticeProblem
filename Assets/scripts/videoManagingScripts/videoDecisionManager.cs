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
            Destroy(gameObject);  // Ensure single instance
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    //Add a video to the queue
    public void AddVideo(VideoClip clip)
    {
        if (clip != null)
            videosToPlay.Add(clip);
    }

    //Clear the queue of videos
    public void Clear()
    {
        videosToPlay.Clear();
    }
}

