using UnityEngine;
using System.Collections;

public class Transmision : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	public void Enviarvalores(float Thetha1, float Thetha2, float Thetha3){
		Debug.Log ("Thetas" + Thetha1.ToString() + Thetha2.ToString() + Thetha3.ToString());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
