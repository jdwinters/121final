using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512cubes : MonoBehaviour {

	public GameObject _sampleCubePrefab;
	GameObject[] _sampleCube = new GameObject[512];
	float distance = 20.0f;
	public float _maxScale = 100.0f;
	public float _red, _green, _blue;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < 512; i++){
			GameObject _instanceSampleCube = (GameObject) Instantiate(_sampleCubePrefab);
			_instanceSampleCube.transform.position = this.transform.position;
			_instanceSampleCube.transform.parent = this.transform;
			_instanceSampleCube.name = "SampleCube" + i;
			this.transform.eulerAngles = new Vector3(0f,50-(360.0f/512.0f) * i, 0f);
			_instanceSampleCube.transform.position = Vector3.forward * distance;
			_sampleCube[i] = _instanceSampleCube;
		}
	}

	// Update is called once per frame
	void Update () {
		for(int i = 0; i < 512; i++){
			if(_sampleCube != null){
				_sampleCube[i].transform.localScale = new Vector3( 10, VisualizeSound._samplesBuffer[i]*_maxScale + 10, 10);
				Color _color = new Color(_red + VisualizeSound._audioBandBuffer[i % 8], _green + VisualizeSound._audioBandBuffer[i % 8], _blue + VisualizeSound._audioBandBuffer[i % 8], VisualizeSound._samplesAudioBuffer[i % 8]);
				_sampleCube[i].GetComponent<MeshRenderer>().materials[0].SetColor("_EmissionColor", _color);
			}
		}
		changeColor();
	}
	void changeColor(){
		if(Input.GetKeyDown(KeyCode.C)){
			_red = Random.Range(0.0f, 1.0f);
			_blue = Random.Range(0.0f, 1.0f);
			_green = Random.Range(0.0f, 1.0f);
		}
	}
}
