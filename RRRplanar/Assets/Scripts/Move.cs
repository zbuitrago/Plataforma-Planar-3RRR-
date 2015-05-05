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
	private float LAntebrazo=1.0f; 			//Largo del Antebrazo
	private float ni=0.8f;					//Distancia del punto M al punto P
	private float phi=3.20f;
	private float[] Angles1;
	private float[] Angles2;
	private float[] Angles3;
	private float initialtheta1=354.51f;
	private float initialalpha1=80.53f;
	private float initialtheta2=106.9f;
	private float initialalpha2=188.68f;
	private float initialtheta3=212.38f;
	private float initialalpha3=334.82f;
	private float angle;
	private float DynamicTheta1;
	private float DynamicAlpha1;
	private float DynamicTheta2;
	private float DynamicAlpha2;
	private float DynamicTheta3;
	private float DynamicAlpha3;
	private int linkCounter;
	
	
	public GameObject brazo3;		//El brazo1 equivale al brazo 3  theta 3 en el PDF
	public GameObject Antebrazo3;	//El Antebrazo1 equivale al Antebrazo 3 alpha 3 en el PDF
	public Text Texto;
	
	
	
	
	// Use this for initialization
	void Start () {
		basemovil = GameObject.Find ("ensamble/Ensamble - Brazo-1");
		DynamicTheta3 = initialtheta3;
		DynamicAlpha3 = initialalpha3;
		isStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isStarted==true){
			angle+=10*Time.deltaTime;

			Debug.Log("Theta3 dinamico: "+DynamicTheta3.ToString());

			if(DynamicTheta3>=Angles3[0]){
				brazo3.transform.eulerAngles=new Vector3(0,angle,0);
				float localAngle=brazo3.transform.eulerAngles.y;
				DynamicTheta3=initialtheta3-localAngle;
				Debug.Log("Theta3 dinamico: "+DynamicTheta3.ToString());
			}

			if(DynamicTheta3<=Angles3[0]){
				brazo3.transform.eulerAngles=new Vector3(0,-angle,0);
				float localAngle=brazo3.transform.eulerAngles.y;
				DynamicTheta3=initialtheta3+localAngle;
				Debug.Log("Theta3 dinamico: "+DynamicTheta3.ToString());
			}
			
			/*if(DynamicTheta3<=(Angles3[0])){
				//brazo1.transform.Rotate (new Vector3 (0, 10, 0) * Time.deltaTime);
				brazo3.transform.eulerAngles=new Vector3(0,-angle,0);
				DynamicTheta3=brazo3.transform.eulerAngles.y;
				DynamicTheta3=((-1*(DynamicTheta3-360))+initialtheta3);
				//initialtheta1=+y;
				//y=y/Mathf.PI*180;
				Debug.Log("Angulo theta3: "+DynamicTheta3.ToString());
				
			}
			
			if(DynamicAlpha3<=(-1*Angles3[1])){
				Antebrazo3.transform.eulerAngles=new Vector3(0,angle,0);
				DynamicAlpha3=Antebrazo3.transform.eulerAngles.y;
				DynamicAlpha3=(DynamicAlpha3+initialalpha3);
				Debug.Log(DynamicAlpha3);
			}*/
			
			
			
		}
		
		
	}
	
	public void GetSpherePosition(){
		
		sphere=GameObject.Find ("sphere1");
		spherePosition = sphere.transform.position;
		
		Texto.text = spherePosition.ToString ();
		
		CalculateThetaAngles ();
		ConvertAnglesToPositive ();
		isStarted = true;
		
		
	}
	
	private void CalculateThetaAngles(){
		float gamma1=210f;				//gammai Angulos entre horizontal y linea ni
		float gamma2=-30f;
		float gamma3=90f;

		float oy1=5.539518f; 			//posicion en y brazo 2 que en realidad es e el brazo 1 theta1
		float ox1=-1.4949f; 			//posicion en x brazo 2 que en realidad es e el brazo 1 theta1

		float oy2=5.544016f; 			//posicion en y brazo 3 que en realidad es e el brazo 2 theta2
		float ox2=-5.498871f; 			//posicion en x brazo 3 que en realidad es e el brazo 2 theta2
		
		float oy3=2.388299f; 			//posicion en y brazo 1 que en realidad es e el brazo 3 theta3
		float ox3=-3.492431f; 			//posicion en x brazo 1 que en realidad es e el brazo 3 theta3
		
		Angles1=CalculateThethaAndAlpha (gamma1, ox1, oy1);
		Angles2=CalculateThethaAndAlpha (gamma2, ox2, oy2);
		Angles3=CalculateThethaAndAlpha (gamma3, ox3, oy3);
	}
	
	private float[] CalculateThethaAndAlpha(float gamma1, float ox1, float oy1){

		linkCounter = linkCounter + 1;
		
		float bx1 = ni * Mathf.Cos ((gamma1*Mathf.PI/2)/90);	//ni*cos(gammai)
		//Debug.Log ("bx1=" + bx1.ToString ());
		float by1 = ni * Mathf.Sin ((gamma1*Mathf.PI/2)/90);	//ni*sin(gammai)
		//Debug.Log ("by1=" + by1.ToString ());
		
		float Pyb = spherePosition.z;
		float Pxb = spherePosition.x;
		
		float A1=2*Lbrazo*(oy1-(bx1*Mathf.Sin((phi*Mathf.PI/2)/90))-(by1*Mathf.Cos((phi*Mathf.PI/2)/90))-Pyb);
		//Debug.Log ("A1=" + A1.ToString ());
		float B1=2*Lbrazo*(ox1+by1*Mathf.Sin((phi*Mathf.PI/2)/90)-bx1*Mathf.Cos((phi*Mathf.PI/2)/90)-Pxb);
		//Debug.Log ("B1=" + B1.ToString ());
		
		float C1 = -((Mathf.Pow (Lbrazo, 2)) - (2 * Pyb * oy1) - (2 * Pxb * ox1) + (Mathf.Pow (bx1, 2) + Mathf.Pow (by1, 2) + Mathf.Pow (ox1, 2) + Mathf.Pow (oy1, 2) + Mathf.Pow (Pxb, 2) + Mathf.Pow (Pyb, 2) - Mathf.Pow (LAntebrazo, 2)) +
		             ((2 * Mathf.Cos ((phi * Mathf.PI / 2) / 90)) * ((Pxb * bx1) + (Pyb * by1) - (bx1 * ox1) - (by1 * oy1))) + ((2 * Mathf.Sin ((phi * Mathf.PI / 2) / 90)) * ((Pyb * bx1) - (Pxb * by1) - (bx1 * oy1) + (by1 * ox1)))); //
		//Debug.Log ("C1=" + C1.ToString ());
		
		float theta1 = (Mathf.Atan2 ((A1),(B1)))+(Mathf.Atan2((Mathf.Sqrt (Mathf.Pow(A1,2)+Mathf.Pow(B1,2)-Mathf.Pow(C1,2))),C1));
		//Debug.Log ("heta 1 sin convt"+theta1.ToString());
		theta1=((theta1*90)/(Mathf.PI/2));
		
		float theta1CodoAbajo = (Mathf.Atan2 ((A1),(B1)))-(Mathf.Atan2((Mathf.Sqrt (Mathf.Pow(A1,2)+Mathf.Pow(B1,2)-Mathf.Pow(C1,2))),C1));
		//Debug.Log ("heta 1 sin convt"+theta1.ToString());
		theta1CodoAbajo=((theta1CodoAbajo*90)/(Mathf.PI/2));
		
		
		//Debug.Log ("Theta"+linkCounter.ToString()+" convertido: "+theta1.ToString());
		//Debug.Log ("ThetaCodoAbajo"+linkCounter.ToString()+" convertido: "+theta1CodoAbajo.ToString());
		
		float Alpha=CalculateAlpha (theta1,Pxb,bx1,by1, ox1);
		float[] Angles= new float[2];
		Angles [0] = theta1;
		Angles [1] = Alpha;
		return Angles ;
		
	}
	
	
	private float CalculateAlpha(float theta1, float Pxb, float bx1, float by1, float ox1)
	{
		
		float D1 = -Mathf.Sin(theta1*((Mathf.PI/2)/90));
		//Debug.Log ("D1: "+D1.ToString());
		float E1= Mathf.Cos(theta1*((Mathf.PI/2)/90));
		//Debug.Log ("E1: "+E1.ToString());
		float G1=(Pxb+(bx1*Mathf.Cos (phi*(Mathf.PI/2)/90))-(by1*Mathf.Sin (phi*(Mathf.PI/2)/90))-(ox1)-(Lbrazo*(Mathf.Cos (theta1*(Mathf.PI/2)/90))))/LAntebrazo;
		//Debug.Log ("G1 "+G1.ToString());
		float Alpha1= (Mathf.Atan2 ((D1),(E1)))+(Mathf.Atan2((Mathf.Sqrt (Mathf.Pow(D1,2)+Mathf.Pow(E1,2)-Mathf.Pow(G1,2))),G1));
		Alpha1=((Alpha1*90)/(Mathf.PI/2));
		//Debug.Log ("Alpha"+linkCounter.ToString()+" convertido: "+Alpha1.ToString());
		return Alpha1;
		
	}
	
	private void ConvertAnglesToPositive(){
		float[] AllAngles= new float[6];
		AllAngles=AssignAnglesXtoAllAngles (AllAngles);
		
		for(int i=0; i<=5; i++){
			if(AllAngles[i]<0){
				AllAngles[i]=AllAngles[i]+360;
			}
		}
		
		AssignAllAnglestoAnglesX (AllAngles);
		DebugLogAngles (AllAngles);
	}
	
	private float[] AssignAnglesXtoAllAngles (float[] AllAngles)
	{
		AllAngles [0] = Angles1 [0];
		AllAngles [1] = Angles2 [0];
		AllAngles [2] = Angles3 [0];
		AllAngles [3] = Angles1 [1];
		AllAngles [4] = Angles2 [1];
		AllAngles [5] = Angles3 [1];
		return AllAngles;
	}
	
	private void AssignAllAnglestoAnglesX (float[] AllAngles)
	{
		Angles1 [0] = AllAngles [0];
		Angles2 [0] = AllAngles [1];
		Angles3 [0] = AllAngles [2];
		Angles1 [1] = AllAngles [3];
		Angles2 [1] = AllAngles [4];
		Angles3 [1] = AllAngles [5];
	}
	
	private void DebugLogAngles (float[] AllAngles)
	{
		Debug.Log("Theta1 "+ AllAngles[0].ToString());
		Debug.Log("Theta2 "+ AllAngles[1].ToString());
		Debug.Log("Theta3 "+ AllAngles[2].ToString());
		
		Debug.Log("Alpha1 "+ AllAngles[3].ToString());
		Debug.Log("Alpha2 "+ AllAngles[4].ToString());
		Debug.Log("Alpha3 "+ AllAngles[5].ToString());
		
	}
}
