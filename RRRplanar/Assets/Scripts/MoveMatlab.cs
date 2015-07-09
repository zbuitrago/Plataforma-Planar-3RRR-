using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveMatlab : MonoBehaviour {

	public Transmision transmisor;
	private float LongitudLadoTriangulo=0.4f;//1.20490491f;//1.3856f;//3.0f; Matlab 
	private float Phi = (0*Mathf.PI)/180f; //Mathf.PI / 4; 63.21//-92.2223f
	private float LongitudEslabon1=1.6f;	//5.0f; Matlab
	private float LongitudEslabon2=1.6f;//0.869565217f;//4.0f; Matlab
	

	/////MATLAB///////
	/*private float CoordenadaXMotor1 = -1.5f;
	private float CoordenadaYMotor1 = -8.4f;

	private float CoordenadaXMotor2 = 6.9f;
	private float CoordenadaYMotor2 = -1.2f;

	private float CoordenadaXMotor3 = -6.6f;
	private float CoordenadaYMotor3 = 2.1f;	*/

	private float CoordenadaXMotor1; //=-0.3743629f;//-1.5f;//-0.3743629f;//Brazo que sirve -3.492431f;//1.42641f;
	private float CoordenadaYMotor1 ;//= 5.198504f;//-8.4f;//5.198504f;//Brazo que sirve 2.388299f;//3.632579f;
	private float CoordenadaZMotor1;
	
	private float CoordenadaXMotor2 ;//=-2.370654f;//6.9f; //-2.370654f;//Brazo que sirve -1.4949f;//-0.5698814f;
	private float CoordenadaYMotor2 ;//=2.038576f;//-1.2f;//2.038576f;//Brazo que sirve 5.539518f; //0.472651f;
	
	private float CoordenadaXMotor3 ;//=1.647024f; //-6.6f;//1.647024f;//Brazo que sirve -5.498871f;//3.447796f;
	private float CoordenadaYMotor3 ;//=2.046705f;//2.1f;//2.046705f;//Brazo que sirve 5.544016f;//0.4807794f;

	
	private float Thetha1;
	private float Alpha1;

	private float Thetha2;
	private float Alpha2;

	private float Thetha3;
	private float Alpha3;

	//Sx Codo Arriba o codo abajo; puede tomar valor de 1 o 0, por defecto empiezan en 0. Igual que matlab.//
	private int S1;
	private int S2;
	private int S3;

	private bool isStarted;

	private bool isTheta1BeenOnPositive;
	private bool isTheta1BeenOnNegative;
	private bool isTheta2BeenOnPositive;
	private bool isTheta2BeenOnNegative;
	private bool isTheta3BeenOnPositive;
	private bool isTheta3BeenOnNegative;

	private bool isAlpha1BeenOnPositive;
	private bool isAlpha1BeenOnNegative;
	private bool isAlpha2BeenOnPositive;
	private bool isAlpha2BeenOnNegative;
	private bool isAlpha3BeenOnPositive;
	private bool isAlpha3BeenOnNegative;

	private GameObject sphere;
	private Vector3 spherePosition;

	public GameObject brazo1;		
	public GameObject Antebrazo1;
	public GameObject brazo2;		
	public GameObject Antebrazo2;
	public GameObject brazo3;		
	public GameObject Antebrazo3;

	public Text Texto;
	public Text ErrorText;

	public Text Theta1Text;
	public Text Theta2Text;
	public Text Theta3Text;

	public Text Alpha1Text;
	public Text Alpha2Text;
	public Text Alpha3Text;

	// Use this for initialization
	void Start () {

		//Distancia M0tor 1 a tMotor 2
		/*Vector2 p1bien = new Vector2(-3.492431f, 2.388299f);
		Vector2 p2bien = new Vector2(-1.4949f, 5.539518f);
		Vector2 p3bien = new Vector2 (-5.498871f,5.544016f);
		Debug.Log ("Distancia de p1 a p2 Brazo que sirve: "+ Vector2.Distance(p1bien,p2bien));
		Debug.Log ("Distancia de p2 a p3 Brazo que sirve: "+ Vector2.Distance(p2bien,p3bien));
		Debug.Log ("Distancia de p1 a p3 Brazo que sirve: "+ Vector2.Distance(p1bien,p3bien));

		Vector2 p1mal = new Vector2(-0.3743629f, 5.198504f);
		Vector2 p2mal = new Vector2(-2.370654f, 2.038576f);
		Vector2 p3mal = new Vector2 (1.647024f,2.046705f);
		Debug.Log ("Distancia de p21 a p22 Brazo que no sirve: "+ Vector2.Distance(p1mal,p2mal));
		Debug.Log ("Distancia de p2 a p3 Brazo que no sirve: "+ Vector2.Distance(p2mal,p3mal));
		Debug.Log ("Distancia de p1 a p3 Brazo que no sirve: "+ Vector2.Distance(p1mal,p3mal));
*/

		//Distancia M0tor 2 a tMotor 3


		CoordenadaXMotor1 = brazo1.transform.position.x;
		CoordenadaYMotor1 = brazo1.transform.position.y;
		CoordenadaZMotor1 = brazo1.transform.position.z;
		Debug.Log ("CoordenadaXMotor1: "+CoordenadaXMotor1.ToString());
		Debug.Log ("CoordenadaYMotor1: "+CoordenadaYMotor1.ToString());
		Debug.Log ("CoordenadaZMotor1: "+CoordenadaZMotor1.ToString());

		CoordenadaXMotor2 = brazo2.transform.position.x;
		CoordenadaYMotor2 = brazo2.transform.position.z;

		CoordenadaXMotor3 = brazo3.transform.position.x;
		CoordenadaYMotor3 = brazo3.transform.position.z;



		S1 = 0;
		S2 = 0;
		S3 = 0;

		isStarted = false;
		isTheta1BeenOnPositive = false;

	}
	
	// Update is called once per frame
	void Update () {
		if(isStarted){

			MoveAngles (brazo1,Thetha1,isTheta1BeenOnPositive, isTheta1BeenOnNegative, "Thetha1");
			MoveAngles (brazo2,Thetha2,isTheta2BeenOnPositive, isTheta2BeenOnNegative, "Thetha2");
			MoveAngles (brazo3,Thetha3,isTheta3BeenOnPositive, isTheta3BeenOnNegative, "Thetha3");

			MoveAngles (Antebrazo1,Alpha1,isAlpha1BeenOnPositive, isAlpha1BeenOnNegative, "Alpha1");
			MoveAngles (Antebrazo2,Alpha2,isAlpha2BeenOnPositive, isAlpha2BeenOnNegative, "Alpha2");
			MoveAngles (Antebrazo3,Alpha3,isAlpha3BeenOnPositive, isAlpha3BeenOnNegative, "Alpha3");

		}
	}

	void MoveAngles (GameObject chain, float Angle, bool isFlagPositive, bool isFlagNegative, string StringAngle)
	{
		string AngleToDisplay;
		if (chain.transform.eulerAngles.y == 0) {
			chain.transform.Rotate (new Vector3 (0, -20 * Time.deltaTime, 0));
		}
		float resta = (Angle - (360 - (chain.transform.eulerAngles.y)));


		if ((resta <= 0.5f) && (isFlagPositive == false)) {
			switch(StringAngle){
			case "Thetha1":
				isTheta1BeenOnNegative=true;
				break;

			case "Thetha2":
				isTheta2BeenOnNegative=true;
				break;

			case "Thetha3":
				isTheta3BeenOnNegative=true;
				break;

			case "Alpha1":
				isAlpha1BeenOnNegative=true;
				break;

			case "Alpha2":
				isAlpha2BeenOnNegative=true;
				break;

			case "Alpha3":
				isAlpha3BeenOnNegative=true;
				break;
			}


			chain.transform.Rotate (new Vector3 (0, 20 * Time.deltaTime, 0));
		}

		if ((resta >= 0.5f) && (isFlagNegative == false)) {
			isFlagPositive = true;
			chain.transform.Rotate (new Vector3 (0, -20 * Time.deltaTime, 0));
		}
		Debug.Log ("angulo "+StringAngle+ " real: " + (360 - (chain.transform.eulerAngles.y)).ToString ());
	}

	public void GetSpherePosition(){
		ResetValues ();
		ErrorText.text = "";
		sphere=GameObject.Find ("sphere1");
		spherePosition = sphere.transform.position;
		spherePosition.y = 0;
		//Debug.Log ("La posicion es: "+spherePosition.ToString());
		Texto.text = spherePosition.ToString ();
		SolveEquations ();	
	}

	public void ResetValues ()
	{
		Debug.Log ("S1: " + S1.ToString () + "S2: " + S2.ToString () + "S3: " + S3.ToString ());
		isStarted = false;

		isTheta1BeenOnPositive = false;
		isTheta1BeenOnNegative = false;

		isTheta2BeenOnPositive = false;
		isTheta2BeenOnNegative = false;

		isTheta3BeenOnPositive = false;
		isTheta3BeenOnNegative = false;

		isAlpha1BeenOnPositive = false;
		isAlpha1BeenOnNegative = false;

		isAlpha2BeenOnPositive = false;
		isAlpha2BeenOnNegative = false;

		isAlpha3BeenOnPositive = false;
		isAlpha3BeenOnNegative = false;


		S1 = 0;
		S2 = 0;
		S3 = 0;

	}

	public void SolveEquations(){

		float CoordenadaXCentro = -0.4923694f;//spherePosition.x;//-0.6074f;//-0.4923694f;///spherePosition.x;//6.514634f;//;  //-3.6333f;// //-4.5f;// Base fija ensamble bien -3.741648
		float CoordenadaYCentro =3.359823f;//spherePosition.z;//3.3007f;//3.359823f;//spherePosition.z;//-0.8925756f;//  //5.1618f;// //4.1f;// Base fija ensamble bien 0.4682827
		//Debug.Log ("Xcentro: "+CoordenadaXCentro.ToString());
		//Debug.Log ("Ycentro: "+CoordenadaYCentro.ToString());


		float UbicacionCentroBase  = (Mathf.Sqrt(3)/3)*LongitudLadoTriangulo;
		//Debug.Log ("ubicacion centro base: " + UbicacionCentroBase.ToString ());  
		float Xa = CoordenadaXCentro -UbicacionCentroBase* Mathf.Cos(Phi+(Mathf.PI/6)); 
		//Debug.Log ("cordenada xa: " + Xa.ToString ());  
		float Ya = CoordenadaYCentro -UbicacionCentroBase*Mathf.Sin(Phi+(Mathf.PI/6));   
		//Debug.Log ("coordenada Ya: " + Ya.ToString ());  
		
		float[] Xd= new float[2];
		float[] Yd= new float[2];


	

		Xd[0]=(1.0f/2.0f)*(1.0f/(-8.0f*CoordenadaXMotor1*Xa-8.0f*Ya*CoordenadaYMotor1+4.0f*Mathf.Pow(Ya,2)+4.0f*Mathf.Pow(CoordenadaYMotor1,2)+4.0f*Mathf.Pow(Xa,2)+4.0f*Mathf.Pow(CoordenadaXMotor1,2))
		                   *(-4.0f*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)-4.0f*Mathf.Pow(Ya,2)*CoordenadaYMotor1+4.0f*Mathf.Pow(Ya,3)+4.0f*Mathf.Pow(CoordenadaXMotor1,2)
		  *CoordenadaYMotor1-4.0f*Ya*Mathf.Pow(LongitudEslabon2,2)+4.0f*Ya*Mathf.Pow(LongitudEslabon1,2)+4.0f*Ya*Mathf.Pow(CoordenadaXMotor1,2)+4.0f*Mathf.Pow(LongitudEslabon2,2)
		  *CoordenadaYMotor1-4.0f*Ya*Mathf.Pow(CoordenadaYMotor1,2)+4.0f*Mathf.Pow(Xa,2)*Ya-8.0f*CoordenadaXMotor1*Xa*CoordenadaYMotor1+4.0f*Mathf.Pow(Xa,2)*CoordenadaYMotor1-8.0f
		  *CoordenadaXMotor1*Xa*Ya+4.0f*Mathf.Pow(CoordenadaYMotor1,3)+4.0f*(Mathf.Sqrt(-2*Mathf.Pow(Xa,4)*Mathf.Pow(CoordenadaYMotor1,2)+2.0f*CoordenadaXMotor1*Xa*Mathf.Pow(LongitudEslabon2,4)
		                                                                              +2.0f*Mathf.Pow(Xa,4)*Mathf.Pow(LongitudEslabon2,2)+12.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon1,2)+2.0f
		                                                                              *Mathf.Pow(Xa,4)*Mathf.Pow(LongitudEslabon1,2)-15.0f*Mathf.Pow(Xa,4)*Mathf.Pow(CoordenadaXMotor1,2)-2.0f*Mathf.Pow(Xa,4)*Mathf.Pow(Ya,2)+12.0f*Mathf.Pow(CoordenadaXMotor1,2)
		                                                                              *Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon2,2)-8.0f*CoordenadaXMotor1*Mathf.Pow(Xa,3)*Mathf.Pow(LongitudEslabon2,2)+2.0f*CoordenadaXMotor1*Xa*Mathf.Pow(LongitudEslabon1,4)
		                                                                              +2.0f*Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(LongitudEslabon1,2)
		                                                                              -16.0f*Mathf.Pow(Xa,3)*Ya*CoordenadaXMotor1*CoordenadaYMotor1-4.0f*CoordenadaXMotor1*Xa*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(LongitudEslabon1,2)+8.0f*CoordenadaYMotor1*
		                                                                              Mathf.Pow(LongitudEslabon1,2)*CoordenadaXMotor1*Xa*Ya-4.0f*Ya*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(Xa,2)*CoordenadaYMotor1+8.0f*Ya*Mathf.Pow(LongitudEslabon2,2)*CoordenadaXMotor1*
		                                                                              Xa*CoordenadaYMotor1-4.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon2,2)*CoordenadaXMotor1*Xa-4.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon1,2)*CoordenadaXMotor1*Xa-4.0f
		                                                                              *Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(CoordenadaYMotor1,2)*CoordenadaXMotor1*Xa-8.0f*Ya*Mathf.Pow(CoordenadaYMotor1,3)*CoordenadaXMotor1*Xa+8.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaXMotor1,3)
		                                                                              *Xa-Mathf.Pow(Xa,6)-Mathf.Pow(CoordenadaXMotor1,6)-4.0f*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)*Ya*Mathf.Pow(CoordenadaXMotor1,2)-4.0f*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)
		                                                                              *Mathf.Pow(Xa,2)*Ya-4.0f*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(LongitudEslabon1,2)*CoordenadaXMotor1*Xa+12.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaYMotor1,2)*
		                                                                              CoordenadaXMotor1*Xa-8.0f*Mathf.Pow(Ya,3)*CoordenadaYMotor1*CoordenadaXMotor1*Xa-4.0f*Mathf.Pow(CoordenadaXMotor1,2)*CoordenadaYMotor1*Ya*Mathf.Pow(LongitudEslabon2,2)
		                                                                              +24.0f*Mathf.Pow(CoordenadaXMotor1,2)*CoordenadaYMotor1*Mathf.Pow(Xa,2)*Ya-16.0f*Mathf.Pow(CoordenadaXMotor1,3)*CoordenadaYMotor1*Xa*Ya-Mathf.Pow(Ya,4)*Mathf.Pow(CoordenadaXMotor1,2)
		                                                                              -Mathf.Pow(Ya,4)*Mathf.Pow(Xa,2)-2.0f*Mathf.Pow(CoordenadaXMotor1,4)*Mathf.Pow(CoordenadaYMotor1,2)-Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,4)-2.0f*Mathf.Pow(Ya,2)
		                                                                              *Mathf.Pow(CoordenadaXMotor1,4)-Mathf.Pow(Xa,2)*Mathf.Pow(CoordenadaYMotor1,4)+6.0f*CoordenadaXMotor1*Mathf.Pow(Xa,5)+6.0f*Mathf.Pow(CoordenadaXMotor1,5)*Xa+20.0f*Mathf.Pow(CoordenadaXMotor1,3)
		                                                                              *Mathf.Pow(Xa,3)-15.0f*Mathf.Pow(CoordenadaXMotor1,4)*Mathf.Pow(Xa,2)-Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon2,4)-Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon1,4)-Mathf.Pow(CoordenadaXMotor1,2)
		                                                                              *Mathf.Pow(LongitudEslabon2,4)-Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(LongitudEslabon1,4)+2.0f*Mathf.Pow(CoordenadaXMotor1,4)*Mathf.Pow(LongitudEslabon2,2)+2.0f*Mathf.Pow(CoordenadaXMotor1,4)
		                                                                              *Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(CoordenadaXMotor1,2)+2.0f*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(LongitudEslabon1,2)
		                                                                              *Mathf.Pow(Xa,2)-6.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(CoordenadaXMotor1,2)+4.0f*Mathf.Pow(Ya,3)*CoordenadaYMotor1*Mathf.Pow(CoordenadaXMotor1,2)+4.0f*Mathf.Pow(Ya,3)*
		                                                                              CoordenadaYMotor1*Mathf.Pow(Xa,2)-6.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(Xa,2)+2.0f*Mathf.Pow(Ya,4)*CoordenadaXMotor1*Xa+4.0f*Mathf.Pow(CoordenadaXMotor1,4)*CoordenadaYMotor1*
		                                                                              Ya+2.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(LongitudEslabon2,2)+4.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,3)*Ya+8.0f
		                                                                              *Mathf.Pow(CoordenadaXMotor1,3)*Mathf.Pow(CoordenadaYMotor1,2)*Xa-12.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(Xa,2)+2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon2,2)*
		                                                                              Mathf.Pow(CoordenadaXMotor1,2)+2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(Xa,2)+2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(CoordenadaXMotor1,2)+2.0f*
		                                                                              Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(Xa,2)-12.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(Xa,2)+2.0f*Mathf.Pow(LongitudEslabon2,2)*
		                                                                              Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(Xa,2)+4.0f*Ya*Mathf.Pow(CoordenadaYMotor1,3)*Mathf.Pow(Xa,2)+4.0f*Mathf.Pow(Xa,4)*Ya*CoordenadaYMotor1+8.0f*Mathf.Pow(Xa,3)*Mathf.Pow(Ya,2)*
		                                                                              CoordenadaXMotor1+8.0f*CoordenadaXMotor1*Mathf.Pow(Xa,3)*Mathf.Pow(CoordenadaYMotor1,2)+2.0f*CoordenadaXMotor1*Xa*Mathf.Pow(CoordenadaYMotor1,4)-8.0f*CoordenadaXMotor1*Mathf.Pow(Xa,3)*Mathf.Pow(LongitudEslabon1,2)
		                                                                              -8.0f*Mathf.Pow(CoordenadaXMotor1,3)*Xa*Mathf.Pow(LongitudEslabon2,2)-8.0f*Mathf.Pow(CoordenadaXMotor1,3)*Xa*Mathf.Pow(LongitudEslabon1,2))))*CoordenadaYMotor1-1.0f/
