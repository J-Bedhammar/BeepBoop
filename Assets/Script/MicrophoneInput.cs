using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneInput : MonoBehaviour
{

	int audioSampleRate = 24000; 
    string micInput;
	public FFTWindow fftWindow = FFTWindow.BlackmanHarris; //This window is more precise (something I read somewhere)
    private int samples = 8192;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (micInput == null)
            micInput = Microphone.devices[0];
    }

    // Update is called once per frame
    void Update() {
		
        audioSource.Stop();
        audioSource.clip = Microphone.Start(micInput, true, 5, audioSampleRate);
        audioSource.loop = true;

        //Debug.Log(Microphone.IsRecording(micInput).ToString());

        if (Microphone.IsRecording(micInput))
        {
            while (!(Microphone.GetPosition(micInput) > 0))
                audioSource.Play();
        }
        else 
            Debug.Log(micInput + " doesn't work");
    }

    public float GetFrequency() {
		
        float frequency = 0.0f;
        float[] data = new float[samples]; //array to put spectrum information in
        audioSource.GetSpectrumData(data, 0, fftWindow);
        float s = 0.0f; //initiate s to a low value
        int i = 0;

        for (int j = 0; j < samples; j++) {
                if (s < data[j]) {
                    s = data[j];
                    i = j;
                }
        }

        frequency = i * audioSampleRate / samples;

        return frequency;
    }
}

