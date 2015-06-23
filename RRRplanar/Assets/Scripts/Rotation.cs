using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	public Vector3 movement;
	private float counter=0;
	// Use this for initialization
	void Start () {
		 movement = new Vector3 (0.0f,counter,0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		counter = counter + 5;
		//rigidbody.velocity = movement * 10;
		//rigidbody.rotation = Quaternion.Euler (0.0f,rigidbody.velocity.x,0.0f);
		//transform.RotateAround (new Vector3 (-4.63f, 0 - 0f, 0.0f), new Vector3 (0.0f, 1.0f, 0.0f), 5.0f * Time.deltaTime);
		transform.Rotate (new Vector3 (0, 0, 30) * Time.deltaTime);

	}
}