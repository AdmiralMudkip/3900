using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

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
        button.SetActive(false);
        player = tempPlayer;
        CameraController.Target = player.transform;
        body = player.GetComponent<Rigidbody>();
    }

    public void hideButton()
    {
        button.SetActive(false);
    }

    private void movePlayer() {
        float moveHorizontal = Mathf.Cos(playerCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Input.GetAxis("Vertical") - Mathf.Sin(playerCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Input.GetAxis("Horizontal");
        float moveVertical = Mathf.Sin(playerCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Input.GetAxis("Vertical") + Mathf.Cos(playerCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveVertical, 0.0f, moveHorizontal);
        body.AddForce(movement * movementSpeed);
    } 

    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.tag == "Player")
                {
                    tempPlayer = hit.transform.gameObject;
                    button.transform.position = new Vector2(Input.mousePosition.x + 160 / 2, Input.mousePosition.y);
                    button.SetActive(true);
                }
            }
        }

        movePlayer();
    }
}
