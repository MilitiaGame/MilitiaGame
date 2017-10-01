using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float lookSensitivity = 3;

	private PlayerMotor motor;

	// Use this for initialization
	void Start () {
		motor = GetComponent<PlayerMotor>();
	}

	// Update is called once per frame
	void Update () {
		// Calculate movement velocity as a 3d vector so that we can move the motor in that space!
		// No processing done by Unity so better choose raw axis, and no smoothing to be done
		// For movement along axes, along [-1, 1]
		float xMovement = Input.GetAxisRaw("Horizontal");
		float zMovement = Input.GetAxisRaw("Vertical");

		// Movement backwards and forwards and upwards and downwards by updating the Vectors along those
		Vector3 moveHorizontal = transform.right * xMovement;
		Vector3 moveVertical = transform.forward * zMovement;

		Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;
		//Apply the movement to a motor
		motor.Move(velocity);

		//Calculate rotation as a 3D vector - set up using the Unity Input
		// Want to move only along left right, up down can be done using camera
		float yRotation = Input.GetAxisRaw("Mouse X");
		Vector3 rotation = new Vector3(0f, yRotation, 0f) * lookSensitivity; // sort of scales
		//Apply rotation
		motor.Rotate(rotation);

		//Calculate camera rotation as a 3D vector - set up using the Unity Input
		float cameraRotation = Input.GetAxisRaw("Mouse Y");
		Vector3 cRotation = new Vector3(cameraRotation, 0f, 0f) * lookSensitivity;
		//Apply camera rotation
		motor.RotateCamera(cRotation);
	}
}
