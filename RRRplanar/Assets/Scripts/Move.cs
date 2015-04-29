using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	/// <summary>
	/// Ecuaciones y variables de: http://cdn.intechopen.com/pdfs-wm/34391.pdf	/// 
	/// </summary>


	private GetPosition positionObject;
	private Vector3 spherePosition;
	private GameObject sphere;
	private GameObject basemovil;
	private bool isStarted;
	private float Xincrement=1.0f;
	private float Zincrement=1.0f;
	private float l=136.40f; 				//Largo del brazo
	private float oy1=2.388299f; 			//posicion en y base 1
	private float ox1=-3.492431f; 			//posicion en x base 1
	private float ni=80f;					//Distancia del punto M al punto P
	private float phi=30.0f;




	// Use this for initialization
	void Start () {
		basemovil = GameObject.Find ("ensamble/Ensamble - Brazo-1");
		isStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(isStarted==true){


			}


	}

	public void GetSpherePosition(){
		isStarted = true;
		sphere=GameObject.Find ("sphere1");
		spherePosition = sphere.transform.position;

		CalculateThetaAngles ();



	}

	private void CalculateThetaAngles(){
		float gamma1=210f;				//gammai Angulos entre horizontal y linea ni
		float gamma2=-30f;
		float gamma3=90f;

		float[] Angles1=CalculateThethaAndAlpha (gamma1);
		float[] Angles2=CalculateThethaAndAlpha (gamma2);
		float[] Angles3=CalculateThethaAndAlpha (gamma3);

	}

	private float[] CalculateThethaAndAlpha(float gamma1){

		 float bx1 = ni * Mathf.Cos ((gamma1*Mathf.PI/2)/90);	//ni*cos(gammai)
		//Debug.Log ("bx1=" + bx1.ToString ());
		 float by1 = ni * Mathf.Sin ((gamma1*Mathf.PI/2)/90);	//ni*sin(gammai)
		//Debug.Log ("by1=" + by1.ToString ());

		float Pyb = spherePosition.z;
		float Pxb = spherePosition.x;

		float A1=2*l*(oy1-(bx1*Mathf.Sin((phi*Mathf.PI/2)/90))-(by1*Mathf.Cos((phi*Mathf.PI/2)/90))-Pyb);
		//Debug.Log ("A1=" + A1.ToString ());
		float B1=2*l*(ox1+by1*Mathf.Sin((phi*Mathf.PI/2)/90)-bx1*Mathf.Cos((phi*Mathf.PI/2)/90)-Pxb);
		//Debug.Log ("B1=" + B1.ToString ());

		float C1 = -((Mathf.Pow (l, 2)) - (2 * Pyb * oy1) - (2 * Pxb * ox1) + (Mathf.Pow (bx1, 2) + Mathf.Pow (by1, 2) + Mathf.Pow (ox1, 2) + Mathf.Pow (oy1, 2) + Mathf.Pow (Pxb, 2) + Mathf.Pow (Pyb, 2) - Mathf.Pow (l, 2)) +
			((2 * Mathf.Cos ((phi * Mathf.PI / 2) / 90)) * ((Pxb * bx1) + (Pyb * by1) - (bx1 * ox1) - (by1 * oy1))) + ((2 * Mathf.Sin ((phi * Mathf.PI / 2) / 90)) * ((Pyb * bx1) - (Pxb * by1) - (bx1 * oy1) + (by1 * ox1)))); //
		//Debug.Log ("C1=" + C1.ToString ());

		float theta1 = (Mathf.Atan2 ((A1),(B1)))+(Mathf.Atan2((Mathf.Sqrt (Mathf.Pow(A1,2)+Mathf.Pow(B1,2)-Mathf.Pow(C1,2))),C1));
		//Debug.Log ("heta 1 sin convt"+theta1.ToString());
		theta1=((theta1*90)/(Mathf.PI/2));
		Debug.Log ("Theta1 convertido: "+theta1.ToString());

		float Alpha=CalculateAlpha (theta1,Pxb,bx1,by1);
		float[] Angles= new float[2];
		Angles [0] = theta1;
		Angles [1] = Alpha;
		return Angles ;

	}


	private float CalculateAlpha(float theta1, float Pxb, float bx1, float by1)
	{


		float D1 = -Mathf.Sin(theta1*((Mathf.PI/2)/90));
		//Debug.Log ("D1: "+D1.ToString());
		float E1= Mathf.Cos(theta1*((Mathf.PI/2)/90));
		//Debug.Log ("E1: "+E1.ToString());
		float G1=(Pxb+(bx1*Mathf.Cos (phi*(Mathf.PI/2)/90))-(by1*Mathf.Sin (phi*(Mathf.PI/2)/90))-(ox1)-(l*(Mathf.Cos (theta1*(Mathf.PI/2)/90))))/l;
		//Debug.Log ("G1 "+G1.ToString());
		float Alpha1= (Mathf.Atan2 ((D1),(E1)))+(Mathf.Atan2((Mathf.Sqrt (Mathf.Pow(D1,2)+Mathf.Pow(E1,2)-Mathf.Pow(G1,2))),G1));
		Alpha1=((Alpha1*90)/(Mathf.PI/2));
		Debug.Log ("Alpha convertido: "+Alpha1.ToString());
		return Alpha1;
		
	}
}
