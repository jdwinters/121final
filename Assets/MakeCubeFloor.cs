using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCubeFloor : MonoBehaviour
{
	public GameObject _sampleCubePrefab;
	GameObject[,] _sampleSquareCube = new GameObject[32,16];
	float distance = 100.0f;
	public float _maxScale = 100.0f;
	int k1;
	public float _red, _green, _blue;
    // Start is called before the first frame update
    void Start()
    {
		for(int i = 0; i < 32; i++){
			for(int j = 0; j < 16; j++){
				GameObject _instanceSampleCube = (GameObject) Instantiate(_sampleCubePrefab);
				_instanceSampleCube.transform.position = this.transform.position - new Vector3(i - 15, 0, j - 7);
				_instanceSampleCube.transform.parent = this.transform;
				_instanceSampleCube.name = "SquareSampleCube" + "i" + i + "j" + j;
				_sampleSquareCube[i,j] = _instanceSampleCube;
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
		k1 = 0;
		for(int i = 0; i < 32; i++){
			for(int j = 0; j < 16; j++){
				if(i == 22){
					k1 = 144;
				}
				_sampleSquareCube[i,j].transform.localScale = new Vector3(12.75f, VisualizeSound._samplesBuffer[k1]*_maxScale,12.75f);
				Color _color = new Color(_red + VisualizeSound._samplesAudioBuffer[k1 % 9], _green + VisualizeSound._samplesAudioBuffer[k1 % 9], _blue + VisualizeSound._samplesAudioBuffer[k1 % 9] + .1f, VisualizeSound._samplesAudioBuffer[k1 % 9] + .1f);
				_sampleSquareCube[i,j].GetComponent<MeshRenderer>().materials[0].SetColor("_EmissionColor", _color);
				if(i < 22){
					k1++;
				}else{
					k1--;
				}
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
