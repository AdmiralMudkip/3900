using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

    /// <summary>
    /// This is a simple Unity project to demonstrate switching controls and views
    /// between pre-determined targets.
    /// 
    /// Authors: Jason Burns & Markus Linseisen
    /// Camera controller credit https://github.com/fholm
    /// 
    /// </summary>


    public static GameObject player;
    public GameObject tempPlayer;
    public GameObject playerCamera;
    public GameObject button;
    public Rigidbody body;

    public float movementSpeed = 10;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        button = GameObject.Find("Button");
        button.SetActive(false);
        playerCamera = GameObject.Find("Main Camera");
        body = player.GetComponent<Rigidbody>();
        CameraController.Target = player.transform;
    }

    public void swap()
    {
        button.SetActive(false); //disable button
        player = tempPlayer; // switch the global player's var to the target that was stored
        CameraController.Target = player.transform; // camera targets the new player
        body = player.GetComponent<Rigidbody>(); // get it's body so we can physics with it
    }

    public void hideButton()
    {
        button.SetActive(false);
    }

    private void movePlayer() {
        // moveVertical and moveHorizontal calculate a value based on where the camera is and what button is being pressed
        float moveHorizontal = Mathf.Cos(playerCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Input.GetAxis("Vertical") - Mathf.Sin(playerCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Input.GetAxis("Horizontal");
        float moveVertical = Mathf.Sin(playerCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Input.GetAxis("Vertical") + Mathf.Cos(playerCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveVertical, 0.0f, moveHorizontal);

        body.AddForce(movement * movementSpeed); // apply force
    } 

    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag == "Player") // if it's tag is defined as 'player,' could be changed to 'switchable' down the line
                {
                    tempPlayer = hit.transform.gameObject;  //save the target, might not switch yet
                    button.transform.position = new Vector2(Input.mousePosition.x + 160 / 2, Input.mousePosition.y);
                    button.SetActive(true); // enable button to confirm switching to target
                }
            }
        }
        // move player every frame
        movePlayer();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
