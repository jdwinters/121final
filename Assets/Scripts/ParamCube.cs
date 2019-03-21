using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int _band;
    public float _startScale, _scaleMultiplier;
    public bool _useBuffer = true;
	Material _material;
	public float _red, _green, _blue;
    // Start is called before the first frame update
    void Start()
    {
		_material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
      if(_useBuffer){
        transform.localScale = new Vector3(transform.localScale.x, (VisualizeSound._bandBuffer[_band] * _scaleMultiplier) + _startScale,transform.localScale.z);
		Color _color = new Color(_red + VisualizeSound._audioBandBuffer[_band], _green + VisualizeSound._audioBandBuffer[_band], _blue + VisualizeSound._audioBandBuffer[_band]);
		_material.SetColor("_EmissionColor", _color);
	  }else{
        transform.localScale = new Vector3(transform.localScale.x, (VisualizeSound._freqBand[_band] * _scaleMultiplier) + _startScale,transform.localScale.z);
		Color _color = new Color(VisualizeSound._audioBand[_band], VisualizeSound._audioBand[_band], VisualizeSound._audioBand[_band]);
		_material.SetColor("_EmissionColor", _color);
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
