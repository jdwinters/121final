using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeBallFun : MonoBehaviour
{
	public float _red, _green, _blue;
	Material _material;
	public float force = 5.0f;
	public float speed = 2.0f;
	Rigidbody ballRB;
	public float gravy = -1.1f;
	void Awake(){
		DontDestroyOnLoad(this.gameObject);
	}
    // Start is called before the first frame update
    void Start()
    {
		ballRB = GetComponent<Rigidbody>();
		_material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
		Color _color = new Color (_red * VisualizeSound._AmplitudeBuffer, _green * VisualizeSound._AmplitudeBuffer, _blue * VisualizeSound._AmplitudeBuffer);
  	  _material.SetColor("_EmissionColor", _color);
  	  _material.SetColor("_Color", _color);
  	  changeColor();
	  GetComponent<Rigidbody>().AddForce(new Vector3(_red * VisualizeSound._AmplitudeBuffer, _green * VisualizeSound._AmplitudeBuffer, _blue * VisualizeSound._AmplitudeBuffer) * force);
	  playerControls();
    }
	void playerControls(){
      Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), gravy, Input.GetAxis("Vertical"));
	 ballRB.velocity = movement * speed;
    }
	void changeColor(){
		if(Input.GetKeyDown(KeyCode.C)){
			_red = Random.Range(0.0f, 1.0f);
			_blue = Random.Range(0.0f, 1.0f);
			_green = Random.Range(0.0f, 1.0f);
		}
	}
}
