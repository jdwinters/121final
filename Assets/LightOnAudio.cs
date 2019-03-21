using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnAudio : MonoBehaviour
{
	public GameObject _sampleLight;
	public float _minIntensity, _maxIntensity;
	GameObject[,] _lights = new GameObject[32, 16];
	int k1;
	public float lightHeight;
	public Transform target;

    // Start is called before the first frame update
    void Start()
    {
		//_light = GetComponent<Light>();
		for(int i = 0; i < 32; i++){
			for(int j = 0; j < 16; j++){
				if(j % 5 == 0){
					GameObject _instanceLight = (GameObject) Instantiate(_sampleLight);
					_instanceLight.transform.position = this.transform.position - new Vector3(i - 15, -lightHeight, j - 7);
					_instanceLight.transform.parent = this.transform;
					_instanceLight.name = "LightThing" + "i" + i + "j" + j;
					_lights[i,j] = _instanceLight;
				}
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
				if(j % 5 == 0){
					_lights[i,j].GetComponent<Light>().intensity = (VisualizeSound._samplesAudioBuffer[k1] * (_maxIntensity - _maxIntensity)) + _maxIntensity;
					_lights[i,j].transform.LookAt(target);
				}
				if(i < 22){
					k1++;
				}else{
					k1--;
				}
			}
		}

    }
}
