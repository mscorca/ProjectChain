using UnityEngine;
using System.Collections;

public class CharacterControlTopDown : MonoBehaviour {

	private Rigidbody2D rigidbody2d;
	public float speed = 6;

	// Use this for initialization
	void Start () {
		rigidbody2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		// Horizontal
		if(h > 0){
			Vector2 hForce = new Vector2(speed, 0.0f);
			rigidbody2d.AddForce(hForce);
		} else if (h < 0){
			Vector2 hForce = new Vector2(-speed, 0.0f);
			rigidbody2d.AddForce(hForce);			
		}

		// Vertical
		if(v > 0){
			Vector2 vForce = new Vector2(0.0f, speed);
			rigidbody2d.AddForce(vForce);
		} else if (v < 0){
			Vector2 vForce = new Vector2(0.0f, -speed);
			rigidbody2d.AddForce(vForce);			
		}
		
	Debug.Log("Velocity: " + rigidbody2d.velocity);

	}
}
