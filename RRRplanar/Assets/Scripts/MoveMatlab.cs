using UnityEngine;
using System.Collections;

public class MoveMatlab : MonoBehaviour {

	private float LongitudLadoTriangulo=3.0f;
	private float Phi = Mathf.PI / 4;
	private float LongitudEslabon1=5.0f;
	private float LongitudEslabon2=4.0f;

	private float CoordenadaXMotor1 = -1.5f;
	private float CoordenadaYMotor1 = -8.4f;

	private float CoordenadaXMotor2 = 6.9f;
	private float CoordenadaYMotor2 = -1.2f;

	private float CoordenadaXMotor3 = -6.6f;
	private float CoordenadaYMotor3 = 2.1f;	
	
	private float Thetha1;
	private float Alpha1;

	private float Thetha2;
	private float Alpha2;

	private float Thetha3;
	private float Alpha3;

	// Use this for initialization
	void Start () {
		SolveEquations ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SolveEquations(){

		float CoordenadaXCentro=0.0f;
		float CoordenadaYCentro=0.0f;

		float UbicacionCentroBase  = (Mathf.Sqrt(3)/3)*LongitudLadoTriangulo;
		float Xa = CoordenadaXCentro -UbicacionCentroBase* Mathf.Cos(Phi+(Mathf.PI/6));   
		float Ya = CoordenadaYCentro -UbicacionCentroBase*Mathf.Sin(Phi+(Mathf.PI/6));   
		
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


		Debug.Log ("Xdc[0]: "+Xdc[0].ToString());


		CalculateTheta1 (Xd, Yd);
		CalculatheAlpha1 (Xa, Ya, Xd, Yd);

		CalculateTheta2 (Xdb, Ydb);
		CalculateAlpha2 (Xb, Yb, Xdb, Ydb);

	}

	private void CalculateTheta1 (float[] Xd, float[] Yd){
		if (Yd [1] >= CoordenadaYMotor1) {
			Thetha1 = (Mathf.Acos ((Xd [1] - CoordenadaXMotor1) / LongitudEslabon1)) * 180 / (Mathf.PI);
		}
		else
			if (Yd [1] < CoordenadaYMotor1) {
				Thetha1 = (2 * Mathf.PI - Mathf.Acos ((Xd [1] - CoordenadaXMotor1) / LongitudEslabon1)) * 180 / (Mathf.PI);
			}
		Debug.Log ("Thetha1= " + Thetha1.ToString ());
	}

	private void CalculatheAlpha1 (float Xa, float Ya, float[] Xd, float[] Yd){
		if (Ya >= Yd [1]) {
			Alpha1 = (Mathf.Acos ((Xa - Xd [1]) / LongitudEslabon2)) * 180 / (Mathf.PI);
		}
		else
			if (Ya < Yd [1]) {
				Alpha1 = (2 * Mathf.PI - Mathf.Acos ((Xa - Xd [1]) / LongitudEslabon2)) * 180 / (Mathf.PI);
			}
		Debug.Log ("Alpha1= " + Alpha1.ToString ());
	}

	void CalculateTheta2 (float[] Xdb, float[] Ydb){
		if (Ydb [0] >= CoordenadaYMotor2) {
			Thetha2 = (Mathf.Acos ((Xdb [0] - CoordenadaXMotor2) / LongitudEslabon1))*180/(Mathf.PI) ;
		}
		else
			if (Ydb [0] < CoordenadaYMotor2) {
				Thetha2 = (2 * Mathf.PI - Mathf.Acos ((Xdb [0] - CoordenadaXMotor2) / LongitudEslabon1))*180/(Mathf.PI);
			}
		Debug.Log ("Thetha2= " + Thetha2.ToString ());
	}

	void CalculateAlpha2 (float Xb, float Yb, float[] Xdb, float[] Ydb){
		if (Yb >= Ydb [0]) {
			Alpha2 = (Mathf.Acos ((Xb - Xdb [0]) / LongitudEslabon2)) * 180 / (Mathf.PI);
		}
		else
			if (Yb < Ydb [0]) {
				Alpha2 = (2 * Mathf.PI - Mathf.Acos ((Xb - Xdb [0]) / LongitudEslabon2)) * 180 / (Mathf.PI);
			}
		Debug.Log ("Alpha2= " + Alpha2.ToString ());
	}
}
