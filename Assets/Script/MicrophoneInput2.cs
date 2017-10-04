using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MicrophoneInput2 : MonoBehaviour
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
		int[] Peak = {0, 0, 0, 0, 0}; // array to place the 5 highest peaks in

		//Implement HPS-algorithm to find fundamental frequency
        for (int j = 0; j < samples; j++) {
                if (s < data[j]) { //if data at index j is bigger than s
                    s = data[j]; //give s the value for data at index j
					Peak[4] = Peak[3];
					Peak[3] = Peak[2];
					Peak[2] = Peak[1];
					Peak[1] = Peak[0]; //Peak[1] will contain the second highset peak aso upwards
					Peak[0] = j; //give first slot of Peak the index at highest peak
                }
        }

		frequency = Peak.Min() * audioSampleRate / samples; //Peak.Min() should grab the fundamental frequency

        return frequency;
    }
}

