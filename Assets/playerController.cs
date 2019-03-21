using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    Rigidbody playerRB;
    public float speed = 3.0f;
    public float jumpForce = 3.0f;

	public float gravy;
	Material _material;
	public float _red, _green, _blue;
	public float _maxScale, _startScale;
    // Start is called before the first frame update
    void Start()
    {
      //Camera Initialization
      playerRB = GetComponent<Rigidbody>();
	  _material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown(KeyCode.Z)){
			SceneManager.LoadScene("Testing");
		}
      //control player movement
      playerControls();
	  //transform.localScale = new Vector3((VisualizeSound._AmplitudeBuffer * _maxScale) + _startScale, (VisualizeSound._AmplitudeBuffer * _maxScale) + _startScale, (VisualizeSound._AmplitudeBuffer * _maxScale) + _startScale);
	  Color _color = new Color (_red * VisualizeSound._AmplitudeBuffer, _green * VisualizeSound._AmplitudeBuffer, _blue * VisualizeSound._AmplitudeBuffer);
	  _material.SetColor("_EmissionColor", _color);
	  _material.SetColor("_Color", _color);
	  changeColor();

    }
    void playerControls(){
      Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), gravy, Input.GetAxis("Vertical"));
	  playerRB.velocity = movement * speed;
    }
	void changeColor(){
		if(Input.GetKeyDown(KeyCode.C)){
			_red = Random.Range(0.0f, 1.0f);
			_blue = Random.Range(0.0f, 1.0f);
			_green = Random.Range(0.0f, 1.0f);
		}
	}
}
