using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	private GetPosition positionObject;
	private Vector3 spherePosition;
	private GameObject sphere;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void GetSpherePosition(){
		sphere=GameObject.Find ("sphere1");
		spherePosition = sphere.transform.position;
		Debug.Log (spherePosition.ToString());
	}
}
