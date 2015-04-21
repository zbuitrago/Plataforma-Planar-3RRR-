using UnityEngine;
using System.Collections;

public class rotationrespectto : MonoBehaviour {

	public GameObject link1;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		transform.position=new Vector3(link1.transform.position.x,0f,link1.transform.position.z);
		transform.

		transform.RotateAround (new Vector3 (link1.transform.position.x, 0f, link1.transform.position.z), new Vector3 (0.0f, 1.0f, 0.0f), 55.0f * Time.deltaTime);
		//transform.Rotate (new Vector3 (0, 5, 0) * Time.deltaTime);
	}
}
