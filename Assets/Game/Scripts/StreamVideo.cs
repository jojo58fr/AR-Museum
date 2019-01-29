using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;
using System.IO;

public class StreamVideo : MonoBehaviour 
{
	public RawImage rawImage;
	public VideoPlayer videoPlayer;
	public AudioSource audioSource;

	private bool initialization = false;
	private bool started = false;
	private TextMeshProUGUI icon;
	private bool checkInvoke = false;


	private void Start()
	{
		icon = GetComponentInChildren<TextMeshProUGUI>();
		icon.text = "\uf04b";

		if(!initialization)
		{
			StartCoroutine(InitVideo());
		}

		//StartCoroutine(RetrieveStreamingAsset());
	}

	//checkOver function will use current frame and total frames of video player video
	//to determine if the video is over.
	
	private void checkOver()
	{
		long playerCurrentFrame = videoPlayer.frame;
		long playerFrameCount = Convert.ToInt64(videoPlayer.frameCount);
		
		if(playerCurrentFrame < playerFrameCount)
		{
			//print ("VIDEO IS PLAYING");
		}
		else
		{
			//print ("VIDEO IS OVER");
			//Do w.e you want to do for when the video is done playing.
			StopVideo();
			checkInvoke = false;
			StartCoroutine(InitVideo());
			//Cancel Invoke since video is no longer playing
			CancelInvoke("checkOver");
		}
	}

	public void OnPlayPauseButton()
	{
		if(!initialization)
		{
			StartCoroutine(InitVideo());
		}

		if(!started)
		{
			PlayVideo();
		}
		else
		{
			PauseVideo();
		}

	}

	IEnumerator InitVideo()
	{
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "yee.mp4");
        videoPlayer.Prepare();
		
		WaitForSeconds waitForSeconds = new WaitForSeconds(1);

		while (!videoPlayer.isPrepared)
		{
			yield return waitForSeconds;
			break;
		}
		
		rawImage.texture = videoPlayer.texture;
		initialization = true;
		icon.text = "\uf04b";
	}

	/*IEnumerator RetrieveStreamingAsset(string mediaFileName)
    {
        string streamingMediaPath = Application.streamingAssetsPath + "/" + mediaFileName;
        string persistentPath = Application.persistentDataPath + "/" + mediaFileName;
        if (!File.Exists(persistentPath))
        {
            WWW wwwReader = new WWW(streamingMediaPath);
            yield return wwwReader;
 
            if (wwwReader.error != null)
            {
                Debug.LogError("wwwReader error: " + wwwReader.error);
            }
 
            System.IO.File.WriteAllBytes(persistentPath, wwwReader.bytes);
        }
 
        videoPlayer.url = persistentPath;
    }*/

	public void StopVideo()
	{
		videoPlayer.Stop();
		audioSource.Stop();
		icon.color = new Color(icon.color.r,icon.color.g,icon.color.b, 1f);
		icon.text = "\uf04b";

		initialization = false;
		started = false;
	}

	public void PauseVideo()
	{
		videoPlayer.Pause();
		audioSource.Pause();
		icon.color = new Color(icon.color.r,icon.color.g,icon.color.b, 1f);
		icon.text = "\uf04c";
		started = false;
	}

	public void PlayVideo()
	{
		videoPlayer.Play();
		audioSource.Play();
		started = true;
		icon.color = new Color(icon.color.r,icon.color.g,icon.color.b, 0f);
		icon.text = "\uf04b";

		if(!checkInvoke)
		{
			//Invoke repeating of checkOver method
			InvokeRepeating("checkOver", .1f,.1f);
			checkInvoke = true;
		}

	}
}
