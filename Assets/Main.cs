using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

    public static GameObject player;
    public float movementSpeed = 10;
    public Rigidbody body;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        body = player.GetComponent<Rigidbody>();
        CameraController.Target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
                if (hit.transform.gameObject.tag == "Player")
                {
                    player = hit.transform.gameObject;
                    CameraController.Target = player.transform;
                    body = player.GetComponent<Rigidbody>();
                }
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        body.AddForce(movement * movementSpeed);
    }
}
