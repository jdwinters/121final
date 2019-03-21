using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		SceneManager.LoadScene("Testing");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