(-8.0f*CoordenadaXMotor1*Xa-8.0f*Ya*CoordenadaYMotor1+4.0f*Mathf.Pow(Ya,2)+4.0f*Mathf.Pow(CoordenadaYMotor1,2)+4.0f*Mathf.Pow(Xa,2)+4.0f*Mathf.Pow(CoordenadaXMotor1,2))*
		                   (-4.0f*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)-4.0f*Mathf.Pow(Ya,2)*CoordenadaYMotor1+4.0f*Mathf.Pow(Ya,3)+4.0f*Mathf.Pow(CoordenadaXMotor1,2)*CoordenadaYMotor1-4.0f*Ya*Mathf.Pow(LongitudEslabon2,2)+
		 4.0f*Ya*Mathf.Pow(LongitudEslabon1,2)+4.0f*Ya*Mathf.Pow(CoordenadaXMotor1,2)+4.0f*Mathf.Pow(LongitudEslabon2,2)*CoordenadaYMotor1-4.0f*Ya*Mathf.Pow(CoordenadaYMotor1,2)+4.0f*Mathf.Pow(Xa,2)*
		 Ya-8.0f*CoordenadaXMotor1*Xa*CoordenadaYMotor1+4.0f*Mathf.Pow(Xa,2)*CoordenadaYMotor1-8.0f*CoordenadaXMotor1*Xa*Ya+4.0f*Mathf.Pow(CoordenadaYMotor1,3)+4.0f*(Mathf.Sqrt(-2*Mathf.Pow(Xa,4)
        *Mathf.Pow(CoordenadaYMotor1,2)+2.0f*CoordenadaXMotor1*Xa*Mathf.Pow(LongitudEslabon2,4)+2.0f*Mathf.Pow(Xa,4)*Mathf.Pow(LongitudEslabon2,2)+12.0f*Mathf.Pow(CoordenadaXMotor1,2)*
        Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(Xa,4)*Mathf.Pow(LongitudEslabon1,2)-15.0f*Mathf.Pow(Xa,4)*Mathf.Pow(CoordenadaXMotor1,2)-2.0f*Mathf.Pow(Xa,4)*
        Mathf.Pow(Ya,2)+12.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon2,2)-8.0f*CoordenadaXMotor1*Mathf.Pow(Xa,3)*Mathf.Pow(LongitudEslabon2,2)+
        2.0f*CoordenadaXMotor1*Xa*Mathf.Pow(LongitudEslabon1,4)+2.0f*Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(CoordenadaXMotor1,2)
        *Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(LongitudEslabon1,2)-16.0f*Mathf.Pow(Xa,3)*Ya*CoordenadaXMotor1*CoordenadaYMotor1-4.0f*CoordenadaXMotor1*Xa*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(LongitudEslabon1,2)
        +8.0f*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)*CoordenadaXMotor1*Xa*Ya-4.0f*Ya*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(Xa,2)*CoordenadaYMotor1+8.0f*Ya*Mathf.Pow(LongitudEslabon2,2)
        *CoordenadaXMotor1*Xa*CoordenadaYMotor1-4.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon2,2)*CoordenadaXMotor1*Xa-4.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon1,2)*CoordenadaXMotor1*Xa
        -4.0f*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(CoordenadaYMotor1,2)*CoordenadaXMotor1*Xa-8.0f*Ya*Mathf.Pow(CoordenadaYMotor1,3)*CoordenadaXMotor1*Xa+8.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaXMotor1,3)*
        Xa-Mathf.Pow(Xa,6)-Mathf.Pow(CoordenadaXMotor1,6)-4.0f*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)*Ya*Mathf.Pow(CoordenadaXMotor1,2)-4.0f*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)*
        Mathf.Pow(Xa,2)*Ya-4.0f*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(LongitudEslabon1,2)*CoordenadaXMotor1*Xa+12.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaYMotor1,2)*CoordenadaXMotor1*Xa-8.0f*
        Mathf.Pow(Ya,3)*CoordenadaYMotor1*CoordenadaXMotor1*Xa-4.0f*Mathf.Pow(CoordenadaXMotor1,2)*CoordenadaYMotor1*Ya*Mathf.Pow(LongitudEslabon2,2)+24.0f*Mathf.Pow(CoordenadaXMotor1,2)
        *CoordenadaYMotor1*Mathf.Pow(Xa,2)*Ya-16.0f*Mathf.Pow(CoordenadaXMotor1,3)*CoordenadaYMotor1*Xa*Ya-Mathf.Pow(Ya,4)*Mathf.Pow(CoordenadaXMotor1,2)-Mathf.Pow(Ya,4)*Mathf.Pow(Xa,2)
        -2.0f*Mathf.Pow(CoordenadaXMotor1,4)*Mathf.Pow(CoordenadaYMotor1,2)-Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,4)-2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaXMotor1,4)-
        Mathf.Pow(Xa,2)*Mathf.Pow(CoordenadaYMotor1,4)+6.0f*CoordenadaXMotor1*Mathf.Pow(Xa,5)+6.0f*Mathf.Pow(CoordenadaXMotor1,5)*Xa+20.0f*Mathf.Pow(CoordenadaXMotor1,3)*Mathf.Pow(Xa,3)-15.0f*
        Mathf.Pow(CoordenadaXMotor1,4)*Mathf.Pow(Xa,2)-Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon2,4)-Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon1,4)-Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(LongitudEslabon2,4)
        -Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(LongitudEslabon1,4)+2.0f*Mathf.Pow(CoordenadaXMotor1,4)*Mathf.Pow(LongitudEslabon2,2)+2.0f*Mathf.Pow(CoordenadaXMotor1,4)*Mathf.Pow(LongitudEslabon1,2)+2.0f
        *Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(CoordenadaXMotor1,2)+2.0f*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(Xa,2)-6.0f*Mathf.Pow(Ya,2)*
        Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(CoordenadaXMotor1,2)+4*Mathf.Pow(Ya,3)*CoordenadaYMotor1*Mathf.Pow(CoordenadaXMotor1,2)+4.0f*Mathf.Pow(Ya,3)*CoordenadaYMotor1*Mathf.Pow(Xa,2)-6.0f
        *Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(Xa,2)+2.0f*Mathf.Pow(Ya,4)*CoordenadaXMotor1*Xa+4.0f*Mathf.Pow(CoordenadaXMotor1,4)*CoordenadaYMotor1*Ya+2.0f*Mathf.Pow(CoordenadaXMotor1,2)
        *Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(LongitudEslabon2,2)+4.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,3)*Ya+8.0f*Mathf.Pow(CoordenadaXMotor1,3)*Mathf.Pow(CoordenadaYMotor1,2)*Xa-12.0f
        *Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(Xa,2)+2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(CoordenadaXMotor1,2)+2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon2,2)*
        Mathf.Pow(Xa,2)+2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(CoordenadaXMotor1,2)+2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(Xa,2)-12.0f*Mathf.Pow(Ya,2)*
        Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(Xa,2)+2.0f*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(Xa,2)+4.0f*Ya*Mathf.Pow(CoordenadaYMotor1,3)*Mathf.Pow(Xa,2)+4.0f
        *Mathf.Pow(Xa,4)*Ya*CoordenadaYMotor1+8.0f*Mathf.Pow(Xa,3)*Mathf.Pow(Ya,2)*CoordenadaXMotor1+8.0f*CoordenadaXMotor1*Mathf.Pow(Xa,3)*Mathf.Pow(CoordenadaYMotor1,2)+2.0f*CoordenadaXMotor1*Xa*Mathf.Pow(CoordenadaYMotor1,4)-8.0f
        *CoordenadaXMotor1*Mathf.Pow(Xa,3)*Mathf.Pow(LongitudEslabon1,2)-8.0f*Mathf.Pow(CoordenadaXMotor1,3)*Xa*Mathf.Pow(LongitudEslabon2,2)-8.0f*Mathf.Pow(CoordenadaXMotor1,3)*Xa*
        Mathf.Pow(LongitudEslabon1,2))))*Ya+Mathf.Pow(Xa,2)+Mathf.Pow(Ya,2)-Mathf.Pow(LongitudEslabon2,2)-Mathf.Pow(CoordenadaXMotor1,2)-Mathf.Pow(CoordenadaYMotor1,2)+Mathf.Pow(LongitudEslabon1,2))
			/(Xa-CoordenadaXMotor1);



		Xd[1]=(1.0f/2.0f)*(1.0f/(-8.0f*CoordenadaXMotor1*Xa-8.0f*Ya*CoordenadaYMotor1+4.0f*Mathf.Pow(Ya,2)+4.0f*Mathf.Pow(CoordenadaYMotor1,2)+4.0f*Mathf.Pow(Xa,2)+4.0f*Mathf.Pow(CoordenadaXMotor1,2))*
		                   (-4.0f*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)-4.0f*Mathf.Pow(Ya,2)*CoordenadaYMotor1+4.0f*Mathf.Pow(Ya,3)+4.0f*Mathf.Pow(CoordenadaXMotor1,2)*CoordenadaYMotor1-4.0f*
		 Ya*Mathf.Pow(LongitudEslabon2,2)+4.0f*Ya*Mathf.Pow(LongitudEslabon1,2)+4.0f*Ya*Mathf.Pow(CoordenadaXMotor1,2)+4.0f*Mathf.Pow(LongitudEslabon2,2)*CoordenadaYMotor1-4.0f*
		 Ya*Mathf.Pow(CoordenadaYMotor1,2)+4*Mathf.Pow(Xa,2)*Ya-8.0f*CoordenadaXMotor1*Xa*CoordenadaYMotor1+4.0f*Mathf.Pow(Xa,2)*CoordenadaYMotor1-8.0f*CoordenadaXMotor1*Xa*Ya+4.0f*
		 Mathf.Pow(CoordenadaYMotor1,3)-4.0f*(Mathf.Sqrt(-2*Mathf.Pow(Xa,4)*Mathf.Pow(CoordenadaYMotor1,2)+2.0f*CoordenadaXMotor1*Xa*Mathf.Pow(LongitudEslabon2,4)+2.0f*Mathf.Pow(Xa,4)*
		                                                Mathf.Pow(LongitudEslabon2,2)+12.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(Xa,4)*Mathf.Pow(LongitudEslabon1,2)-15.0f*
		                                                Mathf.Pow(Xa,4)*Mathf.Pow(CoordenadaXMotor1,2)-2.0f*Mathf.Pow(Xa,4)*Mathf.Pow(Ya,2)+12.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon2,2)
		                                                -8.0f*CoordenadaXMotor1*Mathf.Pow(Xa,3)*Mathf.Pow(LongitudEslabon2,2)+2.0f*CoordenadaXMotor1*Xa*Mathf.Pow(LongitudEslabon1,4)+2.0f*Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon2,2)*
		                                                Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(LongitudEslabon1,2)-16.0f*Mathf.Pow(Xa,3)*Ya*CoordenadaXMotor1*
		                                                CoordenadaYMotor1-4.0f*CoordenadaXMotor1*Xa*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(LongitudEslabon1,2)+8.0f*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)*CoordenadaXMotor1*Xa
		                                                *Ya-4.0f*Ya*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(Xa,2)*CoordenadaYMotor1+8.0f*Ya*Mathf.Pow(LongitudEslabon2,2)*CoordenadaXMotor1*Xa*CoordenadaYMotor1-4.0f*Mathf.Pow(Ya,2)*
		                                                Mathf.Pow(LongitudEslabon2,2)*CoordenadaXMotor1*Xa-4.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon1,2)*CoordenadaXMotor1*Xa-4.0f*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(CoordenadaYMotor1,2)*
		                                                CoordenadaXMotor1*Xa-8.0f*Ya*Mathf.Pow(CoordenadaYMotor1,3)*CoordenadaXMotor1*Xa+8.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaXMotor1,3)*Xa-Mathf.Pow(Xa,6)-Mathf.Pow(CoordenadaXMotor1,6)
		                                                -4.0f*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)*Ya*Mathf.Pow(CoordenadaXMotor1,2)-4.0f*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(Xa,2)*Ya-4.0f*Mathf.Pow(CoordenadaYMotor1,2)*
		                                                Mathf.Pow(LongitudEslabon1,2)*CoordenadaXMotor1*Xa+12.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaYMotor1,2)*CoordenadaXMotor1*Xa-8.0f*Mathf.Pow(Ya,3)*CoordenadaYMotor1*CoordenadaXMotor1*
		                                                Xa-4.0f*Mathf.Pow(CoordenadaXMotor1,2.0f)*CoordenadaYMotor1*Ya*Mathf.Pow(LongitudEslabon2,2)+24.0f*Mathf.Pow(CoordenadaXMotor1,2)*CoordenadaYMotor1*Mathf.Pow(Xa,2)*Ya-
		                                                16.0f*Mathf.Pow(CoordenadaXMotor1,3)*CoordenadaYMotor1*Xa*Ya-Mathf.Pow(Ya,4)*Mathf.Pow(CoordenadaXMotor1,2)-Mathf.Pow(Ya,4)*Mathf.Pow(Xa,2)-2.0f*Mathf.Pow(CoordenadaXMotor1,4)
		                                                *Mathf.Pow(CoordenadaYMotor1,2)-Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,4)-2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaXMotor1,4)-Mathf.Pow(Xa,2)*
		                                                Mathf.Pow(CoordenadaYMotor1,4)+6.0f*CoordenadaXMotor1*Mathf.Pow(Xa,5)+6.0f*Mathf.Pow(CoordenadaXMotor1,5)*Xa+20.0f*Mathf.Pow(CoordenadaXMotor1,3)*Mathf.Pow(Xa,3)-15.0f*
		                                                Mathf.Pow(CoordenadaXMotor1,4)*Mathf.Pow(Xa,2)-Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon2,4)-Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon1,4)-Mathf.Pow(CoordenadaXMotor1,2)*
		                                                Mathf.Pow(LongitudEslabon2,4)-Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(LongitudEslabon1,4)+2.0f*Mathf.Pow(CoordenadaXMotor1,4)*Mathf.Pow(LongitudEslabon2,2)+2.0f*Mathf.Pow(CoordenadaXMotor1,4)*
		                                                Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(CoordenadaXMotor1,2)+2.0f*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(LongitudEslabon1,2)*
		                                                Mathf.Pow(Xa,2)-6.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(CoordenadaXMotor1,2)+4.0f*Mathf.Pow(Ya,3)*CoordenadaYMotor1*Mathf.Pow(CoordenadaXMotor1,2)+
		                                                4.0f*Mathf.Pow(Ya,3)*CoordenadaYMotor1*Mathf.Pow(Xa,2)-6.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(Xa,2)+2.0f*Mathf.Pow(Ya,4)*CoordenadaXMotor1*Xa+4.0f*
		                                                Mathf.Pow(CoordenadaXMotor1,4)*CoordenadaYMotor1*Ya+2.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(LongitudEslabon2,2)+4.0f*Mathf.Pow(CoordenadaXMotor1,2)*
		                                                Mathf.Pow(CoordenadaYMotor1,3)*Ya+8.0f*Mathf.Pow(CoordenadaXMotor1,3)*Mathf.Pow(CoordenadaYMotor1,2)*Xa-12.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,2)*
		                                                Mathf.Pow(Xa,2)+2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(CoordenadaXMotor1,2)+2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(Xa,2)+2.0f*
		                                                Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(CoordenadaXMotor1,2)+2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(Xa,2)-12.0f*Mathf.Pow(Ya,2)*
		                                                Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(Xa,2)+2.0f*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(Xa,2)+4*Ya*Mathf.Pow(CoordenadaYMotor1,3)*
		                                                Mathf.Pow(Xa,2)+4.0f*Mathf.Pow(Xa,4)*Ya*CoordenadaYMotor1+8.0f*Mathf.Pow(Xa,3)*Mathf.Pow(Ya,2)*CoordenadaXMotor1+8.0f*CoordenadaXMotor1*Mathf.Pow(Xa,3)*Mathf.Pow(CoordenadaYMotor1,2)+
		                                                2.0f*CoordenadaXMotor1*Xa*Mathf.Pow(CoordenadaYMotor1,4)-8.0f*CoordenadaXMotor1*Mathf.Pow(Xa,3)*Mathf.Pow(LongitudEslabon1,2)-8.0f*Mathf.Pow(CoordenadaXMotor1,3)*Xa*Mathf.Pow(LongitudEslabon2,2)
		                                                -8.0f*Mathf.Pow(CoordenadaXMotor1,3)*Xa*Mathf.Pow(LongitudEslabon1,2))))*CoordenadaYMotor1-1.0f/(-8.0f*CoordenadaXMotor1*Xa-8.0f*Ya*CoordenadaYMotor1+4.0f*Mathf.Pow(Ya,2)+
		4.0f*Mathf.Pow(CoordenadaYMotor1,2)+4.0f*Mathf.Pow(Xa,2)+4.0f*Mathf.Pow(CoordenadaXMotor1,2))*(-4.0f*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)-4.0f*Mathf.Pow(Ya,2)*
		CoordenadaYMotor1+4.0f*Mathf.Pow(Ya,3)+4.0f*Mathf.Pow(CoordenadaXMotor1,2)*CoordenadaYMotor1-4.0f*Ya*Mathf.Pow(LongitudEslabon2,2)+4.0f*Ya*Mathf.Pow(LongitudEslabon1,2)+
		4.0f*Ya*Mathf.Pow(CoordenadaXMotor1,2)+4.0f*Mathf.Pow(LongitudEslabon2,2)*CoordenadaYMotor1-4.0f*Ya*Mathf.Pow(CoordenadaYMotor1,2)+4.0f*Mathf.Pow(Xa,2)*Ya-8.0f*
		                                                                                               CoordenadaXMotor1*Xa*CoordenadaYMotor1+4.0f*Mathf.Pow(Xa,2)*CoordenadaYMotor1-8.0f*CoordenadaXMotor1*Xa*Ya+4.0f*Mathf.Pow(CoordenadaYMotor1,3)-4.0f*(Mathf.Sqrt(-2*Mathf.Pow(Xa,4)*
		                                                                                                                                                                Mathf.Pow(CoordenadaYMotor1,2)+2.0f*CoordenadaXMotor1*Xa*Mathf.Pow(LongitudEslabon2,4)+2.0f*Mathf.Pow(Xa,4)*Mathf.Pow(LongitudEslabon2,2)+12.0f*Mathf.Pow(CoordenadaXMotor1,2)*
		                                                                                                                                                                Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(Xa,4)*Mathf.Pow(LongitudEslabon1,2)-15.0f*Mathf.Pow(Xa,4)*Mathf.Pow(CoordenadaXMotor1,2)-2.0f*Mathf.Pow(Xa,4)
		                                                                                                                                                                *Mathf.Pow(Ya,2)+12.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon2,2)-8.0f*CoordenadaXMotor1*Mathf.Pow(Xa,3)*Mathf.Pow(LongitudEslabon2,2)+
		                                                                                                                                                                2.0f*CoordenadaXMotor1*Xa*Mathf.Pow(LongitudEslabon1,4)+2.0f*Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(CoordenadaXMotor1,2)*
		                                                                                                                                                                Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(LongitudEslabon1,2)-16.0f*Mathf.Pow(Xa,3)*Ya*CoordenadaXMotor1*CoordenadaYMotor1-4.0f*CoordenadaXMotor1*Xa*Mathf.Pow(LongitudEslabon2,2)*
		                                                                                                                                                                Mathf.Pow(LongitudEslabon1,2)+8.0f*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)*CoordenadaXMotor1*Xa*Ya-4.0f*Ya*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(Xa,2)*
		                                                                                                                                                                CoordenadaYMotor1+8.0f*Ya*Mathf.Pow(LongitudEslabon2,2)*CoordenadaXMotor1*Xa*CoordenadaYMotor1-4.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon2,2)*CoordenadaXMotor1*Xa-4.0f*
		                                                                                                                                                                Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon1,2)*CoordenadaXMotor1*Xa-4.0f*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(CoordenadaYMotor1,2)*CoordenadaXMotor1*Xa-8.0f*Ya*Mathf.Pow(CoordenadaYMotor1,3)*
		                                                                                                                                                                CoordenadaXMotor1*Xa+8.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaXMotor1,3)*Xa-Mathf.Pow(Xa,6)-Mathf.Pow(CoordenadaXMotor1,6)-4.0f*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)*
		                                                                                                                                                                Ya*Mathf.Pow(CoordenadaXMotor1,2)-4.0f*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(Xa,2)*Ya-4.0f*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(LongitudEslabon1,2)*
		                                                                                                                                                                CoordenadaXMotor1*Xa+12.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaYMotor1,2)*CoordenadaXMotor1*Xa-8.0f*Mathf.Pow(Ya,3)*CoordenadaYMotor1*CoordenadaXMotor1*Xa-4.0f*Mathf.Pow(CoordenadaXMotor1,2)*
		                                                                                                                                                                CoordenadaYMotor1*Ya*Mathf.Pow(LongitudEslabon2,2)+24.0f*Mathf.Pow(CoordenadaXMotor1,2)*CoordenadaYMotor1*Mathf.Pow(Xa,2)*Ya-16.0f*Mathf.Pow(CoordenadaXMotor1,3)*CoordenadaYMotor1*Xa*
		                                                                                                                                                                Ya-Mathf.Pow(Ya,4)*Mathf.Pow(CoordenadaXMotor1,2)-Mathf.Pow(Ya,4)*Mathf.Pow(Xa,2)-2.0f*Mathf.Pow(CoordenadaXMotor1,4)*Mathf.Pow(CoordenadaYMotor1,2)-Mathf.Pow(CoordenadaXMotor1,2)*
		                                                                                                                                                                Mathf.Pow(CoordenadaYMotor1,4)-2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaXMotor1,4)-Mathf.Pow(Xa,2)*Mathf.Pow(CoordenadaYMotor1,4)+6.0f*CoordenadaXMotor1*Mathf.Pow(Xa,5)+6.0f*
		                                                                                                                                                                Mathf.Pow(CoordenadaXMotor1,5)*Xa+20.0f*Mathf.Pow(CoordenadaXMotor1,3)*Mathf.Pow(Xa,3)-15.0f*Mathf.Pow(CoordenadaXMotor1,4)*Mathf.Pow(Xa,2)-Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon2,4)-
		                                                                                                                                                                Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon1,4)-Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(LongitudEslabon2,4)-Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(LongitudEslabon1,4)+2.0f*
		                                                                                                                                                                Mathf.Pow(CoordenadaXMotor1,4)*Mathf.Pow(LongitudEslabon2,2)+2.0f*Mathf.Pow(CoordenadaXMotor1,4)*Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(LongitudEslabon1,2)*
		                                                                                                                                                                Mathf.Pow(CoordenadaXMotor1,2)+2.0f*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(Xa,2)-6.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(CoordenadaXMotor1,2)+
		                                                                                                                                                                4.0f*Mathf.Pow(Ya,3)*CoordenadaYMotor1*Mathf.Pow(CoordenadaXMotor1,2)+4.0f*Mathf.Pow(Ya,3)*CoordenadaYMotor1*Mathf.Pow(Xa,2)-6.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaYMotor1,2)*
		                                                                                                                                                                Mathf.Pow(Xa,2)+2.0f*Mathf.Pow(Ya,4)*CoordenadaXMotor1*Xa+4.0f*Mathf.Pow(CoordenadaXMotor1,4)*CoordenadaYMotor1*Ya+2.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,2)*
		                                                                                                                                                                Mathf.Pow(LongitudEslabon2,2)+4.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,3)*Ya+8.0f*Mathf.Pow(CoordenadaXMotor1,3)*Mathf.Pow(CoordenadaYMotor1,2)*Xa-12.0f*
		                                                                                                                                                                Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(Xa,2)+2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(CoordenadaXMotor1,2)+2.0f*Mathf.Pow(Ya,2)*
		                                                                                                                                                                Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(Xa,2)+2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(CoordenadaXMotor1,2)+2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon1,2)
		                                                                                                                                                                *Mathf.Pow(Xa,2)-12.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(Xa,2)+2.0f*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(Xa,2)+4.0f*Ya*
		                                                                                                                                                                Mathf.Pow(CoordenadaYMotor1,3)*Mathf.Pow(Xa,2)+4.0f*Mathf.Pow(Xa,4)*Ya*CoordenadaYMotor1+8.0f*Mathf.Pow(Xa,3)*Mathf.Pow(Ya,2)*CoordenadaXMotor1+8.0f*CoordenadaXMotor1*Mathf.Pow(Xa,3)*
		                                                                                                                                                                Mathf.Pow(CoordenadaYMotor1,2)+2.0f*CoordenadaXMotor1*Xa*Mathf.Pow(CoordenadaYMotor1,4)-8.0f*CoordenadaXMotor1*Mathf.Pow(Xa,3)*Mathf.Pow(LongitudEslabon1,2)-8.0f*Mathf.Pow(CoordenadaXMotor1,3)
		                                                                                                                                                                *Xa*Mathf.Pow(LongitudEslabon2,2)-8.0f*Mathf.Pow(CoordenadaXMotor1,3)*Xa*Mathf.Pow(LongitudEslabon1,2))))*Ya+Mathf.Pow(Xa,2)+Mathf.Pow(Ya,2)-Mathf.Pow(LongitudEslabon2,2)-
		                   Mathf.Pow(CoordenadaXMotor1,2)-Mathf.Pow(CoordenadaYMotor1,2)+Mathf.Pow(LongitudEslabon1,2))/(Xa-CoordenadaXMotor1);
		                  

		Yd [0] = (1.0f / 2.0f) / (-8.0f * CoordenadaXMotor1 * Xa - 8.0f * Ya * CoordenadaYMotor1 + 4.0f * Mathf.Pow (Ya, 2) + 4.0f * Mathf.Pow (CoordenadaYMotor1, 2) + 4.0f * Mathf.Pow (Xa, 2) + 4.0f * Mathf.Pow (CoordenadaXMotor1, 2)) *
			(-4*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)-4*Mathf.Pow(Ya,2)*CoordenadaYMotor1+4*Mathf.Pow(Ya,3)+4*Mathf.Pow(CoordenadaXMotor1,2)*CoordenadaYMotor1-4*Ya*
			 Mathf.Pow(LongitudEslabon2,2)+4.0f*Ya*Mathf.Pow(LongitudEslabon1,2)+4.0f*Ya*Mathf.Pow(CoordenadaXMotor1,2)+4.0f*Mathf.Pow(LongitudEslabon2,2)*CoordenadaYMotor1-4.0f*Ya*
			 Mathf.Pow(CoordenadaYMotor1,2)+4.0f*Mathf.Pow(Xa,2)*Ya-8.0f*CoordenadaXMotor1*Xa*CoordenadaYMotor1+4.0f*Mathf.Pow(Xa,2)*CoordenadaYMotor1-8.0f*CoordenadaXMotor1*Xa*Ya+4.0f*
			 Mathf.Pow(CoordenadaYMotor1,3)+4.0f*(Mathf.Sqrt(-2.0f*Mathf.Pow(Xa,4)*Mathf.Pow(CoordenadaYMotor1,2)+2.0f*CoordenadaXMotor1*Xa*Mathf.Pow(LongitudEslabon2,4)+2.0f*Mathf.Pow(Xa,4)*
			                                                Mathf.Pow(LongitudEslabon2,2)+12.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(Xa,4)*
			                                                Mathf.Pow(LongitudEslabon1,2)-15.0f*Mathf.Pow(Xa,4)*Mathf.Pow(CoordenadaXMotor1,2)-2.0f*Mathf.Pow(Xa,4)*Mathf.Pow(Ya,2)+12.0f*
			                                                Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon2,2)-8.0f*CoordenadaXMotor1*Mathf.Pow(Xa,3)*
			                                                Mathf.Pow(LongitudEslabon2,2)+2.0f*CoordenadaXMotor1*Xa*Mathf.Pow(LongitudEslabon1,4)+2.0f*Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon2,2)*
			                                                Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(LongitudEslabon1,2)-16.0f*
			                                                Mathf.Pow(Xa,3)*Ya*CoordenadaXMotor1*CoordenadaYMotor1-4.0f*CoordenadaXMotor1*Xa*Mathf.Pow(LongitudEslabon2,2)*
			                                                Mathf.Pow(LongitudEslabon1,2)+8.0f*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)*CoordenadaXMotor1*Xa*Ya-4.0f*Ya*
			                                                Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(Xa,2)*CoordenadaYMotor1+8.0f*Ya*Mathf.Pow(LongitudEslabon2,2)*CoordenadaXMotor1*Xa*
			                                                CoordenadaYMotor1-4.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon2,2)*CoordenadaXMotor1*Xa-4.0f*Mathf.Pow(Ya,2)*
			                                                Mathf.Pow(LongitudEslabon1,2)*CoordenadaXMotor1*Xa-4.0f*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(CoordenadaYMotor1,2)*CoordenadaXMotor1*Xa
			                                                -8.0f*Ya*Mathf.Pow(CoordenadaYMotor1,3)*CoordenadaXMotor1*Xa+8.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaXMotor1,3)*Xa-Mathf.Pow(Xa,6)-
			                                                Mathf.Pow(CoordenadaXMotor1,6)-4.0f*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)*Ya*Mathf.Pow(CoordenadaXMotor1,2)-4.0f*
			                                                CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(Xa,2)*Ya-4.0f*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(LongitudEslabon1,2)*
			                                                CoordenadaXMotor1*Xa+12.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaYMotor1,2)*CoordenadaXMotor1*Xa-8.0f*Mathf.Pow(Ya,3)*CoordenadaYMotor1*
			                                                CoordenadaXMotor1*Xa-4.0f*Mathf.Pow(CoordenadaXMotor1,2)*CoordenadaYMotor1*Ya*Mathf.Pow(LongitudEslabon2,2)+24.0f*
			                                                Mathf.Pow(CoordenadaXMotor1,2)*CoordenadaYMotor1*Mathf.Pow(Xa,2)*Ya-16.0f*Mathf.Pow(CoordenadaXMotor1,3)*CoordenadaYMotor1*Xa*
			                                                Ya-Mathf.Pow(Ya,4)*Mathf.Pow(CoordenadaXMotor1,2)-Mathf.Pow(Ya,4)*Mathf.Pow(Xa,2)-2.0f*Mathf.Pow(CoordenadaXMotor1,4)*
			                                                Mathf.Pow(CoordenadaYMotor1,2)-Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,4)-2.0f*Mathf.Pow(Ya,2)*
			                                                Mathf.Pow(CoordenadaXMotor1,4)-Mathf.Pow(Xa,2)*Mathf.Pow(CoordenadaYMotor1,4)+6.0f*CoordenadaXMotor1*Mathf.Pow(Xa,5)+6.0f*
			                                                Mathf.Pow(CoordenadaXMotor1,5)*Xa+20.0f*Mathf.Pow(CoordenadaXMotor1,3)*Mathf.Pow(Xa,3)-15.0f*Mathf.Pow(CoordenadaXMotor1,4)*
			                                             Mathf.Pow(Xa,2)-Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon2,4)-Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon1,4)-
			                                                Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(LongitudEslabon2,4)-Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(LongitudEslabon1,4)+2.0f*
			                                                Mathf.Pow(CoordenadaXMotor1,4)*Mathf.Pow(LongitudEslabon2,2)+2.0f*Mathf.Pow(CoordenadaXMotor1,4)*Mathf.Pow(LongitudEslabon1,2)+2.0f*
			                                                Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(CoordenadaXMotor1,2)+2.0f*Mathf.Pow(CoordenadaYMotor1,2)*
			                                                Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(Xa,2)-6.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(CoordenadaXMotor1,2)+4.0f*
			                                                Mathf.Pow(Ya,3)*CoordenadaYMotor1*Mathf.Pow(CoordenadaXMotor1,2)+4.0f*Mathf.Pow(Ya,3)*CoordenadaYMotor1*Mathf.Pow(Xa,2)-6.0f*
			                                                Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(Xa,2)+2.0f*Mathf.Pow(Ya,4)*CoordenadaXMotor1*Xa+4.0f*
			                                                Mathf.Pow(CoordenadaXMotor1,4)*CoordenadaYMotor1*Ya+2.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,2)*
			                                                Mathf.Pow(LongitudEslabon2,2)+4.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,3)*Ya+8.0f*Mathf.Pow(CoordenadaXMotor1,3)*
			                                                Mathf.Pow(CoordenadaYMotor1,2)*Xa-12.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(Xa,2)+2.0f*
			                                                Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(CoordenadaXMotor1,2)+2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon2,2)*
			                                                Mathf.Pow(Xa,2)+2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(CoordenadaXMotor1,2)+2.0f*Mathf.Pow(Ya,2)*
			                                                Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(Xa,2)-12.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(Xa,2)+2.0f*
			                                                Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(Xa,2)+4.0f*Ya*Mathf.Pow(CoordenadaYMotor1,3)*Mathf.Pow(Xa,2)+4.0f*
			                                                Mathf.Pow(Xa,4)*Ya*CoordenadaYMotor1+8.0f*Mathf.Pow(Xa,3)*Mathf.Pow(Ya,2)*CoordenadaXMotor1+8.0f*CoordenadaXMotor1*Mathf.Pow(Xa,3)*
			                                                Mathf.Pow(CoordenadaYMotor1,2)+2.0f*CoordenadaXMotor1*Xa*Mathf.Pow(CoordenadaYMotor1,4)-8.0f*CoordenadaXMotor1*Mathf.Pow(Xa,3)*
			                                                Mathf.Pow(LongitudEslabon1,2)-8.0f*Mathf.Pow(CoordenadaXMotor1,3)*Xa*Mathf.Pow(LongitudEslabon2,2)-8.0f*Mathf.Pow(CoordenadaXMotor1,3)*Xa*
			                                             Mathf.Pow(LongitudEslabon1,2))));

	


	


		Yd[1]=(1.0f/2.0f)/(-8.0f*CoordenadaXMotor1*Xa-8.0f*Ya*CoordenadaYMotor1+4.0f*Mathf.Pow(Ya,2)+4.0f*Mathf.Pow(CoordenadaYMotor1,2)+4.0f*Mathf.Pow(Xa,2)+4.0f
		                   *Mathf.Pow(CoordenadaXMotor1,2))*(-4.0f*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)-4.0f*Mathf.Pow(Ya,2)*CoordenadaYMotor1+4.0f*Mathf.Pow(Ya,3)+
		                                  4.0f*Mathf.Pow(CoordenadaXMotor1,2)*CoordenadaYMotor1-4.0f*Ya*Mathf.Pow(LongitudEslabon2,2)+4.0f*Ya*Mathf.Pow(LongitudEslabon1,2)+4.0f
		                                  *Ya*Mathf.Pow(CoordenadaXMotor1,2)+4.0f*Mathf.Pow(LongitudEslabon2,2)*CoordenadaYMotor1-4.0f*Ya*Mathf.Pow(CoordenadaYMotor1,2)+4.0f
		                                  *Mathf.Pow(Xa,2)*Ya-8.0f*CoordenadaXMotor1*Xa*CoordenadaYMotor1+4.0f*Mathf.Pow(Xa,2)*CoordenadaYMotor1-8.0f*CoordenadaXMotor1*Xa*Ya+4.0f
		                                  *Mathf.Pow(CoordenadaYMotor1,3)-4.0f*(Mathf.Sqrt(-2*Mathf.Pow(Xa,4)*Mathf.Pow(CoordenadaYMotor1,2)+2.0f*CoordenadaXMotor1*Xa*Mathf.Pow(LongitudEslabon2,4)
		                                                 +2.0f*Mathf.Pow(Xa,4)*Mathf.Pow(LongitudEslabon2,2)+12.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon1,2)
		                                                 +2.0f*Mathf.Pow(Xa,4)*Mathf.Pow(LongitudEslabon1,2)-15.0f*Mathf.Pow(Xa,4)*Mathf.Pow(CoordenadaXMotor1,2)-2.0f*Mathf.Pow(Xa,4)
		                                                 *Mathf.Pow(Ya,2)+12.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon2,2)-8.0f*CoordenadaXMotor1*
		                                                 Mathf.Pow(Xa,3)*Mathf.Pow(LongitudEslabon2,2)+2.0f*CoordenadaXMotor1*Xa*Mathf.Pow(LongitudEslabon1,4)+2.0f*Mathf.Pow(Xa,2)
		                                                 *Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(LongitudEslabon2,2)
		                                                 *Mathf.Pow(LongitudEslabon1,2)-16.0f*Mathf.Pow(Xa,3)*Ya*CoordenadaXMotor1*CoordenadaYMotor1-4.0f*CoordenadaXMotor1*Xa*Mathf.Pow(LongitudEslabon2,2)
		                                                 *Mathf.Pow(LongitudEslabon1,2)+8.0f*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)*CoordenadaXMotor1*Xa*Ya-4.0f*Ya*Mathf.Pow(LongitudEslabon2,2)
		                                                 *Mathf.Pow(Xa,2)*CoordenadaYMotor1+8.0f*Ya*Mathf.Pow(LongitudEslabon2,2)*CoordenadaXMotor1*Xa*CoordenadaYMotor1-4.0f*Mathf.Pow(Ya,2)
		                                                 *Mathf.Pow(LongitudEslabon2,2)*CoordenadaXMotor1*Xa-4.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon1,2)*CoordenadaXMotor1*Xa-4.0f
		                                                 *Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(CoordenadaYMotor1,2)*CoordenadaXMotor1*Xa-8.0f*Ya*Mathf.Pow(CoordenadaYMotor1,3)
		                                                 *CoordenadaXMotor1*Xa+8.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaXMotor1,3)*Xa-Mathf.Pow(Xa,6)-Mathf.Pow(CoordenadaXMotor1,6)-4.0f
		                                                 *CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)*Ya*Mathf.Pow(CoordenadaXMotor1,2)-4.0f*CoordenadaYMotor1*Mathf.Pow(LongitudEslabon1,2)
		                                                 *Mathf.Pow(Xa,2)*Ya-4.0f*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(LongitudEslabon1,2)*CoordenadaXMotor1*Xa+12.0f*Mathf.Pow(Ya,2)
		                                                 *Mathf.Pow(CoordenadaYMotor1,2)*CoordenadaXMotor1*Xa-8.0f*Mathf.Pow(Ya,3)*CoordenadaYMotor1*CoordenadaXMotor1*Xa-4.0f*Mathf.Pow(CoordenadaXMotor1,2)
		                                                 *CoordenadaYMotor1*Ya*Mathf.Pow(LongitudEslabon2,2)+24.0f*Mathf.Pow(CoordenadaXMotor1,2)*CoordenadaYMotor1*Mathf.Pow(Xa,2)*Ya-16.0f
		                                                 *Mathf.Pow(CoordenadaXMotor1,3)*CoordenadaYMotor1*Xa*Ya-Mathf.Pow(Ya,4)*Mathf.Pow(CoordenadaXMotor1,2)-Mathf.Pow(Ya,4)*Mathf.Pow(Xa,2)
		                                                 -2.0f*Mathf.Pow(CoordenadaXMotor1,4)*Mathf.Pow(CoordenadaYMotor1,2)-Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,4)-2.0f
		                                                 *Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaXMotor1,4)-Mathf.Pow(Xa,2)*Mathf.Pow(CoordenadaYMotor1,4)+6.0f*CoordenadaXMotor1*Mathf.Pow(Xa,5)+
		                                                 6.0f*Mathf.Pow(CoordenadaXMotor1,5)*Xa+20.0f*Mathf.Pow(CoordenadaXMotor1,3)*Mathf.Pow(Xa,3)-15.0f*Mathf.Pow(CoordenadaXMotor1,4)
		                                                 *Mathf.Pow(Xa,2)-Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon2,4)-Mathf.Pow(Xa,2)*Mathf.Pow(LongitudEslabon1,4)-Mathf.Pow(CoordenadaXMotor1,2)*
		                                                 Mathf.Pow(LongitudEslabon2,4)-Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(LongitudEslabon1,4)+2.0f*Mathf.Pow(CoordenadaXMotor1,4)
		                                                 *Mathf.Pow(LongitudEslabon2,2)+2.0f*Mathf.Pow(CoordenadaXMotor1,4)*Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(CoordenadaYMotor1,2)*
		                                                 Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(CoordenadaXMotor1,2)+2.0f*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(LongitudEslabon1,2)
		                                                 *Mathf.Pow(Xa,2)-6.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(CoordenadaXMotor1,2)+4.0f*Mathf.Pow(Ya,3)
		                                                 *CoordenadaYMotor1*Mathf.Pow(CoordenadaXMotor1,2)+4.0f*Mathf.Pow(Ya,3)*CoordenadaYMotor1*Mathf.Pow(Xa,2)-6.0f*Mathf.Pow(Ya,2)
		                                                 *Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(Xa,2)+2.0f*Mathf.Pow(Ya,4)*CoordenadaXMotor1*Xa+4.0f*Mathf.Pow(CoordenadaXMotor1,4)
		                                                 *CoordenadaYMotor1*Ya+2.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(LongitudEslabon2,2)+4.0f
		                                                 *Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,3)*Ya+8.0f*Mathf.Pow(CoordenadaXMotor1,3)*Mathf.Pow(CoordenadaYMotor1,2)
		                                                 *Xa-12.0f*Mathf.Pow(CoordenadaXMotor1,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(Xa,2)+2*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon2,2)
		                                                 *Mathf.Pow(CoordenadaXMotor1,2)+2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(Xa,2)+2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon1,2)
		                                                 *Mathf.Pow(CoordenadaXMotor1,2)+2.0f*Mathf.Pow(Ya,2)*Mathf.Pow(LongitudEslabon1,2)*Mathf.Pow(Xa,2)-12.0f*Mathf.Pow(Ya,2)*Mathf.Pow(CoordenadaXMotor1,2)
		                                                 *Mathf.Pow(Xa,2)+2.0f*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(CoordenadaYMotor1,2)*Mathf.Pow(Xa,2)+4.0f*Ya*Mathf.Pow(CoordenadaYMotor1,3)
		                                                 *Mathf.Pow(Xa,2)+4.0f*Mathf.Pow(Xa,4)*Ya*CoordenadaYMotor1+8.0f*Mathf.Pow(Xa,3)*Mathf.Pow(Ya,2)*CoordenadaXMotor1+8.0f*CoordenadaXMotor1*
		                                                 Mathf.Pow(Xa,3)*Mathf.Pow(CoordenadaYMotor1,2)+2.0f*CoordenadaXMotor1*Xa*Mathf.Pow(CoordenadaYMotor1,4)-8.0f*CoordenadaXMotor1*Mathf.Pow(Xa,3)
		                                                 *Mathf.Pow(LongitudEslabon1,2)-8.0f*Mathf.Pow(CoordenadaXMotor1,3)*Xa*Mathf.Pow(LongitudEslabon2,2)-8.0f*Mathf.Pow(CoordenadaXMotor1,3)
		                                                 *Xa*Mathf.Pow(LongitudEslabon1,2))));

		/*Debug.Log ("Xd[0]: "+Xd[0].ToString());
		Debug.Log ("Xd[1]: "+Xd[1].ToString());
		Debug.Log ("Yd[0]: "+Yd[0].ToString());
		Debug.Log ("Yd[1]: "+Yd[1].ToString());*/

		float Xb=Xa+LongitudLadoTriangulo*Mathf.Cos(Phi);
		float Yb=Ya+LongitudLadoTriangulo*Mathf.Sin(Phi);

		float[] Xdb= new float[2];
		float[] Ydb= new float[2];

		Xdb[0]=(-1.0f/2.0f)*(-1.0f/(-8.0f*CoordenadaYMotor2*Yb-8.0f*Xb*CoordenadaXMotor2+4.0f*Mathf.Pow(CoordenadaYMotor2,2)+4.0f*Mathf.Pow(Yb,2)+4.0f*Mathf.Pow(CoordenadaXMotor2,2)+
		4.0f*Mathf.Pow(Xb,2))*(-8.0f*Xb*CoordenadaXMotor2*Yb+4.0f*Mathf.Pow(CoordenadaYMotor2,3)+4.0f*Mathf.Pow(Xb,2)*Yb+4.0f*Mathf.Pow(Yb,3)+4.0f*CoordenadaYMotor2*Mathf.Pow(Xb,2)+
		4.0f*Mathf.Pow(CoordenadaXMotor2,2)*CoordenadaYMotor2-8.0f*Xb*CoordenadaXMotor2*CoordenadaYMotor2+4.0f*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon2,2)+4.0f*Mathf.Pow(CoordenadaXMotor2,2)*
		Yb-4.0f*CoordenadaYMotor2*Mathf.Pow(Yb,2)+4.0f*Mathf.Pow(LongitudEslabon1,2)*Yb-4.0f*Yb*Mathf.Pow(LongitudEslabon2,2)-4.0f*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2)
		                       -4.0f*Mathf.Pow(CoordenadaYMotor2,2)*Yb+4.0f*(Mathf.Sqrt(-8.0f*Mathf.Pow(Xb,3)*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon1,2)-8.0f*Mathf.Pow(Xb,3)*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon2,2)-
		                                                         4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(LongitudEslabon1,2)+20.0f*Mathf.Pow(Xb,3)*Mathf.Pow(CoordenadaXMotor2,3)-15.0f*Mathf.Pow(Xb,2)*Mathf.Pow(CoordenadaXMotor2,4)+
		                                                         2.0f*Mathf.Pow(CoordenadaXMotor2,2)*Mathf.Pow(Yb,2)*Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(CoordenadaXMotor2,2)*Mathf.Pow(Yb,2)*Mathf.Pow(LongitudEslabon2,2)-4.0f*
		                                                         Mathf.Pow(CoordenadaXMotor2,2)*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2)*Yb-4.0f*Mathf.Pow(CoordenadaXMotor2,2)*CoordenadaYMotor2*Yb*Mathf.Pow(LongitudEslabon2,2)-
		                                                         4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(CoordenadaYMotor2,2)*Mathf.Pow(LongitudEslabon2,2)-4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(CoordenadaYMotor2,2)*Mathf.Pow(LongitudEslabon1,2)
		                                                         +2.0f*Mathf.Pow(CoordenadaYMotor2,2)*Mathf.Pow(Xb,2)*Mathf.Pow(LongitudEslabon2,2)+2.0f*Mathf.Pow(CoordenadaYMotor2,2)*Mathf.Pow(Xb,2)*Mathf.Pow(LongitudEslabon1,2)+8.0f*
		                                                         Mathf.Pow(CoordenadaXMotor2,3)*Mathf.Pow(CoordenadaYMotor2,2)*Xb+2.0f*Mathf.Pow(CoordenadaXMotor2,2)*Mathf.Pow(CoordenadaYMotor2,2)*Mathf.Pow(LongitudEslabon2,2)+4.0f*
		                                                         Mathf.Pow(CoordenadaXMotor2,4)*CoordenadaYMotor2*Yb-6.0f*Mathf.Pow(CoordenadaXMotor2,2)*Mathf.Pow(CoordenadaYMotor2,2)*Mathf.Pow(Yb,2)+2.0f*Mathf.Pow(CoordenadaXMotor2,2)*
		                                                         Mathf.Pow(CoordenadaYMotor2,2)*Mathf.Pow(LongitudEslabon1,2)-2.0f*Mathf.Pow(CoordenadaYMotor2,2)*Mathf.Pow(Xb,4)-2.0f*Mathf.Pow(CoordenadaXMotor2,4)*Mathf.Pow(CoordenadaYMotor2,2)-
		                                                         2.0f*Mathf.Pow(CoordenadaXMotor2,4)*Mathf.Pow(Yb,2)+4.0f*Mathf.Pow(Xb,2)*Mathf.Pow(Yb,3)*CoordenadaYMotor2+2.0f*Mathf.Pow(Xb,2)*Mathf.Pow(Yb,2)*Mathf.Pow(LongitudEslabon1,2)+
		                                                         2.0f*Mathf.Pow(Xb,2)*Mathf.Pow(Yb,2)*Mathf.Pow(LongitudEslabon2,2)-6.0f*Mathf.Pow(Xb,2)*Mathf.Pow(Yb,2)*Mathf.Pow(CoordenadaYMotor2,2)+4.0f*Mathf.Pow(Yb,3)*Mathf.Pow(CoordenadaXMotor2,2)*
		                                                         CoordenadaYMotor2-12.0f*Mathf.Pow(CoordenadaYMotor2,2)*Mathf.Pow(Xb,2)*Mathf.Pow(CoordenadaXMotor2,2)+8.0f*Mathf.Pow(CoordenadaYMotor2,2)*Mathf.Pow(Xb,3)*CoordenadaXMotor2-
		                                                         4.0f*Mathf.Pow(Xb,2)*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon2,2)-4.0f*Mathf.Pow(Xb,2)*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2)-2.0f*Mathf.Pow(Xb,4)*Mathf.Pow(Yb,2)-
		                                                         Mathf.Pow(Xb,2)*Mathf.Pow(Yb,4)-Mathf.Pow(Yb,4)*Mathf.Pow(CoordenadaXMotor2,2)+2.0f*Mathf.Pow(CoordenadaYMotor2,4)*Xb*CoordenadaXMotor2+4.0f*Mathf.Pow(CoordenadaYMotor2,3)*
		                                                         Mathf.Pow(CoordenadaXMotor2,2)*Yb+4.0f*Mathf.Pow(Xb,4)*Yb*CoordenadaYMotor2+24.0f*Mathf.Pow(Xb,2)*Mathf.Pow(CoordenadaXMotor2,2)*Yb*CoordenadaYMotor2-Mathf.Pow(CoordenadaYMotor2,4)*
		                                                         Mathf.Pow(CoordenadaXMotor2,2)+8.0f*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon2,2)-8.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,3)*CoordenadaYMotor2+
		                                                         8.0f*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2)-4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,2)*Mathf.Pow(LongitudEslabon1,2)-4.0f*Xb*CoordenadaXMotor2*
		                                                         Mathf.Pow(Yb,2)*Mathf.Pow(LongitudEslabon2,2)+12.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,2)*Mathf.Pow(CoordenadaYMotor2,2)-16.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3)*Yb*CoordenadaYMotor2-
		                                                         Mathf.Pow(Xb,6)-12.0f*Mathf.Pow(Xb,2)*Mathf.Pow(CoordenadaXMotor2,2)*Mathf.Pow(Yb,2)+8.0f*Mathf.Pow(Xb,3)*CoordenadaXMotor2*Mathf.Pow(Yb,2)+2.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,4)+
		                                                         8.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3)*Mathf.Pow(Yb,2)+4.0f*Mathf.Pow(CoordenadaYMotor2,3)*Mathf.Pow(Xb,2)*Yb-Mathf.Pow(CoordenadaXMotor2,6)-Mathf.Pow(CoordenadaYMotor2,4)*
		                                                         Mathf.Pow(Xb,2)-8.0f*Xb*CoordenadaXMotor2*Yb*Mathf.Pow(CoordenadaYMotor2,3)-16.0f*Mathf.Pow(Xb,3)*CoordenadaXMotor2*Yb*CoordenadaYMotor2+2.0f*Mathf.Pow(Xb,4)*Mathf.Pow(LongitudEslabon2,2)+
		                                                         2.0f*Mathf.Pow(Xb,2)*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(CoordenadaXMotor2,4)*Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(CoordenadaXMotor2,4)*
		                                                         Mathf.Pow(LongitudEslabon2,2)-Mathf.Pow(Xb,2)*Mathf.Pow(LongitudEslabon2,4)-Mathf.Pow(Xb,2)*Mathf.Pow(LongitudEslabon1,4)+2.0f*Mathf.Pow(Xb,4)*Mathf.Pow(LongitudEslabon1,2)-
		                                                         Mathf.Pow(CoordenadaXMotor2,2)*Mathf.Pow(LongitudEslabon2,4)-Mathf.Pow(CoordenadaXMotor2,2)*Mathf.Pow(LongitudEslabon1,4)+2.0f*Mathf.Pow(CoordenadaXMotor2,2)*Mathf.Pow(LongitudEslabon2,2)*
		                                                         Mathf.Pow(LongitudEslabon1,2)-15.0f*Mathf.Pow(Xb,4)*Mathf.Pow(CoordenadaXMotor2,2)+6.0f*Xb*Mathf.Pow(CoordenadaXMotor2,5)+6.0f*Mathf.Pow(Xb,5)*CoordenadaXMotor2+12.0f*Mathf.Pow(Xb,2)*
		                                                         Mathf.Pow(CoordenadaXMotor2,2)*Mathf.Pow(LongitudEslabon2,2)+12.0f*Mathf.Pow(Xb,2)*Mathf.Pow(CoordenadaXMotor2,2)*Mathf.Pow(LongitudEslabon1,2)+2.0f*Xb*CoordenadaXMotor2*
		                                                         Mathf.Pow(LongitudEslabon2,4)+2.0f*Xb*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon1,4)-8.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3)*Mathf.Pow(LongitudEslabon1,2)-8.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3)*
		                                                         Mathf.Pow(LongitudEslabon2,2))))*CoordenadaYMotor2+1.0f/(-8.0f*CoordenadaYMotor2*Yb-8.0f*Xb*CoordenadaXMotor2+4.0f*Mathf.Pow(CoordenadaYMotor2,2)+4.0f*Mathf.Pow(Yb,2)+
		4.0f*Mathf.Pow(CoordenadaXMotor2,2)+4.0f*Mathf.Pow(Xb,2))*(-8.0f*Xb*CoordenadaXMotor2*Yb+4.0f*Mathf.Pow(CoordenadaYMotor2,3)+4.0f*Mathf.Pow(Xb,2)*Yb+4.0f*Mathf.Pow(Yb,3)+
		4.0f*CoordenadaYMotor2*Mathf.Pow(Xb,2)+4.0f*Mathf.Pow(CoordenadaXMotor2,2)*CoordenadaYMotor2-8.0f*Xb*CoordenadaXMotor2*CoordenadaYMotor2+4.0f*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon2,2)+
		4.0f*Mathf.Pow(CoordenadaXMotor2,2)*Yb-4.0f*CoordenadaYMotor2*Mathf.Pow(Yb,2)+4.0f*Mathf.Pow(LongitudEslabon1,2)*Yb-4.0f*Yb*Mathf.Pow(LongitudEslabon2,2)-4.0f*CoordenadaYMotor2*
		                                                           Mathf.Pow(LongitudEslabon1,2)-4.0f*Mathf.Pow(CoordenadaYMotor2,2)*Yb+4.0f*(Mathf.Sqrt(-8.0f*Mathf.Pow(Xb,3)*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon1,2)-8.0f*Mathf.Pow(Xb,3)*CoordenadaXMotor2*
		                                                                                      Mathf.Pow(LongitudEslabon2,2)-4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(LongitudEslabon1,2)+20.0f*Mathf.Pow(Xb,3)*Mathf.Pow(CoordenadaXMotor2,3)-15.0f*
		                                                                                      Mathf.Pow(Xb,2)*Mathf.Pow(CoordenadaXMotor2,4)+2.0f*Mathf.Pow(CoordenadaXMotor2,2)*Mathf.Pow(Yb,2)*Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(CoordenadaXMotor2,2)*Mathf.Pow(Yb,2)*
		                                                                                      Mathf.Pow(LongitudEslabon2,2)-4.0f*Mathf.Pow(CoordenadaXMotor2,2)*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2)*Yb-4.0f*Mathf.Pow(CoordenadaXMotor2,2)*CoordenadaYMotor2*Yb*
		                                                                                      Mathf.Pow(LongitudEslabon2,2)-4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(CoordenadaYMotor2,2)*Mathf.Pow(LongitudEslabon2,2)-4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(CoordenadaYMotor2,2)*
		                                                                                      Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(CoordenadaYMotor2,2)*Mathf.Pow(Xb,2)*Mathf.Pow(LongitudEslabon2,2)+2.0f*Mathf.Pow(CoordenadaYMotor2,2)*Mathf.Pow(Xb,2)*Mathf.Pow(LongitudEslabon1,2)+
		                                                                                      8.0f*Mathf.Pow(CoordenadaXMotor2,3)*Mathf.Pow(CoordenadaYMotor2,2)*Xb+2.0f*Mathf.Pow(CoordenadaXMotor2,2)*Mathf.Pow(CoordenadaYMotor2,2)*Mathf.Pow(LongitudEslabon2,2)+4.0f*
		                                                                                      Mathf.Pow(CoordenadaXMotor2,4)*CoordenadaYMotor2*Yb-6.0f*Mathf.Pow(CoordenadaXMotor2,2)*Mathf.Pow(CoordenadaYMotor2,2)*Mathf.Pow(Yb,2)+2.0f*Mathf.Pow(CoordenadaXMotor2,2)*
		                                                                                      Mathf.Pow(CoordenadaYMotor2,2)*Mathf.Pow(LongitudEslabon1,2)-2.0f*Mathf.Pow(CoordenadaYMotor2,2)*Mathf.Pow(Xb,4)-2.0f*Mathf.Pow(CoordenadaXMotor2,4)*Mathf.Pow(CoordenadaYMotor2,2)-
		                                                                                      2.0f*Mathf.Pow(CoordenadaXMotor2,4)*Mathf.Pow(Yb,2)+4.0f*Mathf.Pow(Xb,2)*Mathf.Pow(Yb,3)*CoordenadaYMotor2+2.0f*Mathf.Pow(Xb,2)*Mathf.Pow(Yb,2)*Mathf.Pow(LongitudEslabon1,2)+
		                                                                                      2.0f*Mathf.Pow(Xb,2)*Mathf.Pow(Yb,2)*Mathf.Pow(LongitudEslabon2,2)-6.0f*Mathf.Pow(Xb,2)*Mathf.Pow(Yb,2)*Mathf.Pow(CoordenadaYMotor2,2)+4.0f*Mathf.Pow(Yb,3)*Mathf.Pow(CoordenadaXMotor2,2)*
		                                                                                      CoordenadaYMotor2-12.0f*Mathf.Pow(CoordenadaYMotor2,2)*Mathf.Pow(Xb,2)*Mathf.Pow(CoordenadaXMotor2,2)+8.0f*Mathf.Pow(CoordenadaYMotor2,2)*Mathf.Pow(Xb,3)*CoordenadaXMotor2-4.0f*
		                                                                                      Mathf.Pow(Xb,2)*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon2,2)-4.0f*Mathf.Pow(Xb,2)*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2)-2.0f*Mathf.Pow(Xb,4)*Mathf.Pow(Yb,2)-
		                                                                                      Mathf.Pow(Xb,2)*Mathf.Pow(Yb,4)-Mathf.Pow(Yb,4)*Mathf.Pow(CoordenadaXMotor2,2)+2.0f*Mathf.Pow(CoordenadaYMotor2,4)*Xb*CoordenadaXMotor2+4.0f*Mathf.Pow(CoordenadaYMotor2,3)*
		                                                                                      Mathf.Pow(CoordenadaXMotor2,2)*Yb+4.0f*Mathf.Pow(Xb,4)*Yb*CoordenadaYMotor2+24.0f*Mathf.Pow(Xb,2)*Mathf.Pow(CoordenadaXMotor2,2)*Yb*CoordenadaYMotor2-Mathf.Pow(CoordenadaYMotor2,4)*
		                                                                                      Mathf.Pow(CoordenadaXMotor2,2)+8.0f*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon2,2)-8.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,3)*CoordenadaYMotor2+8.0f*
		                                                                                      Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2)-4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,2)*Mathf.Pow(LongitudEslabon1,2)-4.0f*Xb*CoordenadaXMotor2*
		                                                                                      Mathf.Pow(Yb,2)*Mathf.Pow(LongitudEslabon2,2)+12.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,2)*Mathf.Pow(CoordenadaYMotor2,2)-16.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3)*Yb*CoordenadaYMotor2-
		                                                                                      Mathf.Pow(Xb,6)-12.0f*Mathf.Pow(Xb,2)*Mathf.Pow(CoordenadaXMotor2,2)*Mathf.Pow(Yb,2)+8.0f*Mathf.Pow(Xb,3)*CoordenadaXMotor2*Mathf.Pow(Yb,2)+2.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,4)+
		                                                                                      8.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3)*Mathf.Pow(Yb,2)+4.0f*Mathf.Pow(CoordenadaYMotor2,3)*Mathf.Pow(Xb,2)*Yb-Mathf.Pow(CoordenadaXMotor2,6)-Mathf.Pow(CoordenadaYMotor2,4)*
		                                                                                      Mathf.Pow(Xb,2)-8.0f*Xb*CoordenadaXMotor2*Yb*Mathf.Pow(CoordenadaYMotor2,3)-16.0f*Mathf.Pow(Xb,3)*CoordenadaXMotor2*Yb*CoordenadaYMotor2+2.0f*Mathf.Pow(Xb,4)*Mathf.Pow(LongitudEslabon2,2)+
		                                                                                      2.0f*Mathf.Pow(Xb,2)*Mathf.Pow(LongitudEslabon2,2)*Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(CoordenadaXMotor2,4)*Mathf.Pow(LongitudEslabon1,2)+2.0f*Mathf.Pow(CoordenadaXMotor2,4)*
		                                                                                      Mathf.Pow(LongitudEslabon2,2)-Mathf.Pow(Xb,2)*Mathf.Pow(LongitudEslabon2,4)-Mathf.Pow(Xb,2)*Mathf.Pow(LongitudEslabon1,4)+2.0f*Mathf.Pow(Xb,4)*Mathf.Pow(LongitudEslabon1,2)-
		                                                                                      Mathf.Pow(CoordenadaXMotor2,2)*Mathf.Pow(LongitudEslabon2,4)-Mathf.Pow(CoordenadaXMotor2,2)*Mathf.Pow(LongitudEslabon1,4)+2.0f*Mathf.Pow(CoordenadaXMotor2,2)*Mathf.Pow(LongitudEslabon2,2)*
		                                                                                      Mathf.Pow(LongitudEslabon1,2)-15.0f*Mathf.Pow(Xb,4)*Mathf.Pow(CoordenadaXMotor2,2)+6.0f*Xb*Mathf.Pow(CoordenadaXMotor2,5)+6.0f*Mathf.Pow(Xb,5)*CoordenadaXMotor2+12.0f*Mathf.Pow(Xb,2)
		                                                                                      *Mathf.Pow(CoordenadaXMotor2,2)*Mathf.Pow(LongitudEslabon2,2)+12.0f*Mathf.Pow(Xb,2)*Mathf.Pow(CoordenadaXMotor2,2)*Mathf.Pow(LongitudEslabon1,2)+2.0f*Xb*CoordenadaXMotor2*
		                                                                                      Mathf.Pow(LongitudEslabon2,4)+2.0f*Xb*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon1,4)-8.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3)*Mathf.Pow(LongitudEslabon1,2)-8.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3)*
		                                                                                      Mathf.Pow(LongitudEslabon2,2))))*Yb+Mathf.Pow(CoordenadaXMotor2,2)+Mathf.Pow(CoordenadaYMotor2,2)-Mathf.Pow(LongitudEslabon1,2)-Mathf.Pow(Xb,2)-Mathf.Pow(Yb,2)+
		Mathf.Pow(LongitudEslabon2,2))/(-CoordenadaXMotor2+Xb);

	
		Xdb[1]=-1.0f/2.0f*(-1.0f/(-8.0f*CoordenadaYMotor2*Yb-8.0f*Xb*CoordenadaXMotor2+4.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)+4.0f*Mathf.Pow(Yb,2.0f)+4.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)+
		                          4.0f*Mathf.Pow(Xb,2.0f))*(-8.0f*Xb*CoordenadaXMotor2*Yb+4.0f*Mathf.Pow(CoordenadaYMotor2,3.0f)+4.0f*Mathf.Pow(Xb,2.0f)*Yb+4.0f*Mathf.Pow(Yb,3.0f)+4.0f*CoordenadaYMotor2*Mathf.Pow(Xb,2.0f)+
		                          4.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*CoordenadaYMotor2-8.0f*Xb*CoordenadaXMotor2*CoordenadaYMotor2+4.0f*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon2,2.0f)+4.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*
		                          Yb-4.0f*CoordenadaYMotor2*Mathf.Pow(Yb,2.0f)+4.0f*Mathf.Pow(LongitudEslabon1,2.0f)*Yb-4.0f*Yb*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2.0f)-
		                          4.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)*Yb-4.0f*(Mathf.Sqrt(-8.0f*Mathf.Pow(Xb,3.0f)*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon1,2.0f)-8.0f*Mathf.Pow(Xb,3.0f)*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon2,2.0f)-
		                                                           4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+20.0f*Mathf.Pow(Xb,3.0f)*Mathf.Pow(CoordenadaXMotor2,3.0f)-15.0f*Mathf.Pow(Xb,2.0f)*
		                                                           Mathf.Pow(CoordenadaXMotor2,4.0f)+2.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(Yb,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(Yb,2.0f)*
		                                                           Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2.0f)*Yb-4.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*CoordenadaYMotor2*
		                                                           Yb*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(CoordenadaYMotor2,2.0f)*
		                                                           Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Xb,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Xb,2.0f)*
		                                                           Mathf.Pow(LongitudEslabon1,2.0f)+8.0f*Mathf.Pow(CoordenadaXMotor2,3.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)*Xb+2.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)*
		                                                           Mathf.Pow(LongitudEslabon2,2.0f)+4.0f*Mathf.Pow(CoordenadaXMotor2,4.0f)*CoordenadaYMotor2*Yb-6.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Yb,2.0f)+
		                                                           2.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-2.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Xb,4.0f)-2.0f*Mathf.Pow(CoordenadaXMotor2,4.0f)*
		                                                           Mathf.Pow(CoordenadaYMotor2,2.0f)-2.0f*Mathf.Pow(CoordenadaXMotor2,4.0f)*Mathf.Pow(Yb,2.0f)+4.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(Yb,3.0f)*CoordenadaYMotor2+2.0f*Mathf.Pow(Xb,2.0f)*
		                                                           Mathf.Pow(Yb,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(Yb,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-6.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(Yb,2.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)+
		                                                           4.0f*Mathf.Pow(Yb,3.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*CoordenadaYMotor2-12.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)+8.0f*
		                                                           Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Xb,3.0f)*CoordenadaXMotor2-4.0f*Mathf.Pow(Xb,2.0f)*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Mathf.Pow(Xb,2.0f)*Yb*
		                                                           CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2.0f)-2.0f*Mathf.Pow(Xb,4.0f)*Mathf.Pow(Yb,2.0f)-Mathf.Pow(Xb,2.0f)*Mathf.Pow(Yb,4.0f)-Mathf.Pow(Yb,4.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)+
		                                                           2.0f*Mathf.Pow(CoordenadaYMotor2,4.0f)*Xb*CoordenadaXMotor2+4.0f*Mathf.Pow(CoordenadaYMotor2,3.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*Yb+4.0f*Mathf.Pow(Xb,4.0f)*Yb*CoordenadaYMotor2+
		                                                           24.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*Yb*CoordenadaYMotor2-Mathf.Pow(CoordenadaYMotor2,4.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)+8.0f*Xb*CoordenadaXMotor2*Yb*
		                                                           CoordenadaYMotor2*Mathf.Pow(LongitudEslabon2,2.0f)-8.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,3.0f)*CoordenadaYMotor2+8.0f*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2.0f)-
		                                                           4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+12.0f*Xb*CoordenadaXMotor2*
		                                                           Mathf.Pow(Yb,2.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)-16.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3.0f)*Yb*CoordenadaYMotor2-Mathf.Pow(Xb,6.0f)-12.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*
		                                                           Mathf.Pow(Yb,2.0f)+8.0f*Mathf.Pow(Xb,3.0f)*CoordenadaXMotor2*Mathf.Pow(Yb,2.0f)+2.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,4.0f)+8.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3.0f)*Mathf.Pow(Yb,2.0f)+
		                                                           4.0f*Mathf.Pow(CoordenadaYMotor2,3.0f)*Mathf.Pow(Xb,2.0f)*Yb-Mathf.Pow(CoordenadaXMotor2,6.0f)-Mathf.Pow(CoordenadaYMotor2,4.0f)*Mathf.Pow(Xb,2.0f)-8.0f*Xb*CoordenadaXMotor2*Yb*
		                                                           Mathf.Pow(CoordenadaYMotor2,3.0f)-16.0f*Mathf.Pow(Xb,3.0f)*CoordenadaXMotor2*Yb*CoordenadaYMotor2+2.0f*Mathf.Pow(Xb,4.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*Mathf.Pow(Xb,2.0f)*
		                                                           Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(CoordenadaXMotor2,4.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(CoordenadaXMotor2,4.0f)*
		                                                           Mathf.Pow(LongitudEslabon2,2.0f)-Mathf.Pow(Xb,2.0f)*Mathf.Pow(LongitudEslabon2,4.0f)-Mathf.Pow(Xb,2.0f)*Mathf.Pow(LongitudEslabon1,4.0f)+2.0f*Mathf.Pow(Xb,4.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-
		                                                           Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(LongitudEslabon2,4.0f)-Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(LongitudEslabon1,4.0f)+2.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*
		                                                           Mathf.Pow(LongitudEslabon1,2.0f)-15.0f*Mathf.Pow(Xb,4.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)+6.0f*Xb*Mathf.Pow(CoordenadaXMotor2,5.0f)+6.0f*Mathf.Pow(Xb,5.0f)*CoordenadaXMotor2+12.0f*
		                                                           Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+12.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*
		                                                           Xb*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon2,4.0f)+2.0f*Xb*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon1,4.0f)-8.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-
		                                                           8.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3.0f)*Mathf.Pow(LongitudEslabon2,2.0f))))*CoordenadaYMotor2+1.0f/(-8.0f*CoordenadaYMotor2*Yb-8.0f*Xb*CoordenadaXMotor2+4.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)+
		                                                                                                      4.0f*Mathf.Pow(Yb,2.0f)+4.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)+4.0f*Mathf.Pow(Xb,2.0f))*(-8.0f*Xb*CoordenadaXMotor2*Yb+4.0f*Mathf.Pow(CoordenadaYMotor2,3.0f)+4.0f*Mathf.Pow(Xb,2.0f)*
		                                                                                         Yb+4.0f*Mathf.Pow(Yb,3.0f)+4.0f*CoordenadaYMotor2*Mathf.Pow(Xb,2.0f)+4.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*CoordenadaYMotor2-8.0f*Xb*CoordenadaXMotor2*CoordenadaYMotor2+4.0f*CoordenadaYMotor2*
		                                                                                         Mathf.Pow(LongitudEslabon2,2.0f)+4.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Yb-4.0f*CoordenadaYMotor2*Mathf.Pow(Yb,2.0f)+4.0f*Mathf.Pow(LongitudEslabon1,2.0f)*Yb-4.0f*Yb*Mathf.Pow(LongitudEslabon2,2.0f)
		                                                                                         -4.0f*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2.0f)-4.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)*Yb-4.0f*(Mathf.Sqrt(-8.0f*Mathf.Pow(Xb,3.0f)*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon1,2.0f)-
		                                                                                                                    8.0f*Mathf.Pow(Xb,3.0f)*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+20.0f*
		                                                                                                                    Mathf.Pow(Xb,3.0f)*Mathf.Pow(CoordenadaXMotor2,3.0f)-15.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,4.0f)+2.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(Yb,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+
		                                                                                                                    2.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(Yb,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2.0f)*
		                                                                                                                    Yb-4.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*CoordenadaYMotor2*Yb*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-
		                                                                                                                    4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Xb,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f
		                                                                                                                    *Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Xb,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+8.0f*Mathf.Pow(CoordenadaXMotor2,3.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)*Xb+2.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*
		                                                                                                                    Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+4.0f*Mathf.Pow(CoordenadaXMotor2,4.0f)*CoordenadaYMotor2*Yb-6.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)*
		                                                                                                                    Mathf.Pow(Yb,2.0f)+2.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-2.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Xb,4.0f)-2.0f*
		                                                                                                                    Mathf.Pow(CoordenadaXMotor2,4.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)-2.0f*Mathf.Pow(CoordenadaXMotor2,4.0f)*Mathf.Pow(Yb,2.0f)+4.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(Yb,3.0f)*CoordenadaYMotor2+2.0f*
		                                                                                                                    Mathf.Pow(Xb,2.0f)*Mathf.Pow(Yb,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(Yb,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-6.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(Yb,2.0f)*
		                                                                                                                    Mathf.Pow(CoordenadaYMotor2,2.0f)+4.0f*Mathf.Pow(Yb,3.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*CoordenadaYMotor2-12.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)+8.0f*
		                                                                                                                    Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Xb,3.0f)*CoordenadaXMotor2-4.0f*Mathf.Pow(Xb,2.0f)*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Mathf.Pow(Xb,2.0f)*Yb*CoordenadaYMotor2*
		                                                                                                                    Mathf.Pow(LongitudEslabon1,2.0f)-2.0f*Mathf.Pow(Xb,4.0f)*Mathf.Pow(Yb,2.0f)-Mathf.Pow(Xb,2.0f)*Mathf.Pow(Yb,4.0f)-Mathf.Pow(Yb,4.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor2,4.0f)*
		                                                                                                                    Xb*CoordenadaXMotor2+4.0f*Mathf.Pow(CoordenadaYMotor2,3.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*Yb+4.0f*Mathf.Pow(Xb,4.0f)*Yb*CoordenadaYMotor2+24.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*
		                                                                                                                    Yb*CoordenadaYMotor2-Mathf.Pow(CoordenadaYMotor2,4.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)+8.0f*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon2,2.0f)-8.0f*Xb*CoordenadaXMotor2*
		                                                                                                                    Mathf.Pow(Yb,3.0f)*CoordenadaYMotor2+8.0f*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2.0f)-4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-
		                                                                                                                    4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+12.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,2.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)-16.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3.0f)*
		                                                                                                                    Yb*CoordenadaYMotor2-Mathf.Pow(Xb,6.0f)-12.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(Yb,2.0f)+8.0f*Mathf.Pow(Xb,3.0f)*CoordenadaXMotor2*Mathf.Pow(Yb,2.0f)+2.0f*
		                                                                                                                    Xb*CoordenadaXMotor2*Mathf.Pow(Yb,4.0f)+8.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3.0f)*Mathf.Pow(Yb,2.0f)+4.0f*Mathf.Pow(CoordenadaYMotor2,3.0f)*Mathf.Pow(Xb,2.0f)*Yb-Mathf.Pow(CoordenadaXMotor2,6.0f)-
		                                                                                                                    Mathf.Pow(CoordenadaYMotor2,4.0f)*Mathf.Pow(Xb,2.0f)-8.0f*Xb*CoordenadaXMotor2*Yb*Mathf.Pow(CoordenadaYMotor2,3.0f)-16.0f*Mathf.Pow(Xb,3.0f)*CoordenadaXMotor2*Yb*CoordenadaYMotor2+2.0f*
		                                                                                                                    Mathf.Pow(Xb,4.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(CoordenadaXMotor2,4.0f)*
		                                                                                                                    Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(CoordenadaXMotor2,4.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-Mathf.Pow(Xb,2.0f)*Mathf.Pow(LongitudEslabon2,4.0f)-Mathf.Pow(Xb,2.0f)*Mathf.Pow(LongitudEslabon1,4.0f)+2.0f*
		                                                                                                                    Mathf.Pow(Xb,4.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(LongitudEslabon2,4.0f)-Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(LongitudEslabon1,4.0f)+2.0f*
		                                                                                                                    Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-15.0f*Mathf.Pow(Xb,4.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)+6.0f*Xb*Mathf.Pow(CoordenadaXMotor2,5.0f)+
		                                                                                                                    6.0f*Mathf.Pow(Xb,5.0f)*CoordenadaXMotor2+12.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+12.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*
		                                                                                                                    Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Xb*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon2,4.0f)+2.0f*Xb*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon1,4.0f)-8.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3.0f)*
		                                                                                                                    Mathf.Pow(LongitudEslabon1,2.0f)-8.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3.0f)*Mathf.Pow(LongitudEslabon2,2.0f))))*Yb+Mathf.Pow(CoordenadaXMotor2,2.0f)+Mathf.Pow(CoordenadaYMotor2,2.0f)-
		                   Mathf.Pow(LongitudEslabon1,2.0f)-Mathf.Pow(Xb,2.0f)-Mathf.Pow(Yb,2.0f)+Mathf.Pow(LongitudEslabon2,2.0f))/(-CoordenadaXMotor2+Xb);


			


		Ydb[0]=1.0f/2.0f/(-8.0f*CoordenadaYMotor2*Yb-8.0f*Xb*CoordenadaXMotor2+4.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)+4.0f*Mathf.Pow(Yb,2.0f)+4.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)+4.0f*
		                  Mathf.Pow(Xb,2.0f))*(-8.0f*Xb*CoordenadaXMotor2*Yb+4.0f*Mathf.Pow(CoordenadaYMotor2,3.0f)+4.0f*Mathf.Pow(Xb,2.0f)*Yb+4.0f*Mathf.Pow(Yb,3.0f)+4.0f*CoordenadaYMotor2*Mathf.Pow(Xb,2.0f)+
		                     4.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*CoordenadaYMotor2-8.0f*Xb*CoordenadaXMotor2*CoordenadaYMotor2+4.0f*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon2,2.0f)+4.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*
		                     Yb-4.0f*CoordenadaYMotor2*Mathf.Pow(Yb,2.0f)+4.0f*Mathf.Pow(LongitudEslabon1,2.0f)*Yb-4.0f*Yb*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2.0f)-
		                     4.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)*Yb+4.0f*(Mathf.Sqrt(-8.0f*Mathf.Pow(Xb,3.0f)*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon1,2.0f)-8.0f*Mathf.Pow(Xb,3.0f)*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon2,2.0f)-
		                                                           4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+20.0f*Mathf.Pow(Xb,3.0f)*Mathf.Pow(CoordenadaXMotor2,3.0f)-15.0f*Mathf.Pow(Xb,2.0f)*
		                                                           Mathf.Pow(CoordenadaXMotor2,4.0f)+2.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(Yb,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(Yb,2.0f)*
		                                                           Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2.0f)*Yb-4.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*CoordenadaYMotor2*
		                                                           Yb*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(CoordenadaYMotor2,2.0f)*
		                                                           Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Xb,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Xb,2.0f)*
		                                                           Mathf.Pow(LongitudEslabon1,2.0f)+8.0f*Mathf.Pow(CoordenadaXMotor2,3.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)*Xb+2.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)*
		                                                           Mathf.Pow(LongitudEslabon2,2.0f)+4.0f*Mathf.Pow(CoordenadaXMotor2,4.0f)*CoordenadaYMotor2*Yb-6.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Yb,2.0f)+2.0f*
		                                                           Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-2.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Xb,4.0f)-2.0f*Mathf.Pow(CoordenadaXMotor2,4.0f)*
		                                                           Mathf.Pow(CoordenadaYMotor2,2.0f)-2.0f*Mathf.Pow(CoordenadaXMotor2,4.0f)*Mathf.Pow(Yb,2.0f)+4.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(Yb,3.0f)*CoordenadaYMotor2+2.0f*Mathf.Pow(Xb,2.0f)*
		                                                           Mathf.Pow(Yb,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(Yb,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-6.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(Yb,2.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)+
		                                                           4.0f*Mathf.Pow(Yb,3.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*CoordenadaYMotor2-12.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)+8.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)*
		                                                           Mathf.Pow(Xb,3.0f)*CoordenadaXMotor2-4.0f*Mathf.Pow(Xb,2.0f)*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Mathf.Pow(Xb,2.0f)*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2.0f)-
		                                                           2.0f*Mathf.Pow(Xb,4.0f)*Mathf.Pow(Yb,2.0f)-Mathf.Pow(Xb,2.0f)*Mathf.Pow(Yb,4.0f)-Mathf.Pow(Yb,4.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor2,4.0f)*Xb*CoordenadaXMotor2+
		                                                           4.0f*Mathf.Pow(CoordenadaYMotor2,3.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*Yb+4.0f*Mathf.Pow(Xb,4.0f)*Yb*CoordenadaYMotor2+24.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*
		                                                           Yb*CoordenadaYMotor2-Mathf.Pow(CoordenadaYMotor2,4.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)+8.0f*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon2,2.0f)-8.0f*Xb*
		                                                           CoordenadaXMotor2*Mathf.Pow(Yb,3.0f)*CoordenadaYMotor2+8.0f*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2.0f)-4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,2.0f)*
		                                                           Mathf.Pow(LongitudEslabon1,2.0f)-4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+12.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,2.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)-
		                                                           16.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3.0f)*Yb*CoordenadaYMotor2-Mathf.Pow(Xb,6.0f)-12.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(Yb,2.0f)+8.0f*Mathf.Pow(Xb,3.0f)*
		                                                           CoordenadaXMotor2*Mathf.Pow(Yb,2.0f)+2.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,4.0f)+8.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3.0f)*Mathf.Pow(Yb,2.0f)+4.0f*Mathf.Pow(CoordenadaYMotor2,3.0f)*
		                                                           Mathf.Pow(Xb,2.0f)*Yb-Mathf.Pow(CoordenadaXMotor2,6.0f)-Mathf.Pow(CoordenadaYMotor2,4.0f)*Mathf.Pow(Xb,2.0f)-8.0f*Xb*CoordenadaXMotor2*Yb*Mathf.Pow(CoordenadaYMotor2,3.0f)-16.0f*
		                                                           Mathf.Pow(Xb,3.0f)*CoordenadaXMotor2*Yb*CoordenadaYMotor2+2.0f*Mathf.Pow(Xb,4.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+
		                                                           2.0f*Mathf.Pow(CoordenadaXMotor2,4.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(CoordenadaXMotor2,4.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-Mathf.Pow(Xb,2.0f)*Mathf.Pow(LongitudEslabon2,4.0f)-
		                                                           Mathf.Pow(Xb,2.0f)*Mathf.Pow(LongitudEslabon1,4.0f)+2.0f*Mathf.Pow(Xb,4.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(LongitudEslabon2,4.0f)-
		                                                           Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(LongitudEslabon1,4.0f)+2.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-15.0f*
		                                                           Mathf.Pow(Xb,4.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)+6.0f*Xb*Mathf.Pow(CoordenadaXMotor2,5.0f)+6.0f*Mathf.Pow(Xb,5.0f)*CoordenadaXMotor2+12.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*
		                                                           Mathf.Pow(LongitudEslabon2,2.0f)+12.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Xb*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon2,4.0f)+2.0f*
		                                                           Xb*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon1,4.0f)-8.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-8.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3.0f)*
		                                                           Mathf.Pow(LongitudEslabon2,2.0f))));

			

		Ydb[1]=1.0f/2.0f/(-8.0f*CoordenadaYMotor2*Yb-8.0f*Xb*CoordenadaXMotor2+4.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)+4.0f*Mathf.Pow(Yb,2.0f)+4.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)+4.0f*
		                  Mathf.Pow(Xb,2.0f))*(-8.0f*Xb*CoordenadaXMotor2*Yb+4.0f*Mathf.Pow(CoordenadaYMotor2,3.0f)+4.0f*Mathf.Pow(Xb,2.0f)*Yb+4.0f*Mathf.Pow(Yb,3.0f)+4.0f*CoordenadaYMotor2*Mathf.Pow(Xb,2.0f)+
		                     4.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*CoordenadaYMotor2-8.0f*Xb*CoordenadaXMotor2*CoordenadaYMotor2+4.0f*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon2,2.0f)+4.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*
		                     Yb-4.0f*CoordenadaYMotor2*Mathf.Pow(Yb,2.0f)+4.0f*Mathf.Pow(LongitudEslabon1,2.0f)*Yb-4.0f*Yb*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2.0f)-4.0f*
		                     Mathf.Pow(CoordenadaYMotor2,2.0f)*Yb-4.0f*(Mathf.Sqrt(-8.0f*Mathf.Pow(Xb,3.0f)*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon1,2.0f)-8.0f*Mathf.Pow(Xb,3.0f)*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon2,2.0f)-
		                                                      4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+20.0f*Mathf.Pow(Xb,3.0f)*Mathf.Pow(CoordenadaXMotor2,3.0f)-15.0f*Mathf.Pow(Xb,2.0f)*
		                                                      Mathf.Pow(CoordenadaXMotor2,4.0f)+2.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(Yb,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(Yb,2.0f)*
		                                                      Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2.0f)*Yb-4.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*CoordenadaYMotor2*
		                                                      Yb*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(CoordenadaYMotor2,2.0f)*
		                                                      Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Xb,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Xb,2.0f)*
		                                                      Mathf.Pow(LongitudEslabon1,2.0f)+8.0f*Mathf.Pow(CoordenadaXMotor2,3.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)*Xb+2.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)*
		                                                      Mathf.Pow(LongitudEslabon2,2.0f)+4.0f*Mathf.Pow(CoordenadaXMotor2,4.0f)*CoordenadaYMotor2*Yb-6.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Yb,2.0f)+2.0f*
		                                                      Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-2.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Xb,4.0f)-2.0f*Mathf.Pow(CoordenadaXMotor2,4.0f)*
		                                                      Mathf.Pow(CoordenadaYMotor2,2.0f)-2.0f*Mathf.Pow(CoordenadaXMotor2,4.0f)*Mathf.Pow(Yb,2.0f)+4.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(Yb,3.0f)*CoordenadaYMotor2+2.0f*Mathf.Pow(Xb,2.0f)*
		                                                      Mathf.Pow(Yb,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(Yb,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-6.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(Yb,2.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)+
		                                                      4.0f*Mathf.Pow(Yb,3.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*CoordenadaYMotor2-12.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)*Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)+8.0f*Mathf.Pow(CoordenadaYMotor2,2.0f)*
		                                                      Mathf.Pow(Xb,3.0f)*CoordenadaXMotor2-4.0f*Mathf.Pow(Xb,2.0f)*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Mathf.Pow(Xb,2.0f)*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2.0f)-
		                                                      2.0f*Mathf.Pow(Xb,4.0f)*Mathf.Pow(Yb,2.0f)-Mathf.Pow(Xb,2.0f)*Mathf.Pow(Yb,4.0f)-Mathf.Pow(Yb,4.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor2,4.0f)*Xb*CoordenadaXMotor2+
		                                                      4.0f*Mathf.Pow(CoordenadaYMotor2,3.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*Yb+4.0f*Mathf.Pow(Xb,4.0f)*Yb*CoordenadaYMotor2+24.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*
		                                                      Yb*CoordenadaYMotor2-Mathf.Pow(CoordenadaYMotor2,4.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)+8.0f*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon2,2.0f)-8.0f*Xb*CoordenadaXMotor2*
		                                                      Mathf.Pow(Yb,3.0f)*CoordenadaYMotor2+8.0f*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*Mathf.Pow(LongitudEslabon1,2.0f)-4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-
		                                                      4.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+12.0f*Xb*CoordenadaXMotor2*Mathf.Pow(Yb,2.0f)*Mathf.Pow(CoordenadaYMotor2,2.0f)-16.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3.0f)*
		                                                      Yb*CoordenadaYMotor2-Mathf.Pow(Xb,6.0f)-12.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(Yb,2.0f)+8.0f*Mathf.Pow(Xb,3.0f)*CoordenadaXMotor2*Mathf.Pow(Yb,2.0f)+2.0f*
		                                                      Xb*CoordenadaXMotor2*Mathf.Pow(Yb,4.0f)+8.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3.0f)*Mathf.Pow(Yb,2.0f)+4.0f*Mathf.Pow(CoordenadaYMotor2,3.0f)*Mathf.Pow(Xb,2.0f)*Yb-Mathf.Pow(CoordenadaXMotor2,6.0f)-
		                                                      Mathf.Pow(CoordenadaYMotor2,4.0f)*Mathf.Pow(Xb,2.0f)-8.0f*Xb*CoordenadaXMotor2*Yb*Mathf.Pow(CoordenadaYMotor2,3.0f)-16.0f*Mathf.Pow(Xb,3.0f)*CoordenadaXMotor2*Yb*CoordenadaYMotor2+2.0f*
		                                                      Mathf.Pow(Xb,4.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(CoordenadaXMotor2,4.0f)*
		                                                      Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(CoordenadaXMotor2,4.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-Mathf.Pow(Xb,2.0f)*Mathf.Pow(LongitudEslabon2,4.0f)-Mathf.Pow(Xb,2.0f)*Mathf.Pow(LongitudEslabon1,4.0f)+2.0f*
		                                                      Mathf.Pow(Xb,4.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(LongitudEslabon2,4.0f)-Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(LongitudEslabon1,4.0f)+
		                                                      2.0f*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-15.0f*Mathf.Pow(Xb,4.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)+6.0f*Xb*Mathf.Pow(CoordenadaXMotor2,5.0f)+
		                                                      6.0f*Mathf.Pow(Xb,5.0f)*CoordenadaXMotor2+12.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+12.0f*Mathf.Pow(Xb,2.0f)*Mathf.Pow(CoordenadaXMotor2,2.0f)*
		                                                      Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Xb*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon2,4.0f)+2.0f*Xb*CoordenadaXMotor2*Mathf.Pow(LongitudEslabon1,4.0f)-8.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3.0f)*
		                                                      Mathf.Pow(LongitudEslabon1,2.0f)-8.0f*Xb*Mathf.Pow(CoordenadaXMotor2,3.0f)*Mathf.Pow(LongitudEslabon2,2.0f))));

			

		/*Debug.Log ("Xdb[0]: "+Xdb[0].ToString());
		Debug.Log ("Xdb[1]: "+Xdb[1].ToString());
		Debug.Log ("Ydb[0]: "+Ydb[0].ToString());
		Debug.Log ("Ydb[1]: "+Ydb[1].ToString());*/

		float Xc=Xa+LongitudLadoTriangulo*Mathf.Cos(Phi+(Mathf.PI/3));
		float Yc=Ya+LongitudLadoTriangulo*Mathf.Sin(Phi+(Mathf.PI/3));
		
		float[] Xdc= new float[2];
		float[] Ydc= new float[2];

		Xdc[0]=-1.0f/2.0f*(1.0f/(-8.0f*Yc*CoordenadaYMotor3-8.0f*CoordenadaXMotor3*Xc+4.0f*Mathf.Pow(Yc,2.0f)+4.0f*Mathf.Pow(CoordenadaYMotor3,2.0f)+4.0f*Mathf.Pow(Xc,2.0f)+4.0f*Mathf.Pow(CoordenadaXMotor3,2.0f))*
		                   (-4.0f*Yc*Mathf.Pow(CoordenadaYMotor3,2.0f)+4.0f*Mathf.Pow(Yc,3.0f)-8.0f*CoordenadaXMotor3*Xc*CoordenadaYMotor3+4.0f*Mathf.Pow(CoordenadaYMotor3,3.0f)-4.0f*CoordenadaYMotor3*Mathf.Pow(LongitudEslabon1,2.0f)-
		 8.0f*CoordenadaXMotor3*Xc*Yc+4.0f*Yc*Mathf.Pow(CoordenadaXMotor3,2.0f)+4.0f*Yc*Mathf.Pow(LongitudEslabon1,2.0f)+4.0f*Mathf.Pow(Xc,2.0f)*Yc-4.0f*Yc*Mathf.Pow(LongitudEslabon2,2.0f)-
		 4.0f*Mathf.Pow(Yc,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(LongitudEslabon2,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(Xc,2.0f)*
		 CoordenadaYMotor3+4.0f*(Mathf.Sqrt(-6.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(Xc,2.0f)+2.0f*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*
		                                   Mathf.Pow(CoordenadaXMotor3,2.0f)+2.0f*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(Xc,2.0f)+4.0f*Yc*Mathf.Pow(CoordenadaXMotor3,4.0f)*
		                                   CoordenadaYMotor3+2.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)*Mathf.Pow(Xc,2.0f)+2.0f*Mathf.Pow(Xc,2.0f)*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+4.0f*
		                                   Mathf.Pow(Xc,4.0f)*Yc*CoordenadaYMotor3-4.0f*CoordenadaYMotor3*Mathf.Pow(LongitudEslabon1,2.0f)*Mathf.Pow(Xc,2.0f)*Yc-4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-
		                                   4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Yc*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*CoordenadaYMotor3-4.0f*
		                                   Mathf.Pow(Xc,2.0f)*Yc*Mathf.Pow(LongitudEslabon2,2.0f)*CoordenadaYMotor3+8.0f*CoordenadaXMotor3*Xc*CoordenadaYMotor3*Yc*Mathf.Pow(LongitudEslabon1,2.0f)+8.0f*CoordenadaXMotor3*Xc*
		                                   CoordenadaYMotor3*Yc*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor3,2.0f)*
		                                   Mathf.Pow(LongitudEslabon1,2.0f)*Mathf.Pow(Xc,2.0f)-12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*Mathf.Pow(Yc,2.0f)+8.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*
		                                   Mathf.Pow(Yc,2.0f)+8.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(Yc,2.0f)+2.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*
		                                   Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+24.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*CoordenadaYMotor3*Yc-16.0f*
		                                   Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*CoordenadaYMotor3*Yc-16.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*CoordenadaYMotor3*Yc-4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(CoordenadaYMotor3,2.0f)*
		                                   Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*CoordenadaYMotor3*Mathf.Pow(LongitudEslabon1,2.0f)*Yc*Mathf.Pow(CoordenadaXMotor3,2.0f)-8.0f*Yc*Mathf.Pow(CoordenadaYMotor3,3.0f)*CoordenadaXMotor3*Xc+
		                                   12.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*CoordenadaXMotor3*Xc-8.0f*Mathf.Pow(Yc,3.0f)*CoordenadaXMotor3*Xc*CoordenadaYMotor3-4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(CoordenadaYMotor3,2.0f)*
		                                   Mathf.Pow(LongitudEslabon1,2.0f)-6.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)+4.0f*Yc*Mathf.Pow(CoordenadaYMotor3,3.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)+
		                                   4.0f*Yc*Mathf.Pow(CoordenadaYMotor3,3.0f)*Mathf.Pow(Xc,2.0f)+2.0f*Mathf.Pow(Yc,4.0f)*CoordenadaXMotor3*Xc-Mathf.Pow(Xc,6.0f)-Mathf.Pow(CoordenadaXMotor3,6.0f)-Mathf.Pow(Yc,4.0f)*
		                                   Mathf.Pow(CoordenadaXMotor3,2.0f)-Mathf.Pow(Yc,4.0f)*Mathf.Pow(Xc,2.0f)-Mathf.Pow(CoordenadaYMotor3,4.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)-Mathf.Pow(CoordenadaYMotor3,4.0f)*
		                                   Mathf.Pow(Xc,2.0f)-2.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaXMotor3,4.0f)-2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(Yc,2.0f)-2.0f*Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)-
		                                   2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)+6.0f*CoordenadaXMotor3*Mathf.Pow(Xc,5.0f)+6.0f*Mathf.Pow(CoordenadaXMotor3,5.0f)*Xc+20.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*
		                                   Mathf.Pow(Xc,3.0f)-15.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,4.0f)-15.0f*Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(Xc,2.0f)-Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon2,4.0f)-
		                                   Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon1,4.0f)+2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-Mathf.Pow(CoordenadaXMotor3,2.0f)*
		                                   Mathf.Pow(LongitudEslabon2,4.0f)-Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,4.0f)+2.0f*Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*
		                                   Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+4.0f*Mathf.Pow(Yc,3.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(Yc,3.0f)*Mathf.Pow(Xc,2.0f)*
		                                   CoordenadaYMotor3-12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)+2.0f*CoordenadaXMotor3*Xc*Mathf.Pow(CoordenadaYMotor3,4.0f)+8.0f*
		                                   Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*Mathf.Pow(CoordenadaYMotor3,2.0f)+8.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)+2.0f*CoordenadaXMotor3*Xc*
		                                   Mathf.Pow(LongitudEslabon2,4.0f)+2.0f*CoordenadaXMotor3*Xc*Mathf.Pow(LongitudEslabon1,4.0f)+12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+
		                                   12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-8.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-8.0f*
		                                   CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-8.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*Mathf.Pow(LongitudEslabon2,2.0f)-8.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*
		                                   Xc*Mathf.Pow(LongitudEslabon1,2.0f)-4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*
		                                   Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f))))*Yc-1.0f/(-8.0f*Yc*CoordenadaYMotor3-
		                                                                                                                                                      8.0f*CoordenadaXMotor3*Xc+4.0f*Mathf.Pow(Yc,2.0f)+4.0f*Mathf.Pow(CoordenadaYMotor3,2.0f)+4.0f*Mathf.Pow(Xc,2.0f)+4.0f*Mathf.Pow(CoordenadaXMotor3,2.0f))*(-4.0f*Yc*Mathf.Pow(CoordenadaYMotor3,2.0f)+
		                                                                                                                                                          4.0f*Mathf.Pow(Yc,3.0f)-8.0f*CoordenadaXMotor3*Xc*CoordenadaYMotor3+4.0f*Mathf.Pow(CoordenadaYMotor3,3.0f)-4.0f*CoordenadaYMotor3*Mathf.Pow(LongitudEslabon1,2.0f)-8.0f*CoordenadaXMotor3*
		                                                                                                                                                          Xc*Yc+4.0f*Yc*Mathf.Pow(CoordenadaXMotor3,2.0f)+4.0f*Yc*Mathf.Pow(LongitudEslabon1,2.0f)+4.0f*Mathf.Pow(Xc,2.0f)*Yc-4.0f*Yc*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Mathf.Pow(Yc,2.0f)*
		                                                                                                                                                          CoordenadaYMotor3+4.0f*Mathf.Pow(LongitudEslabon2,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(Xc,2.0f)*CoordenadaYMotor3+4.0f*
		                                                                                                                                                          (Mathf.Sqrt(-6.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(Xc,2.0f)+2.0f*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)+
		            2.0f*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(Xc,2.0f)+4.0f*Yc*Mathf.Pow(CoordenadaXMotor3,4.0f)*CoordenadaYMotor3+2.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)*
		            Mathf.Pow(Xc,2.0f)+2.0f*Mathf.Pow(Xc,2.0f)*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+4.0f*Mathf.Pow(Xc,4.0f)*Yc*CoordenadaYMotor3-4.0f*CoordenadaYMotor3*Mathf.Pow(LongitudEslabon1,2.0f)*
		            Mathf.Pow(Xc,2.0f)*Yc-4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-
		            4.0f*Yc*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*CoordenadaYMotor3-4.0f*Mathf.Pow(Xc,2.0f)*Yc*Mathf.Pow(LongitudEslabon2,2.0f)*CoordenadaYMotor3+8.0f*
		            CoordenadaXMotor3*Xc*CoordenadaYMotor3*Yc*Mathf.Pow(LongitudEslabon1,2.0f)+8.0f*CoordenadaXMotor3*Xc*CoordenadaYMotor3*Yc*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor3,2.0f)*
		            Mathf.Pow(LongitudEslabon1,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)*Mathf.Pow(Xc,2.0f)-12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*
		            Mathf.Pow(Xc,2.0f)*Mathf.Pow(Yc,2.0f)+8.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*Mathf.Pow(Yc,2.0f)+8.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(Yc,2.0f)+2.0f*Mathf.Pow(Yc,2.0f)*
		            Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+24.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*
		            Mathf.Pow(Xc,2.0f)*CoordenadaYMotor3*Yc-16.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*CoordenadaYMotor3*Yc-16.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*CoordenadaYMotor3*Yc-4.0f*CoordenadaXMotor3*Xc*
		            Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*CoordenadaYMotor3*Mathf.Pow(LongitudEslabon1,2.0f)*Yc*Mathf.Pow(CoordenadaXMotor3,2.0f)-8.0f*Yc*Mathf.Pow(CoordenadaYMotor3,3.0f)*
		            CoordenadaXMotor3*Xc+12.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*CoordenadaXMotor3*Xc-8.0f*Mathf.Pow(Yc,3.0f)*CoordenadaXMotor3*Xc*CoordenadaYMotor3-4.0f*CoordenadaXMotor3*
		            Xc*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-6.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)+4.0f*Yc*Mathf.Pow(CoordenadaYMotor3,3.0f)*
		            Mathf.Pow(CoordenadaXMotor3,2.0f)+4.0f*Yc*Mathf.Pow(CoordenadaYMotor3,3.0f)*Mathf.Pow(Xc,2.0f)+2.0f*Mathf.Pow(Yc,4.0f)*CoordenadaXMotor3*Xc-Mathf.Pow(Xc,6.0f)-Mathf.Pow(CoordenadaXMotor3,6.0f)-
		            Mathf.Pow(Yc,4.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)-Mathf.Pow(Yc,4.0f)*Mathf.Pow(Xc,2.0f)-Mathf.Pow(CoordenadaYMotor3,4.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)-Mathf.Pow(CoordenadaYMotor3,4.0f)*
		            Mathf.Pow(Xc,2.0f)-2.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaXMotor3,4.0f)-2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(Yc,2.0f)-2.0f*Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)-
		            2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)+6.0f*CoordenadaXMotor3*Mathf.Pow(Xc,5.0f)+6.0f*Mathf.Pow(CoordenadaXMotor3,5.0f)*Xc+20.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*
		            Mathf.Pow(Xc,3.0f)-15.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,4.0f)-15.0f*Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(Xc,2.0f)-Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon2,4.0f)-
		            Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon1,4.0f)+2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-Mathf.Pow(CoordenadaXMotor3,2.0f)*
		            Mathf.Pow(LongitudEslabon2,4.0f)-Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,4.0f)+2.0f*Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*
		            Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+4.0f*Mathf.Pow(Yc,3.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(Yc,3.0f)*Mathf.Pow(Xc,2.0f)*
		            CoordenadaYMotor3-12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)+2.0f*CoordenadaXMotor3*Xc*Mathf.Pow(CoordenadaYMotor3,4.0f)+8.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*
		            Xc*Mathf.Pow(CoordenadaYMotor3,2.0f)+8.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)+2.0f*CoordenadaXMotor3*Xc*Mathf.Pow(LongitudEslabon2,4.0f)+2.0f*
		            CoordenadaXMotor3*Xc*Mathf.Pow(LongitudEslabon1,4.0f)+12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*
		            Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-8.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-8.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-
		            8.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*Mathf.Pow(LongitudEslabon2,2.0f)-8.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*Mathf.Pow(LongitudEslabon1,2.0f)-4.0f*CoordenadaXMotor3*Xc*
		            Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*
		            Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f))))*CoordenadaYMotor3-Mathf.Pow(Xc,2.0f)-Mathf.Pow(Yc,2.0f)+Mathf.Pow(LongitudEslabon2,2.0f)+Mathf.Pow(CoordenadaXMotor3,2.0f)+
		                   Mathf.Pow(CoordenadaYMotor3,2.0f)-Mathf.Pow(LongitudEslabon1,2.0f))/(Xc-CoordenadaXMotor3);


		Xdc[1]=-1.0f/2.0f*(1.0f/(-8.0f*Yc*CoordenadaYMotor3-8.0f*CoordenadaXMotor3*Xc+4.0f*Mathf.Pow(Yc,2.0f)+4.0f*Mathf.Pow(CoordenadaYMotor3,2.0f)+4.0f*Mathf.Pow(Xc,2.0f)+4.0f*Mathf.Pow(CoordenadaXMotor3,2.0f))*
		                   (-4.0f*Yc*Mathf.Pow(CoordenadaYMotor3,2.0f)+4.0f*Mathf.Pow(Yc,3.0f)-8.0f*CoordenadaXMotor3*Xc*CoordenadaYMotor3+4.0f*Mathf.Pow(CoordenadaYMotor3,3.0f)-4.0f*CoordenadaYMotor3*Mathf.Pow(LongitudEslabon1,2.0f)-
		 8.0f*CoordenadaXMotor3*Xc*Yc+4.0f*Yc*Mathf.Pow(CoordenadaXMotor3,2.0f)+4.0f*Yc*Mathf.Pow(LongitudEslabon1,2.0f)+4.0f*Mathf.Pow(Xc,2.0f)*Yc-4.0f*Yc*Mathf.Pow(LongitudEslabon2,2.0f)-
		 4.0f*Mathf.Pow(Yc,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(LongitudEslabon2,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(Xc,2.0f)*
		 CoordenadaYMotor3-4.0f*(Mathf.Sqrt(-6.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(Xc,2.0f)+2.0f*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*
		                                   Mathf.Pow(CoordenadaXMotor3,2.0f)+2.0f*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(Xc,2.0f)+4.0f*Yc*Mathf.Pow(CoordenadaXMotor3,4.0f)*CoordenadaYMotor3+
		                                   2.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)*Mathf.Pow(Xc,2.0f)+2.0f*Mathf.Pow(Xc,2.0f)*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+4.0f*Mathf.Pow(Xc,4.0f)*Yc*
		                                   CoordenadaYMotor3-4.0f*CoordenadaYMotor3*Mathf.Pow(LongitudEslabon1,2.0f)*Mathf.Pow(Xc,2.0f)*Yc-4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-4.0f*
		                                   CoordenadaXMotor3*Xc*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Yc*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*CoordenadaYMotor3-4.0f*Mathf.Pow(Xc,2.0f)*
		                                   Yc*Mathf.Pow(LongitudEslabon2,2.0f)*CoordenadaYMotor3+8.0f*CoordenadaXMotor3*Xc*CoordenadaYMotor3*Yc*Mathf.Pow(LongitudEslabon1,2.0f)+8.0f*CoordenadaXMotor3*Xc*CoordenadaYMotor3*
		                                   Yc*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor3,2.0f)*
		                                   Mathf.Pow(LongitudEslabon1,2.0f)*Mathf.Pow(Xc,2.0f)-12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*Mathf.Pow(Yc,2.0f)+8.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*Mathf.Pow(Yc,2.0f)+
		                                   8.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(Yc,2.0f)+2.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(Yc,2.0f)*
		                                   Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+24.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*CoordenadaYMotor3*Yc-16.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*
		                                   Xc*CoordenadaYMotor3*Yc-16.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*CoordenadaYMotor3*Yc-4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-
		                                   4.0f*CoordenadaYMotor3*Mathf.Pow(LongitudEslabon1,2.0f)*Yc*Mathf.Pow(CoordenadaXMotor3,2.0f)-8.0f*Yc*Mathf.Pow(CoordenadaYMotor3,3.0f)*CoordenadaXMotor3*Xc+12.0f*Mathf.Pow(Yc,2.0f)*
		                                   Mathf.Pow(CoordenadaYMotor3,2.0f)*CoordenadaXMotor3*Xc-8.0f*Mathf.Pow(Yc,3.0f)*CoordenadaXMotor3*Xc*CoordenadaYMotor3-4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(CoordenadaYMotor3,2.0f)*
		                                   Mathf.Pow(LongitudEslabon1,2.0f)-6.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)+4.0f*Yc*Mathf.Pow(CoordenadaYMotor3,3.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)+
		                                   4.0f*Yc*Mathf.Pow(CoordenadaYMotor3,3.0f)*Mathf.Pow(Xc,2.0f)+2.0f*Mathf.Pow(Yc,4.0f)*CoordenadaXMotor3*Xc-Mathf.Pow(Xc,6.0f)-Mathf.Pow(CoordenadaXMotor3,6.0f)-Mathf.Pow(Yc,4.0f)*
		                                   Mathf.Pow(CoordenadaXMotor3,2.0f)-Mathf.Pow(Yc,4.0f)*Mathf.Pow(Xc,2.0f)-Mathf.Pow(CoordenadaYMotor3,4.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)-Mathf.Pow(CoordenadaYMotor3,4.0f)*
		                                   Mathf.Pow(Xc,2.0f)-2.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaXMotor3,4.0f)-2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(Yc,2.0f)-2.0f*Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)-
		                                   2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)+6.0f*CoordenadaXMotor3*Mathf.Pow(Xc,5.0f)+6.0f*Mathf.Pow(CoordenadaXMotor3,5.0f)*Xc+20.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*
		                                   Mathf.Pow(Xc,3.0f)-15.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,4.0f)-15.0f*Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(Xc,2.0f)-Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon2,4.0f)-
		                                   Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon1,4.0f)+2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-Mathf.Pow(CoordenadaXMotor3,2.0f)*
		                                   Mathf.Pow(LongitudEslabon2,4.0f)-Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,4.0f)+2.0f*Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*
		                                   Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+4.0f*Mathf.Pow(Yc,3.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(Yc,3.0f)*Mathf.Pow(Xc,2.0f)*
		                                   CoordenadaYMotor3-12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)+2.0f*CoordenadaXMotor3*Xc*Mathf.Pow(CoordenadaYMotor3,4.0f)+8.0f*
		                                   Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*Mathf.Pow(CoordenadaYMotor3,2.0f)+8.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)+2.0f*CoordenadaXMotor3*Xc*
		                                   Mathf.Pow(LongitudEslabon2,4.0f)+2.0f*CoordenadaXMotor3*Xc*Mathf.Pow(LongitudEslabon1,4.0f)+12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+
		                                   12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-8.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-8.0f*
		                                   CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-8.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*Mathf.Pow(LongitudEslabon2,2.0f)-8.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*
		                                   Xc*Mathf.Pow(LongitudEslabon1,2.0f)-4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*
		                                   Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f))))*Yc-1.0f/(-8.0f*Yc*CoordenadaYMotor3-
		                                                                                                                                                      8.0f*CoordenadaXMotor3*Xc+4.0f*Mathf.Pow(Yc,2.0f)+4.0f*Mathf.Pow(CoordenadaYMotor3,2.0f)+4.0f*Mathf.Pow(Xc,2.0f)+4.0f*Mathf.Pow(CoordenadaXMotor3,2.0f))*(-4.0f*Yc*Mathf.Pow(CoordenadaYMotor3,2.0f)+
		                                                                                                                                                          4.0f*Mathf.Pow(Yc,3.0f)-8.0f*CoordenadaXMotor3*Xc*CoordenadaYMotor3+4.0f*Mathf.Pow(CoordenadaYMotor3,3.0f)-4.0f*CoordenadaYMotor3*Mathf.Pow(LongitudEslabon1,2.0f)-8.0f*
		                                                                                                                                                          CoordenadaXMotor3*Xc*Yc+4.0f*Yc*Mathf.Pow(CoordenadaXMotor3,2.0f)+4.0f*Yc*Mathf.Pow(LongitudEslabon1,2.0f)+4.0f*Mathf.Pow(Xc,2.0f)*Yc-4.0f*Yc*Mathf.Pow(LongitudEslabon2,2.0f)
		                                                                                                                                                          -4.0f*Mathf.Pow(Yc,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(LongitudEslabon2,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(Xc,2.0f)*
		                                                                                                                                                          CoordenadaYMotor3-4.0f*(Mathf.Sqrt(-6.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(Xc,2.0f)+2.0f*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*
		                                   Mathf.Pow(CoordenadaXMotor3,2.0f)+2.0f*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(Xc,2.0f)+4.0f*Yc*Mathf.Pow(CoordenadaXMotor3,4.0f)*CoordenadaYMotor3+
		                                   2.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)*Mathf.Pow(Xc,2.0f)+2.0f*Mathf.Pow(Xc,2.0f)*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+4.0f*Mathf.Pow(Xc,4.0f)*
		                                   Yc*CoordenadaYMotor3-4.0f*CoordenadaYMotor3*Mathf.Pow(LongitudEslabon1,2.0f)*Mathf.Pow(Xc,2.0f)*Yc-4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-
		                                   4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Yc*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*CoordenadaYMotor3-4.0f*
		                                   Mathf.Pow(Xc,2.0f)*Yc*Mathf.Pow(LongitudEslabon2,2.0f)*CoordenadaYMotor3+8.0f*CoordenadaXMotor3*Xc*CoordenadaYMotor3*Yc*Mathf.Pow(LongitudEslabon1,2.0f)+8.0f*CoordenadaXMotor3*
		                                   Xc*CoordenadaYMotor3*Yc*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor3,2.0f)*
		                                   Mathf.Pow(LongitudEslabon1,2.0f)*Mathf.Pow(Xc,2.0f)-12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*Mathf.Pow(Yc,2.0f)+8.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*
		                                   Mathf.Pow(Yc,2.0f)+8.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(Yc,2.0f)+2.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*
		                                   Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+24.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*CoordenadaYMotor3*Yc-16.0f*
		                                   Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*CoordenadaYMotor3*Yc-16.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*CoordenadaYMotor3*Yc-4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(CoordenadaYMotor3,2.0f)*
		                                   Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*CoordenadaYMotor3*Mathf.Pow(LongitudEslabon1,2.0f)*Yc*Mathf.Pow(CoordenadaXMotor3,2.0f)-8.0f*Yc*Mathf.Pow(CoordenadaYMotor3,3.0f)*CoordenadaXMotor3*Xc+
		                                   12.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*CoordenadaXMotor3*Xc-8.0f*Mathf.Pow(Yc,3.0f)*CoordenadaXMotor3*Xc*CoordenadaYMotor3-4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(CoordenadaYMotor3,2.0f)
		                                   *Mathf.Pow(LongitudEslabon1,2.0f)-6.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)+4.0f*Yc*Mathf.Pow(CoordenadaYMotor3,3.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)+
		                                   4.0f*Yc*Mathf.Pow(CoordenadaYMotor3,3.0f)*Mathf.Pow(Xc,2.0f)+2.0f*Mathf.Pow(Yc,4.0f)*CoordenadaXMotor3*Xc-Mathf.Pow(Xc,6.0f)-Mathf.Pow(CoordenadaXMotor3,6.0f)-Mathf.Pow(Yc,4.0f)*
		                                   Mathf.Pow(CoordenadaXMotor3,2.0f)-Mathf.Pow(Yc,4.0f)*Mathf.Pow(Xc,2.0f)-Mathf.Pow(CoordenadaYMotor3,4.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)-Mathf.Pow(CoordenadaYMotor3,4.0f)*
		                                   Mathf.Pow(Xc,2.0f)-2.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaXMotor3,4.0f)-2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(Yc,2.0f)-2.0f*Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)-
		                                   2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)+6.0f*CoordenadaXMotor3*Mathf.Pow(Xc,5.0f)+6.0f*Mathf.Pow(CoordenadaXMotor3,5.0f)*Xc+20.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*
		                                   Mathf.Pow(Xc,3.0f)-15.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,4.0f)-15.0f*Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(Xc,2.0f)-Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon2,4.0f)-
		                                   Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon1,4.0f)+2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-Mathf.Pow(CoordenadaXMotor3,2.0f)*
		                                   Mathf.Pow(LongitudEslabon2,4.0f)-Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,4.0f)+2.0f*Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*
		                                   Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+4.0f*Mathf.Pow(Yc,3.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(Yc,3.0f)*Mathf.Pow(Xc,2.0f)*
		                                   CoordenadaYMotor3-12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)+2.0f*CoordenadaXMotor3*Xc*Mathf.Pow(CoordenadaYMotor3,4.0f)+8.0f*
		                                   Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*Mathf.Pow(CoordenadaYMotor3,2.0f)+8.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)+2.0f*CoordenadaXMotor3*Xc*
		                                   Mathf.Pow(LongitudEslabon2,4.0f)+2.0f*CoordenadaXMotor3*Xc*Mathf.Pow(LongitudEslabon1,4.0f)+12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+
		                                   12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-8.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-8.0f*
		                                   CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-8.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*Mathf.Pow(LongitudEslabon2,2.0f)-8.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*
		                                   Xc*Mathf.Pow(LongitudEslabon1,2.0f)-4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*
		                                   Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f))))*CoordenadaYMotor3-
		                   Mathf.Pow(Xc,2.0f)-Mathf.Pow(Yc,2.0f)+Mathf.Pow(LongitudEslabon2,2.0f)+Mathf.Pow(CoordenadaXMotor3,2.0f)+Mathf.Pow(CoordenadaYMotor3,2.0f)-Mathf.Pow(LongitudEslabon1,2.0f))
			/(Xc-CoordenadaXMotor3);


		Ydc[0]=1.0f/2.0f/(-8.0f*Yc*CoordenadaYMotor3-8.0f*CoordenadaXMotor3*Xc+4.0f*Mathf.Pow(Yc,2.0f)+4.0f*Mathf.Pow(CoordenadaYMotor3,2.0f)+4.0f*Mathf.Pow(Xc,2.0f)+4.0f*Mathf.Pow(CoordenadaXMotor3,2.0f))*
			(-4.0f*Yc*Mathf.Pow(CoordenadaYMotor3,2.0f)+4.0f*Mathf.Pow(Yc,3.0f)-8.0f*CoordenadaXMotor3*Xc*CoordenadaYMotor3+4.0f*Mathf.Pow(CoordenadaYMotor3,3.0f)-4.0f*CoordenadaYMotor3*Mathf.Pow(LongitudEslabon1,2.0f)-
			 8.0f*CoordenadaXMotor3*Xc*Yc+4.0f*Yc*Mathf.Pow(CoordenadaXMotor3,2.0f)+4.0f*Yc*Mathf.Pow(LongitudEslabon1,2.0f)+4.0f*Mathf.Pow(Xc,2.0f)*Yc-4.0f*Yc*Mathf.Pow(LongitudEslabon2,2.0f)-
			 4.0f*Mathf.Pow(Yc,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(LongitudEslabon2,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(Xc,2.0f)*
			 CoordenadaYMotor3+4.0f*(Mathf.Sqrt(-6.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(Xc,2.0f)+2.0f*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)+
			                                   2.0f*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(Xc,2.0f)+4.0f*Yc*Mathf.Pow(CoordenadaXMotor3,4.0f)*CoordenadaYMotor3+2.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)*
			                                   Mathf.Pow(Xc,2.0f)+2.0f*Mathf.Pow(Xc,2.0f)*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+4.0f*Mathf.Pow(Xc,4.0f)*Yc*CoordenadaYMotor3-4.0f*CoordenadaYMotor3*Mathf.Pow(LongitudEslabon1,2.0f)*
			                                   Mathf.Pow(Xc,2.0f)*Yc-4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-
			                                   4.0f*Yc*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*CoordenadaYMotor3-4.0f*Mathf.Pow(Xc,2.0f)*Yc*Mathf.Pow(LongitudEslabon2,2.0f)*CoordenadaYMotor3+8.0f*CoordenadaXMotor3*
			                                   Xc*CoordenadaYMotor3*Yc*Mathf.Pow(LongitudEslabon1,2.0f)+8.0f*CoordenadaXMotor3*Xc*CoordenadaYMotor3*Yc*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor3,2.0f)*
			                                   Mathf.Pow(LongitudEslabon1,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)*Mathf.Pow(Xc,2.0f)-12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*
			                                   Mathf.Pow(Xc,2.0f)*Mathf.Pow(Yc,2.0f)+8.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*Mathf.Pow(Yc,2.0f)+8.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(Yc,2.0f)+2.0f*Mathf.Pow(Yc,2.0f)*
			                                   Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+24.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*
			                                   Mathf.Pow(Xc,2.0f)*CoordenadaYMotor3*Yc-16.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*CoordenadaYMotor3*Yc-16.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*CoordenadaYMotor3*Yc-4.0f*CoordenadaXMotor3*
			                                   Xc*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*CoordenadaYMotor3*Mathf.Pow(LongitudEslabon1,2.0f)*Yc*Mathf.Pow(CoordenadaXMotor3,2.0f)-8.0f*Yc*Mathf.Pow(CoordenadaYMotor3,3.0f)*
			                                   CoordenadaXMotor3*Xc+12.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*CoordenadaXMotor3*Xc-8.0f*Mathf.Pow(Yc,3.0f)*CoordenadaXMotor3*Xc*CoordenadaYMotor3-4.0f*CoordenadaXMotor3*
			                                   Xc*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-6.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)+4.0f*Yc*Mathf.Pow(CoordenadaYMotor3,3.0f)*
			                                   Mathf.Pow(CoordenadaXMotor3,2.0f)+4.0f*Yc*Mathf.Pow(CoordenadaYMotor3,3.0f)*Mathf.Pow(Xc,2.0f)+2.0f*Mathf.Pow(Yc,4.0f)*CoordenadaXMotor3*Xc-Mathf.Pow(Xc,6.0f)-Mathf.Pow(CoordenadaXMotor3,6.0f)-
			                                   Mathf.Pow(Yc,4.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)-Mathf.Pow(Yc,4.0f)*Mathf.Pow(Xc,2.0f)-Mathf.Pow(CoordenadaYMotor3,4.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)-Mathf.Pow(CoordenadaYMotor3,4.0f)
			                                   *Mathf.Pow(Xc,2.0f)-2.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaXMotor3,4.0f)-2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(Yc,2.0f)-2.0f*Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)-
			                                   2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)+6.0f*CoordenadaXMotor3*Mathf.Pow(Xc,5.0f)+6.0f*Mathf.Pow(CoordenadaXMotor3,5.0f)*Xc+20.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*
			                                   Mathf.Pow(Xc,3.0f)-15.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,4.0f)-15.0f*Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(Xc,2.0f)-Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon2,4.0f)-
			                                   Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon1,4.0f)+2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-Mathf.Pow(CoordenadaXMotor3,2.0f)*
			                                   Mathf.Pow(LongitudEslabon2,4.0f)-Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,4.0f)+2.0f*Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*
			                                   Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+4.0f*Mathf.Pow(Yc,3.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(Yc,3.0f)*Mathf.Pow(Xc,2.0f)*
			                                   CoordenadaYMotor3-12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)+2.0f*CoordenadaXMotor3*Xc*Mathf.Pow(CoordenadaYMotor3,4.0f)+8.0f*
			                                   Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*Mathf.Pow(CoordenadaYMotor3,2.0f)+8.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)+2.0f*CoordenadaXMotor3*Xc*
			                                   Mathf.Pow(LongitudEslabon2,4.0f)+2.0f*CoordenadaXMotor3*Xc*Mathf.Pow(LongitudEslabon1,4.0f)+12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+
			                                   12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-8.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-8.0f*
			                                   CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-8.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*Mathf.Pow(LongitudEslabon2,2.0f)-8.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*
			                                   Xc*Mathf.Pow(LongitudEslabon1,2.0f)-4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*
			                                   Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f))));

		Ydc[1]=1.0f/2.0f/(-8.0f*Yc*CoordenadaYMotor3-8.0f*CoordenadaXMotor3*Xc+4.0f*Mathf.Pow(Yc,2.0f)+4.0f*Mathf.Pow(CoordenadaYMotor3,2.0f)+4.0f*Mathf.Pow(Xc,2.0f)+4.0f*Mathf.Pow(CoordenadaXMotor3,2.0f))*
			(-4.0f*Yc*Mathf.Pow(CoordenadaYMotor3,2.0f)+4.0f*Mathf.Pow(Yc,3.0f)-8.0f*CoordenadaXMotor3*Xc*CoordenadaYMotor3+4.0f*Mathf.Pow(CoordenadaYMotor3,3.0f)-4.0f*CoordenadaYMotor3*
			 Mathf.Pow(LongitudEslabon1,2.0f)-8.0f*CoordenadaXMotor3*Xc*Yc+4.0f*Yc*Mathf.Pow(CoordenadaXMotor3,2.0f)+4.0f*Yc*Mathf.Pow(LongitudEslabon1,2.0f)+4.0f*Mathf.Pow(Xc,2.0f)*Yc-
			 4.0f*Yc*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Mathf.Pow(Yc,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(LongitudEslabon2,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*
			 CoordenadaYMotor3+4.0f*Mathf.Pow(Xc,2.0f)*CoordenadaYMotor3-4.0f*(Mathf.Sqrt(-6.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(Xc,2.0f)+2.0f*Mathf.Pow(LongitudEslabon2,2.0f)*
			                                                                             Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)+2.0f*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(Xc,2.0f)+4.0f*Yc*
			                                                                             Mathf.Pow(CoordenadaXMotor3,4.0f)*CoordenadaYMotor3+2.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)*Mathf.Pow(Xc,2.0f)+2.0f*Mathf.Pow(Xc,2.0f)*Mathf.Pow(Yc,2.0f)*
			                                                                             Mathf.Pow(LongitudEslabon2,2.0f)+4.0f*Mathf.Pow(Xc,4.0f)*Yc*CoordenadaYMotor3-4.0f*CoordenadaYMotor3*Mathf.Pow(LongitudEslabon1,2.0f)*Mathf.Pow(Xc,2.0f)*Yc-4.0f*CoordenadaXMotor3*
			                                                                             Xc*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(Yc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*Yc*Mathf.Pow(CoordenadaXMotor3,2.0f)*
			                                                                             Mathf.Pow(LongitudEslabon2,2.0f)*CoordenadaYMotor3-4.0f*Mathf.Pow(Xc,2.0f)*Yc*Mathf.Pow(LongitudEslabon2,2.0f)*CoordenadaYMotor3+8.0f*CoordenadaXMotor3*Xc*CoordenadaYMotor3*Yc*
			                                                                             Mathf.Pow(LongitudEslabon1,2.0f)+8.0f*CoordenadaXMotor3*Xc*CoordenadaYMotor3*Yc*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)*
			                                                                             Mathf.Pow(CoordenadaXMotor3,2.0f)+2.0f*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)*Mathf.Pow(Xc,2.0f)-12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*
			                                                                             Mathf.Pow(Yc,2.0f)+8.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*Mathf.Pow(Yc,2.0f)+8.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(Yc,2.0f)+2.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)*
			                                                                             Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+24.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*
			                                                                             CoordenadaYMotor3*Yc-16.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*CoordenadaYMotor3*Yc-16.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*CoordenadaYMotor3*Yc-4.0f*CoordenadaXMotor3*Xc*
			                                                                             Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-4.0f*CoordenadaYMotor3*Mathf.Pow(LongitudEslabon1,2.0f)*Yc*Mathf.Pow(CoordenadaXMotor3,2.0f)-8.0f*Yc*Mathf.Pow(CoordenadaYMotor3,3.0f)*
			                                                                             CoordenadaXMotor3*Xc+12.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*CoordenadaXMotor3*Xc-8.0f*Mathf.Pow(Yc,3.0f)*CoordenadaXMotor3*Xc*CoordenadaYMotor3-4.0f*CoordenadaXMotor3*
			                                                                             Xc*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-6.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)+4.0f*Yc*Mathf.Pow(CoordenadaYMotor3,3.0f)*
			                                                                             Mathf.Pow(CoordenadaXMotor3,2.0f)+4.0f*Yc*Mathf.Pow(CoordenadaYMotor3,3.0f)*Mathf.Pow(Xc,2.0f)+2.0f*Mathf.Pow(Yc,4.0f)*CoordenadaXMotor3*Xc-Mathf.Pow(Xc,6.0f)-Mathf.Pow(CoordenadaXMotor3,6.0f)-
			                                                                             Mathf.Pow(Yc,4.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)-Mathf.Pow(Yc,4.0f)*Mathf.Pow(Xc,2.0f)-Mathf.Pow(CoordenadaYMotor3,4.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)-Mathf.Pow(CoordenadaYMotor3,4.0f)*
			                                                                             Mathf.Pow(Xc,2.0f)-2.0f*Mathf.Pow(Yc,2.0f)*Mathf.Pow(CoordenadaXMotor3,4.0f)-2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(Yc,2.0f)-2.0f*Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)-
			                                                                             2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)+6.0f*CoordenadaXMotor3*Mathf.Pow(Xc,5.0f)+6.0f*Mathf.Pow(CoordenadaXMotor3,5.0f)*Xc+20.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*
			                                                                             Mathf.Pow(Xc,3.0f)-15.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,4.0f)-15.0f*Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(Xc,2.0f)-Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon2,4.0f)-
			                                                                             Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon1,4.0f)+2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*Mathf.Pow(Xc,4.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-Mathf.Pow(CoordenadaXMotor3,2.0f)*
			                                                                             Mathf.Pow(LongitudEslabon2,4.0f)-Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon1,4.0f)+2.0f*Mathf.Pow(CoordenadaXMotor3,4.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+2.0f*Mathf.Pow(CoordenadaXMotor3,4.0f)*
			                                                                             Mathf.Pow(LongitudEslabon1,2.0f)+4.0f*Mathf.Pow(Yc,3.0f)*Mathf.Pow(CoordenadaXMotor3,2.0f)*CoordenadaYMotor3+4.0f*Mathf.Pow(Yc,3.0f)*Mathf.Pow(Xc,2.0f)*CoordenadaYMotor3-12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*
			                                                                             Mathf.Pow(Xc,2.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)+2.0f*CoordenadaXMotor3*Xc*Mathf.Pow(CoordenadaYMotor3,4.0f)+8.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*Mathf.Pow(CoordenadaYMotor3,2.0f)+
			                                                                             8.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(CoordenadaYMotor3,2.0f)+2.0f*CoordenadaXMotor3*Xc*Mathf.Pow(LongitudEslabon2,4.0f)+2.0f*CoordenadaXMotor3*Xc*Mathf.Pow(LongitudEslabon1,4.0f)+
			                                                                             12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)+12.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-8.0f*
			                                                                             CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(LongitudEslabon2,2.0f)-8.0f*CoordenadaXMotor3*Mathf.Pow(Xc,3.0f)*Mathf.Pow(LongitudEslabon1,2.0f)-8.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*
			                                                                             Xc*Mathf.Pow(LongitudEslabon2,2.0f)-8.0f*Mathf.Pow(CoordenadaXMotor3,3.0f)*Xc*Mathf.Pow(LongitudEslabon1,2.0f)-4.0f*CoordenadaXMotor3*Xc*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+
			                                                                             2.0f*Mathf.Pow(Xc,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*Mathf.Pow(LongitudEslabon1,2.0f)+2.0f*Mathf.Pow(CoordenadaXMotor3,2.0f)*Mathf.Pow(LongitudEslabon2,2.0f)*
			                                                                             Mathf.Pow(LongitudEslabon1,2.0f))));


		/*Debug.Log ("Xdc[0]: "+Xdc[0].ToString());
		Debug.Log ("Xdc[1]: "+Xdc[1].ToString());
		Debug.Log ("Ydc[0]: "+Ydc[0].ToString());
		Debug.Log ("Ydc[1]: "+Ydc[1].ToString());*/

		bool isSingularityReached=SolveElbowUpOrDown (Xa, Xd, Yd, Xb, Xdb, Ydb, Xc, Xdc, Ydc);
		//Debug.Log("XC es= "+Xc.ToString());

		if(isSingularityReached==false){
			CalculateTheta1 (Xd, Yd);
			CalculatheAlpha1 (Xa, Ya, Xd, Yd);
			
			CalculateTheta2 (Xdb, Ydb);
			CalculateAlpha2 (Xb, Yb, Xdb, Ydb);
			
			CalculateTheta3 (Xdc, Ydc);
			CalculateAlpha3 (Xc, Yc, Xdc, Ydc);
			isStarted = true;
			transmisor=new Transmision();
			transmisor.Enviarvalores(Thetha1, Thetha2, Thetha3);
		}


	}

	private bool SolveElbowUpOrDown (float Xa, float[] Xd, float[] Yd, float Xb, float[] Xdb, float[] Ydb, float Xc, float[] Xdc, float[] Ydc)
	{
		bool isSingularityReached;
		if ((!(float.IsNaN (Xd [0]))) && (!(float.IsNaN (Yd [0]))) && (!(float.IsNaN (Xdb [0]))) && (!(float.IsNaN (Ydb [0]))) && (!(float.IsNaN (Xdc [0]))) && (!(float.IsNaN (Ydc [0]))) && (!(float.IsNaN (Xd [1]))) && (!(float.IsNaN (Yd [1]))) && (!(float.IsNaN (Xdb [1]))) && (!(float.IsNaN (Ydb [1]))) && (!(float.IsNaN (Xdc [1]))) && (!(float.IsNaN (Ydc [1])))) {

			if((CoordenadaXMotor1 > Xa) && (S1 == 0)){
				S1=0;
			}

			else if (((CoordenadaXMotor1 < Xa) && (S1 == 0))) {
				S1 = 1;
			} 

			else if((CoordenadaXMotor1 > Xa) && (S1 == 1)){
				S1=1;
			}

			else if (((CoordenadaXMotor1 < Xa) && (S1 == 1))) {
				S1 = 0;
			}



			if((CoordenadaXMotor2 > Xb) && (S2 == 0)){
				S2=0;
			}
			
			else if (((CoordenadaXMotor2 < Xb) && (S2 == 0))) {
				S2 = 1;
			} 
			
			else if((CoordenadaXMotor2 > Xb) && (S2 == 1)){
				S2=1;
			}
			
			else if (((CoordenadaXMotor2 < Xb) && (S2 == 1))) {
				S2 = 0;
			}


			if((CoordenadaXMotor3 > Xc) && (S3 == 0)){
				S3=0;
			}
			
			else if (((CoordenadaXMotor3 < Xc) && (S3 == 0))) {
				S3 = 1;
			} 
			
			else if((CoordenadaXMotor3 > Xc) && (S3 == 1)){
				S3=1;
			}
			
			else if (((CoordenadaXMotor3 < Xc) && (S3 == 1))) {
				S3 = 0;
			}



			Debug.Log ("S1: " + S1.ToString () + "S2: " + S2.ToString () + "S3: " + S3.ToString ());
			return isSingularityReached=false;
		} else {
			ErrorText.text="Ha alcanzado una singularidad. Por favor coloque otro punto.";
			return isSingularityReached=true;
		}
	}

	private void CalculateTheta1 (float[] Xd, float[] Yd){
		if (Yd [S1] >= CoordenadaYMotor1) {
			Thetha1 = (Mathf.Acos ((Xd [S1] - CoordenadaXMotor1) / LongitudEslabon1)) * 180 / (Mathf.PI);
		}
		else
			if (Yd [S1] < CoordenadaYMotor1) {
				Thetha1 = (2 * Mathf.PI - Mathf.Acos ((Xd [S1] - CoordenadaXMotor1) / LongitudEslabon1)) * 180 / (Mathf.PI);
			}
		//Debug.Log ("Thetha1= " + Thetha1.ToString ());
		Theta1Text.text = Thetha1.ToString ();
	}

	private void CalculatheAlpha1 (float Xa, float Ya, float[] Xd, float[] Yd){
		if (Ya >= Yd [S1]) {
			Alpha1 = (Mathf.Acos ((Xa - Xd [S1]) / LongitudEslabon2)) * 180 / (Mathf.PI);
		}
		else
			if (Ya < Yd [S1]) {
				Alpha1 = (2 * Mathf.PI - Mathf.Acos ((Xa - Xd [S1]) / LongitudEslabon2)) * 180 / (Mathf.PI);
			}
		//Debug.Log ("Alpha1= " + Alpha1.ToString ());
		Alpha1Text.text = Alpha1.ToString ();
	}

	void CalculateTheta2 (float[] Xdb, float[] Ydb){
		if (Ydb [S2] >= CoordenadaYMotor2) {
			Thetha2 = (Mathf.Acos ((Xdb [S2] - CoordenadaXMotor2) / LongitudEslabon1))*180/(Mathf.PI) ;
		}
		else
			if (Ydb [S2] < CoordenadaYMotor2) {
				Thetha2 = (2 * Mathf.PI - Mathf.Acos ((Xdb [S2] - CoordenadaXMotor2) / LongitudEslabon1))*180/(Mathf.PI);
			}
		//Debug.Log ("Thetha2= " + Thetha2.ToString ());
		Theta2Text.text = Thetha2.ToString ();
	}

	void CalculateAlpha2 (float Xb, float Yb, float[] Xdb, float[] Ydb){	//// YDb[1] para que quede codo abajo como en el ensamble de solid; al contrario de como viene por defecto matlab
		if (Yb >= Ydb [S2]) {
			Alpha2 = (Mathf.Acos ((Xb - Xdb [S2]) / LongitudEslabon2)) * 180 / (Mathf.PI);
		}
		else
			if (Yb < Ydb [S2]) {
				Alpha2 = (2 * Mathf.PI - Mathf.Acos ((Xb - Xdb [S2]) / LongitudEslabon2)) * 180 / (Mathf.PI);
			}
		//Debug.Log ("Alpha2= " + Alpha2.ToString ());
		Alpha2Text.text = Alpha2.ToString ();
	}

	void CalculateTheta3 (float[] Xdc, float[] Ydc)
	{
		if (Ydc [S3] >= CoordenadaYMotor3) {
			Thetha3 = (Mathf.Acos ((Xdc [S3] - CoordenadaXMotor3) / LongitudEslabon1)) * 180 / (Mathf.PI);
		}
		else
			if (Ydc [S3] < CoordenadaYMotor3) {
				Thetha3 = (2 * Mathf.PI - Mathf.Acos ((Xdc [S3] - CoordenadaXMotor3) / LongitudEslabon1)) * 180 / (Mathf.PI);
			}
		//Debug.Log ("Thetha3= " + Thetha3.ToString ());
		Theta3Text.text = Thetha3.ToString ();
	}

	void CalculateAlpha3 (float Xc, float Yc, float[] Xdc, float[] Ydc)
	{
		if (Yc >= Ydc [S3]) {
			Alpha3 = (Mathf.Acos ((Xc - Xdc [S3]) / LongitudEslabon2)) * 180 / (Mathf.PI);
		}
		else
			if (Yc < Ydc [S3]) {
				Alpha3 = (2 * Mathf.PI - Mathf.Acos ((Xc - Xdc [S3]) / LongitudEslabon2)) * 180 / (Mathf.PI);
			}
		//Debug.Log ("Alpha3= " + Alpha3.ToString ());
		Alpha3Text.text = Alpha3.ToString ();
	}
}
