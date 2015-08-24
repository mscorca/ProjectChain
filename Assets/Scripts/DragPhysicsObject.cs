using UnityEngine;
using System.Collections;
 
public class DragPhysicsObject : MonoBehaviour {
     
	public SpringJoint2D spring;
 
      
     void Awake(){
		// "spring" is the SpringJoint2D component that I added to my object
     	// i want the anchor position to start at the object's mousePosition
	    spring = this.gameObject.GetComponent<SpringJoint2D>(); 
	    spring.connectedAnchor = gameObject.transform.position;
     }
 
 
     void OnMouseDown(){
	    //I'm reactivating the SpringJoint2D component each time I'm clicking on my object becouse I'm disabling it after I'm releasing the mouse click so it will fly in the direction i was moving my mouse
	    spring.enabled = true;
     }
 
 
     void OnMouseDrag(){
		if (spring.enabled = true){
			//getting cursor position 
			//the anchor get's cursor's position
			Vector2 cursorPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			spring.connectedAnchor = cursorPosition;
		}
     }
 
     
    void OnMouseUp(){
    	//disabling the spring component
    	spring.enabled = false;
    }
 
 }
 