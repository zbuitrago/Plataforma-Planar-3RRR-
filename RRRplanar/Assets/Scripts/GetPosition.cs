using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetPosition : MonoBehaviour {

	public float distance=4.5f;
	public Text position;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0) == true) {
			Vector3 point=CastRayToWorld();
			setPointToTextField(point);
		}
	}

	private Vector3 CastRayToWorld(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Vector3 point= ray.origin+(ray.direction*distance);
		return point;
	}

	private void setPointToTextField(Vector3 point){
		position.text=point.ToString();
	}
}
