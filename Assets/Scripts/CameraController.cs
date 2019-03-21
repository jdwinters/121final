using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    PlayerController playerController;
    public float speed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      Movement();
      Rotation();
    }
    void Rotation(){
      this.transform.Rotate(-playerController.Looking.Y ,playerController.Looking.X,0);
    }
    void Movement(){
      if(playerController.Movement.Y > 0){
        this.transform.position += transform.forward * Time.deltaTime * speed;
      }else if(playerController.Movement.Y < 0){
        this.transform.position -= transform.forward * Time.deltaTime * speed;
      }

      if(playerController.Movement.X > 0){
        this.transform.position += transform.right * Time.deltaTime * speed;
      }else if(playerController.Movement.X < 0){
        this.transform.position -= transform.right * Time.deltaTime * speed;
      }

    }
    //On/Off Enable
    void OnEnable(){
      // Bind buttons to actions
      playerController = PlayerController.CreateDefaultBindings();
    }
    void OnDisable(){
      playerController.Destroy();
    }
}
