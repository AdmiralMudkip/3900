using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        offset = transform.position - target.transform.position;
    }

    float movementSpeed = 1;
    float strafeSpeed = 1;

    public GameObject target;
    public GameObject camera;
    public float damping = 1;
    Vector3 offset;
    public float smoothing = 15f, dampening = 0.1f;
    
    // Update is called once per frame
    void Update () {
        float horizontal = Input.GetAxis("Horizontal") * strafeSpeed * Time.deltaTime;
        transform.Translate(horizontal, 0, 0);

        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);
	}

    void LateUpdate()
    {
        Vector3 desiredPosition = target.transform.position + offset;
        Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
        transform.position = position;

        Vector3 cameraPosition = camera.transform.position;



        transform.LookAt(target.transform.position);
    }


    void Awake()
    {

    }
}
