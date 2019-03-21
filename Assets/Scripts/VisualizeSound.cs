using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizeSound : MonoBehaviour {

	AudioSource _audioSource;
	public static float[] _samples = new float[512];

	public static float[] _samplesBuffer = new float[512];
	float[] _samplesBufferDecrease = new float[512];

	float[] _sampleHighest = new float[512];
	public static float[] _samplesAudioBand = new float[512];
	public static float[] _samplesAudioBuffer = new float[512];

	public static float[] _freqBand = new float[8];
	public static float[] _bandBuffer = new float[8];
	float[] _bufferDecrease = new float[8];

	float[] _freqBandHighest = new float[8];
	public static float[] _audioBand = new float[8];
	public static float[] _audioBandBuffer = new float[8];

	public static float _Amplitude, _AmplitudeBuffer;
	private float _AmplitudeHighest;

	public bool useVoice = false;
	bool doneOnce;

	public AudioClip[] myClips;

	// Use this for initialization
	void Start () {
		//GetComponent<AudioSource>().GetSpectrumData(Samples, Channel, FFTWindow);
		_audioSource = GetComponent<AudioSource>();
		//_audioSource.clip = Microphone.Start("Built-in Microphone", true, 100, 44100); // Third parameter is length of recording
		//while(!(Microphone.GetPosition(null) > 0)){}
		//_audioSource.Play();
	}

	// Update is called once per frame
	void Update () {
		VoiceOrSong();
		GetSpectrumAudioSource();
		MakeFrequencyBands();
		BandBuffer();
		CreateAudioBands();
		GetAmplitude();
	}
	void VoiceOrSong(){
		if(Input.GetKeyDown(KeyCode.C)){
			useVoice = !useVoice;
			doneOnce = true;
		}
		if(useVoice){
			if(doneOnce){
				_audioSource.clip = Microphone.Start("Built-in Microphone", true, 300, 44100); // Third parameter is length of recording
				while(!(Microphone.GetPosition(null) > 0)){}
				_audioSource.Play();
				doneOnce = false;
			}
		}else{
			if(doneOnce){
				_audioSource.clip = (AudioClip) myClips[Random.Range(0, myClips.Length)];
				_audioSource.Play();
				doneOnce = false;
			}
		}
	}
	void GetAmplitude(){
		float _CurrentAmplitude = 0;
		float _CurrentAmplitudeBuffer = 0;
		for(int i = 0; i < 8; i++){
			_CurrentAmplitude += _audioBand[i];
			_CurrentAmplitudeBuffer += _audioBandBuffer[i];
		}
		if(_CurrentAmplitude > _AmplitudeHighest){
			_AmplitudeHighest = _CurrentAmplitude;
		}
		_Amplitude = _CurrentAmplitude / _AmplitudeHighest;
		_AmplitudeBuffer = _CurrentAmplitudeBuffer / _AmplitudeHighest;
	}

	void CreateAudioBands(){
		for(int i = 0; i < 8; i++){
			if(_freqBand[i] > _freqBandHighest[i]){
				_freqBandHighest[i] = _freqBand[i];
			}
			_audioBand[i] = (_freqBand[i] / _freqBandHighest[i]);
			_audioBandBuffer[i] = (_bandBuffer[i] / _freqBandHighest[i]);
		}
		for(int i = 0; i < 512; i++){
			if(_samples[i] > _sampleHighest[i]){
				_sampleHighest[i] = _samples[i];
			}
			_samplesAudioBand[i] = (_samples[i] / _sampleHighest[i]);
			_samplesAudioBuffer[i] = (_samplesBuffer[i] / _sampleHighest[i]);

		}
	}
	void BandBuffer(){
		for(int g = 0; g < 8; g++){
			if(_freqBand[g] > _bandBuffer[g] ){
				_bandBuffer[g] = _freqBand[g];
				_bufferDecrease[g] = 0.00005f;
			}
			if(_freqBand[g] < _bandBuffer[g] ){
				_bandBuffer[g] -= _bufferDecrease[g];
				_bufferDecrease[g] *= 1.2f;
			}
		}

		for(int g = 0; g < 512; g++){
			if(_samples[g] > _samplesBuffer[g]){
				_samplesBuffer[g] = _samples[g];
				_samplesBufferDecrease[g] = 0.00005f;
			}
			if(_samples[g] < _samplesBuffer[g]){
				_samplesBuffer[g] -= _samplesBufferDecrease[g];
				_samplesBufferDecrease[g] *= 1.075f;
			}
		}
	}

	void GetSpectrumAudioSource(){
		_audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
	}
	void MakeFrequencyBands(){
		int count = 0;

		for(int i = 0; i < 8; i++){
			float average = 0;
			int sampleCount = (int) Mathf.Pow(2, i) * 2;
			if(i == 7){
				sampleCount += 2;
			}
			for(int j = 0; j < sampleCount; j++){
				average += _samples[count] * (count + 1);
				count++;
			}
			average /= count;
			_freqBand[i] = average * 10;
		}
	}


}
