using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Video;

public class NewsVideoPlayer : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private bool isPlayingQueue = false;

    public GameObject nextRoundButton;

    private void OnEnable()
    {
        // Avoid starting multiple coroutines if panel is toggled quickly
        if (!isPlayingQueue)
            StartCoroutine(PlayQueuedVideos());
    }

    IEnumerator PlayQueuedVideos()
    {
        isPlayingQueue = true;

        var queue = videoDecisionManager.Instance.videosToPlay;

        if (queue == null || queue.Count == 0)
        {
            Debug.Log("No videos queued.");
            isPlayingQueue = false;
            yield break;
        }

        foreach (var clip in queue)
        {
            videoPlayer.clip = clip;
            videoPlayer.Play();
            Debug.Log("Started video: " + clip.name);

            // Wait until it actually starts
            while (!videoPlayer.isPlaying)
                yield return null;

            // Wait until it finishes
            while (videoPlayer.isPlaying)
                yield return null;

            Debug.Log("Finished video: " + clip.name);
            yield return new WaitForSeconds(0.2f);
        }

        videoDecisionManager.Instance.videosToPlay.Clear();
        Debug.Log("Finished ALL queued videos.");

        isPlayingQueue = false;
    }
}
