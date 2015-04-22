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
			CreateSphere(point);
		}
	}
	
	private Vector3 CastRayToWorld(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		Vector3 worldPos=Vector3.zero;
		if (Physics.Raycast (ray, out hit, 1000f)) {
			worldPos = hit.point;
		} 
		return worldPos;
	}

	private void setPointToTextField(Vector3 point){
		point.y = 0;
		position.text=point.ToString();
	}

	private void CreateSphere(Vector3 point){
		if(point!=Vector3.zero){
			GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			sphere.transform.position = new Vector3 (point.x,0.0f,point.z);
			sphere.transform.localScale = new Vector3 (0.5f,0.5f,0.5f);
		}
	}
}
