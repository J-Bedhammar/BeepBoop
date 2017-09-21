using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicCode2 : MonoBehaviour
{

    //int sample_size = 256;
    int audioSampleRate = 44100;
    float minThreshold = 0;
    string micInput;

    //AudioClip audio_;
    public FFTWindow fftWindow;
    private int samples = 8192;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {

        audioSource = GetComponent<AudioSource>();

        if (micInput == null)
            micInput = Microphone.devices[0];

        Update();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.Stop();
        audioSource.clip = Microphone.Start(micInput, true, 5, audioSampleRate);
        audioSource.loop = true;

        Debug.Log(Microphone.IsRecording(micInput).ToString());

        if (Microphone.IsRecording(micInput))
        {
            while (!(Microphone.GetPosition(micInput) > 0))
            {
                audioSource.Play();
            }
        }
        else {
            Debug.Log(micInput + " doesn't work");
        }

    }

    public float GetFundamentalFrequency() {
        float fundamentalFrequency = 0.0f;
        float[] data = new float[samples];
        audioSource.GetSpectrumData(data, 0, fftWindow);
        float s = 0.0f;
        int i = 0;

        for (int j = 0; j < samples; j++) {
            if (data[j] > minThreshold) {
                if (s < data[j]) {
                    s = data[j];
                    i = j;
                }
            }
        }

        fundamentalFrequency = i * audioSampleRate / samples;

        return fundamentalFrequency;
    }
}

