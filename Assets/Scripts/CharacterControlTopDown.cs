using UnityEngine;
using System.Collections;

public class CharacterControlTopDown : MonoBehaviour {

	private Rigidbody2D rigidbody2d;
	//private Transform transform;
	public float maxSpeed = 8.0f;
	public float maxAngularSpeed = 5.0f;
	public float moveForce = 365.0f;
	public float spinForce = 10.0f;

	private float rollMult = 2.5f;
	//private float spinDirectionMultiplier = 1;
	private bool rollWait = false;


	private Vector3 prevMousePos;
	private Vector3 mousePos;
	private Vector3 prevCrossProduct;
	private Vector3 crossProduct;
	private Quaternion previousRot;
	private Quaternion currentRot;


	// Use this for initialization
	void Start () {
		rigidbody2d = GetComponent<Rigidbody2D>();
		//mousePos = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
		// transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		move();

		//prevMousePos = mousePos;
		//Vector3 drawPrev = Camera.main.transform.position - mousePos;
		//mousePos = Camera.main.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

		// Debug.Log("Pre: " + prevMousePos);
		// Debug.Log("Cur: " + mousePos);

		//transform.LookAt(mousePos);

		//previousRot = currentRot;
		//currentRot = Quaternion.LookRotation(transform.position - mousePos, Vector3.forward);

		// Debug.DrawLine(Camera.main.transform.position, drawPrev, Color.blue);
		// Debug.DrawLine(Camera.main.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.red);
		
		// float angle = Vector3.Angle(prevMousePos, mousePos);
		// prevCrossProduct = crossProduct;
		// crossProduct = Vector3.Cross(prevMousePos, mousePos);
		// if(crossProduct.y < 0 && !(prevCrossProduct.y < 0)){
		// 	spinDirectionMultiplier = -spinDirectionMultiplier;
		// 	Debug.Log("Angle: " + -angle);
		// } else {
		// 	Debug.Log("Angle: " + angle);
		// }

		// rigidbody2d.AddTorque(angle * spinDirectionMultiplier * spinForce);

	}

	void move(){
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Debug.Log("Horizontal: " + h);
		Debug.Log("Vertical: " + v);

		// Horizontal
		if((h * rigidbody2d.velocity.x) < maxSpeed){
			//Debug.Log("FORCE: " + Vector2.right * h * moveForce);
			rigidbody2d.AddForce(Vector2.right * h * moveForce);
		} 

		if(Mathf.Abs(rigidbody2d.velocity.x) > maxSpeed){
			//Debug.Log("Max speed achieved");
			rigidbody2d.velocity = new Vector2(Mathf.Sign(rigidbody2d.velocity.x) * maxSpeed, rigidbody2d.velocity.y);
		}

		// Vertical
		if(v * rigidbody2d.velocity.y < maxSpeed){
			//Debug.Log("FORCE: " + Vector2.right * h * moveForce);
			rigidbody2d.AddForce(Vector2.up * v * moveForce);
		} 

		if(Mathf.Abs(rigidbody2d.velocity.y) > maxSpeed){
			//Debug.Log("Max speed achieved");
			rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, Mathf.Sign(rigidbody2d.velocity.y) * maxSpeed);
		}

		if(!rollWait && Input.GetKeyDown("space")){
			rollWait = true;
			moveForce *= rollMult;
			maxSpeed *= rollMult;
			StartCoroutine(resetRoll());
		}

	}

	IEnumerator resetRoll(){
			yield return new WaitForSeconds(.25f);
			rollWait = false;
			moveForce /= rollMult;
			maxSpeed /= rollMult;
	}

}
