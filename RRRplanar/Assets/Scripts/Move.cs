using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Move : MonoBehaviour {

	/// <summary>
	/// Ecuaciones y variables de: http://cdn.intechopen.com/pdfs-wm/34391.pdf	/// 
	/// </summary>

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/////LAS DISTANCIAS DE SOLIDWORKS A UNITY3D -> 500 UNIDADES EN SOLIDWORKS EQUIVALEN A 5 UNIDADES EN UNITY3D///
	/// //////////////////////////////////////////////////////////////////////////////////////////////////////////

	private GetPosition positionObject;
	private Vector3 spherePosition;
	private GameObject sphere;
	private GameObject basemovil;
	private bool isStarted;
	private float Xincrement=1.0f;
	private float Zincrement=1.0f;
	private float Lbrazo=1.15f; 			//Largo del brazo
	private float LAntebrazo=1.0f; 		//Largo del Antebrazo
	private float oy1=2.388299f; 			//posicion en y base 1
	private float ox1=-3.492431f; 			//posicion en x base 1
	private float ni=0.8f;					//Distancia del punto M al punto P
	private float phi=30.0f;
	private float[] Angles1;
	private float initialtheta1=38.45f;
	private float initialalpha1=57.57f;
	private float angle;
	private float DynamicTheta1;
	private float DynamicAlpha1;
	private int linkCounter;


	public GameObject brazo1;
	public GameObject Antebrazo1;
	public Text Texto;




	// Use this for initialization
	void Start () {
		basemovil = GameObject.Find ("ensamble/Ensamble - Brazo-1");
		//brazo1=GameObject.Find ("ensamble/Ensamble - Brazo-1");
		isStarted = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(isStarted==true){
			angle+=10*Time.deltaTime;
			if(DynamicTheta1<=(Angles1[0])){
				//brazo1.transform.Rotate (new Vector3 (0, 10, 0) * Time.deltaTime);
				brazo1.transform.eulerAngles=new Vector3(0,-angle,0);
				DynamicTheta1=brazo1.transform.eulerAngles.y;
				DynamicTheta1=((-1*(DynamicTheta1-360))+initialtheta1);
				//initialtheta1=+y;
				//y=y/Mathf.PI*180;
				Debug.Log("Angulo theta1: "+DynamicTheta1.ToString());

			}

			if(DynamicAlpha1<=(-1*Angles1[1])){
				Antebrazo1.transform.eulerAngles=new Vector3(0,angle,0);
				DynamicAlpha1=Antebrazo1.transform.eulerAngles.y;
				DynamicAlpha1=(DynamicAlpha1+initialalpha1);
				Debug.Log(DynamicAlpha1);
			}



		}


	}

	public void GetSpherePosition(){

		sphere=GameObject.Find ("sphere1");
		spherePosition = sphere.transform.position;
		Debug.Log (spherePosition.ToString());

		Texto.text = spherePosition.ToString ();

		CalculateThetaAngles ();
		isStarted = true;


	}

	private void CalculateThetaAngles(){
		float gamma1=210f;				//gammai Angulos entre horizontal y linea ni
		float gamma2=-30f;
		float gamma3=90f;

		Angles1=CalculateThethaAndAlpha (gamma1);
		float[] Angles2=CalculateThethaAndAlpha (gamma2);
		float[] Angles3=CalculateThethaAndAlpha (gamma3);

	}

	private float[] CalculateThethaAndAlpha(float gamma1){

		linkCounter = linkCounter + 1;

		float bx1 = ni * Mathf.Cos ((gamma1*Mathf.PI/2)/90);	//ni*cos(gammai)
		//Debug.Log ("bx1=" + bx1.ToString ());
		float by1 = ni * Mathf.Sin ((gamma1*Mathf.PI/2)/90);	//ni*sin(gammai)
		//Debug.Log ("by1=" + by1.ToString ());

		float Pyb = spherePosition.z;
		float Pxb = spherePosition.x;

		float A1=2*LAntebrazo*(oy1-(bx1*Mathf.Sin((phi*Mathf.PI/2)/90))-(by1*Mathf.Cos((phi*Mathf.PI/2)/90))-Pyb);
		//Debug.Log ("A1=" + A1.ToString ());
		float B1=2*LAntebrazo*(ox1+by1*Mathf.Sin((phi*Mathf.PI/2)/90)-bx1*Mathf.Cos((phi*Mathf.PI/2)/90)-Pxb);
		//Debug.Log ("B1=" + B1.ToString ());

		float C1 = -((Mathf.Pow (LAntebrazo, 2)) - (2 * Pyb * oy1) - (2 * Pxb * ox1) + (Mathf.Pow (bx1, 2) + Mathf.Pow (by1, 2) + Mathf.Pow (ox1, 2) + Mathf.Pow (oy1, 2) + Mathf.Pow (Pxb, 2) + Mathf.Pow (Pyb, 2) - Mathf.Pow (Lbrazo, 2)) +
			((2 * Mathf.Cos ((phi * Mathf.PI / 2) / 90)) * ((Pxb * bx1) + (Pyb * by1) - (bx1 * ox1) - (by1 * oy1))) + ((2 * Mathf.Sin ((phi * Mathf.PI / 2) / 90)) * ((Pyb * bx1) - (Pxb * by1) - (bx1 * oy1) + (by1 * ox1)))); //
		//Debug.Log ("C1=" + C1.ToString ());

		float theta1 = (Mathf.Atan2 ((A1),(B1)))+(Mathf.Atan2((Mathf.Sqrt (Mathf.Pow(A1,2)+Mathf.Pow(B1,2)-Mathf.Pow(C1,2))),C1));
		//Debug.Log ("heta 1 sin convt"+theta1.ToString());
		theta1=((theta1*90)/(Mathf.PI/2));

		float theta1CodoAbajo = (Mathf.Atan2 ((A1),(B1)))-(Mathf.Atan2((Mathf.Sqrt (Mathf.Pow(A1,2)+Mathf.Pow(B1,2)-Mathf.Pow(C1,2))),C1));
		//Debug.Log ("heta 1 sin convt"+theta1.ToString());
		theta1CodoAbajo=((theta1CodoAbajo*90)/(Mathf.PI/2));


		Debug.Log ("Theta"+linkCounter.ToString()+" convertido: "+theta1.ToString());
		//Debug.Log ("ThetaCodoAbajo"+linkCounter.ToString()+" convertido: "+theta1CodoAbajo.ToString());

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
		float G1=(Pxb+(bx1*Mathf.Cos (phi*(Mathf.PI/2)/90))-(by1*Mathf.Sin (phi*(Mathf.PI/2)/90))-(ox1)-(Lbrazo*(Mathf.Cos (theta1*(Mathf.PI/2)/90))))/Lbrazo;
		//Debug.Log ("G1 "+G1.ToString());
		float Alpha1= (Mathf.Atan2 ((D1),(E1)))+(Mathf.Atan2((Mathf.Sqrt (Mathf.Pow(D1,2)+Mathf.Pow(E1,2)-Mathf.Pow(G1,2))),G1));
		Alpha1=((Alpha1*90)/(Mathf.PI/2));
		Debug.Log ("Alpha"+linkCounter.ToString()+" convertido: "+Alpha1.ToString());
		return Alpha1;
		
	}
}
