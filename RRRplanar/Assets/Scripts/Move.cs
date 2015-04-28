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
	private float l=136.4f; 				//Largo del brazo
	private float oy1=2.388299f; 			//posicion en y base 1
	private float ox1=-3.492431f; 			//posicion en x base 1
	private float ni=80f;					//Distancia del punto M al punto P
	private float gamma1=210f;				//gammai Angulos entre horizontal y linea ni
	private float gamma2=-30f;
	private float gamma3=90f;
	private float phi=0.0f;


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
		CalculateThetha1 ();
	}

	private void CalculateThetha1(){



		float bx1 = ni * Mathf.Cos ((gamma1*Mathf.PI/2)/90);	//ni*cos(gammai)
		Debug.Log ("bx1=" + bx1.ToString ());
		float by1 = ni * Mathf.Sin ((gamma1*Mathf.PI/2)/90);	//ni*sin(gammai)
		Debug.Log ("by1=" + by1.ToString ());

		float Pyb = 3.4f; //spherePosition.z;
		float Pxb = -4.6f; //spherePosition.x;

		float A1=2*l*(oy1-bx1*Mathf.Sin((phi*Mathf.PI/2)/90)-by1*Mathf.Cos((phi*Mathf.PI/2)/90)-Pyb);
		Debug.Log ("A1=" + A1.ToString ());
		float B1=2*l*(ox1+by1*Mathf.Sin((phi*Mathf.PI/2)/90)-bx1*Mathf.Cos((phi*Mathf.PI/2)/90)-Pxb);
		Debug.Log ("B1=" + B1.ToString ());

		float Pyboy = Pyb * oy1;	//8.120216
		float Pxox = Pxb * ox1;	//16.06518	
		float SumAllFactorsPow2 = Mathf.Pow (bx1,2)+Mathf.Pow (by1,2)+Mathf.Pow (ox1,2)+Mathf.Pow (oy1,2)+Mathf.Pow (Pxb,2)+Mathf.Pow (Pyb,2);	//6450.621
		Debug.Log ("SumAllFactorsPow2: "+SumAllFactorsPow2.ToString());
		float bx1ox1 = bx1 * ox1;	//241.9627
		Debug.Log ("bx1ox1=" + bx1ox1.ToString ());

		float Pxbx = Pxb * bx1;	// 318.69
		Debug.Log ("Pxbx=" + Pxbx.ToString ());

		float Pyby = Pyb * by1;	//-136
		Debug.Log ("Pyby=" + Pyby.ToString ());

		float by1oy1 = by1 * oy1;	//-95.532
		Debug.Log ("by1oy1=" + by1oy1.ToString ());

		float prueba=((2*Mathf.Cos((phi*Mathf.PI/2)/90))*(Pxbx+Pyby-bx1ox1-by1oy1));
		Debug.Log("Prueba"+prueba.ToString());

		float Pybx = Pyb * bx1;
		Debug.Log ("Pybx=" + Pybx.ToString ());

		float Pxbby = Pxb * by1;
		Debug.Log ("Pxbby=" + Pxbby.ToString ());

		float bxoy = bx1 * oy1;
		Debug.Log ("bxoy=" + bxoy.ToString ());

		float byox = by1 * ox1;
		Debug.Log ("byox=" + byox.ToString ());

		float C1 = -1 * (-2 * Pyboy - (2 * Pxox) + SumAllFactorsPow2+((2*Mathf.Cos((phi*Mathf.PI/2)/90))*(Pxbx+Pyby-bx1ox1-by1oy1))+
		                 ((2*Mathf.Cos((phi*Mathf.PI/2)/90))*(Pybx-Pxbby-bxoy+byox))); //
		Debug.Log ("C1=" + C1.ToString ());

		float sqrtABC2 = Mathf.Sqrt (Mathf.Pow(A1,2)+Mathf.Pow(B1,2)-Mathf.Pow(C1,2));
		Debug.Log ("raiz ABC2=: "+sqrtABC2.ToString());

		float theta1 = Mathf.Atan2 (A1,B1)+Mathf.Atan2(sqrtABC2,C1);
		Debug.Log ("heta 1 sin convt"+theta1.ToString());
		theta1=((theta1*Mathf.PI/2)/90);
		Debug.Log ("Theta1 convertido: "+theta1.ToString());

	}
}
