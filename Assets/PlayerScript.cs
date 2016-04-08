using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
 
    int layerMask = -1;
    public GameObject camera;
    CameraController controller;
    MovementScript movement;


    void Start () {        
        controller = camera.GetComponent<CameraController>();
        movement = GetComponent<MovementScript>();
    }
    
    // Update is called once per frame
    void Update () {
        
	}
    
    
}


