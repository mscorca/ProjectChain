using UnityEngine;
using System.Collections;

public class CharacterControlTopDown : MonoBehaviour {

	private Rigidbody2D rigidbody2d;
	public float maxSpeed = 8.0f;
	public float moveForce = 365.0f;

	// Use this for initialization
	void Start () {
		rigidbody2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Debug.Log("Horizontal: " + h);
		Debug.Log("Vertical: " + v);

		// Horizontal
		if((h * rigidbody2d.velocity.x) < maxSpeed){
			Debug.Log("FORCE: " + Vector2.right * h * moveForce);
			rigidbody2d.AddForce(Vector2.right * h * moveForce);
		} 

		if(Mathf.Abs(rigidbody2d.velocity.x) > maxSpeed){
			Debug.Log("Max speed achieved");
			rigidbody2d.velocity = new Vector2(Mathf.Sign(rigidbody2d.velocity.x) * maxSpeed, rigidbody2d.velocity.y);
		}

		// Vertical
		if(v * rigidbody2d.velocity.y < maxSpeed){
			Debug.Log("FORCE: " + Vector2.right * h * moveForce);
			rigidbody2d.AddForce(Vector2.up * v * moveForce);
		} 

		if(Mathf.Abs(rigidbody2d.velocity.y) > maxSpeed){
			Debug.Log("Max speed achieved");
			rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, Mathf.Sign(rigidbody2d.velocity.y) * maxSpeed);
		}

	//Debug.Log("Velocity: " + rigidbody2d.velocity);

	}
}
