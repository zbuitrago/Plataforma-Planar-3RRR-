using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetPosition : MonoBehaviour {

	public float distance=4.5f;
	public Text position;
	public Texture sphereTexture;
	private GameObject sphere;
	public int sphereCounter;

	// Use this for initialization
	void Start () {
		sphereCounter = 0;
	}
	
	// Update is called once per frame
	// recordar que la base tiene un box coellider Phisycs
	void Update () {
		if (Input.GetMouseButtonDown (0) == true && Input.touchCount<2) {
			sphereCounter=sphereCounter+1;
			Vector3 point=CastRayToWorld();
			setPointToTextField(point);
			CreateSphere(point);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
					Application.Quit();
		}
	}
	
	private Vector3 CastRayToWorld(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); // Objeto rayo
		RaycastHit hit;
		Vector3 worldPos=Vector3.zero;
		if (Physics.Raycast (ray, out hit, 1000f)) { 
			worldPos = hit.point; // tomo posicion de donde pego rayo

		} 

		return worldPos;
	}

	private void setPointToTextField(Vector3 point){
		point.y = 0;
		position.text=point.ToString();
	}

	private void CreateSphere(Vector3 point){
		if(point!=Vector3.zero){
			sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			sphere.name="sphere"+sphereCounter.ToString();
			sphere.transform.position = new Vector3 (point.x,0.2f,point.z);
			SphereAppeareance(sphere);
		}
	}

	private void SphereAppeareance(GameObject sphere){
		sphere.transform.localScale = new Vector3 (0.06f,0.06f,0.06f);
		sphere.renderer.material.mainTexture = sphereTexture;
	}

	public Vector3 getSpherePosition(){
		return sphere.transform.position;
	}

	public void ClearSphereCounter(){
		for(int x=1; x<=sphereCounter; x++){
			GameObject deletedSphere=GameObject.Find ("sphere"+x.ToString());// encuentra la espera y le va asignando un numero
			Destroy(deletedSphere);
		}
		sphereCounter = 0;
	}
}
