using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour
{
    int layerMask = -1;
    public GameObject camera;
    CameraController controller;

    // Use this for initialization
    void Start()
    {
        controller = camera.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        checkClick();
    }

    void switchControl(RaycastHit hit)
    {
        GetComponent<MovementScript>().active = false; //disable controls of this
        hit.transform.gameObject.GetComponent<MovementScript>().active = true;
        controller.Target = hit.transform;
    }

    void checkClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Casts the ray and get the first game object hit
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                switchControl(hit);
            }
        }
    }
}
