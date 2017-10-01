using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

	[SerializeField]
	private Camera cam;

	// Initially velocity,rotation will be zero
	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private Vector3 rotationCamera = Vector3.zero;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	// Gets a movement vector from PlayerController
	public void Move(Vector3 _velocity) {
		velocity = _velocity;
	}

	// Gets a rotation vector from PlayerController
	public void Rotate(Vector3 _rotation) {
		rotation = _rotation;
	}

	// Gets a rotation camera vector from PlayerController
	public void RotateCamera(Vector3 _rotationc) {
		rotationCamera = _rotationc;
	}

	// Run or do movement afer an iteration
	public void FixedUpdate() {
		PerformMovement();
		PerformRotation();
	}

	//Perform movement based on velocity variable
	public void PerformMovement() {
		if(velocity != Vector3.zero) {
			// will stop the movement if there is an obstacle in the way
			// Distance = speed * time
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
		}
	}

	//Perform rotation based on rotation variable
	public void PerformRotation() {
		if(rotation != Vector3.zero) {
			// will stop the rotation if there is an obstacle in the way
			// Quaternion is basically a different way to represent the angle rotation in space
			rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
		}
		if (cam != null) {
			cam.transform.Rotate(-rotationCamera);
		}
	}
}
