using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour
{
    int layerMask = -1;
    public GameObject camera;
    CameraController controller;
    Movement moveSwitch;

    // Use this for initialization
    void Start()
    {
        controller = camera.GetComponent<CameraController>();
        moveSwitch = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        checkClick();  
    }

    void switchControl(RaycastHit hit)
    {
        try //if it doesn't have a movementscript component
        {
            hit.transform.gameObject.GetComponent<Movement>().active = true; // enable controls of target
        }
        catch (System.NullReferenceException)
        {
            return;
        }
        moveSwitch.active = false; //disable controls of this
        controller.Target = hit.transform; //switch camera to target
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
