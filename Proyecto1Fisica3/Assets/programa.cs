// 01000001 01110101 01110100 01101111 01110010 01100101 01110011 00111010
// 01000001 01101110 01100100 01111001 00100000 01000011 01100001 01110011 01110100 01101001 01101100 01101100 01101111 00100000 00110001 00111000 00110000 00110100 00110000
// 01001100 01110101 01100011 01100001 00100000 01010010 01101001 01110110 01100101 01110010 01100001 00100000 00110001 00111000 00110000 00110100 00111001
// 01001101 01100001 01110010 01100011 01101111 00100000 01000110 01110101 01100101 01101110 01110100 01100101 01110011 00100000 00110001 00111000 00111000 00111000 00111000
// 01000110 01110010 01100001 01101110 01100011 01101001 01110011 01100011 01101111 00100000 01010010 01101111 01110011 01100001 01101100 00100000 00110001 00111000 00110110 00110111 00110110

// 01110000 01110101 01110100 01101111 00100000 01100101 01101100 00100000 01110001 01110101 01100101 00100000 01101100 01101111 00100000 01100100 01100101 01110011 01100011 01110101 01100010 01110010 01100001
// 01110000 01110101 01110100 01100001 00100000 01100110 01101001 01110011 01101001 01100011 01100001

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class programa : MonoBehaviour {
	public Camera cam;
	public Dropdown funciones;
	public InputField cargaInput;
	public InputField velocidadInicialInput;
	public InputField masaInput;
	public Rigidbody particula;
	public InputField coeficienteA;
	public InputField coeficienteB;
	public InputField coeficienteC;
	private double energiaCinetica = 0;
	private double energiaPotencial = 0;
	private double energia = 0;
	private double a;
	private double b;
	private double c;
	private double carga;
	private double velocidadInicial;
	private double velocidadInst;
	private double masa;
	private bool yaInicio  = false;

	// Start is called before the first frame update
	void Start() {
		Debug.Log("01110000 01110101 01110100 01100001 00100000 01100110 01101001 01110011 01101001 01100011 01100001");
	}

	// Update is called once per frame
	void Update() {
		if (yaInicio) {
			float adentro = (float)energia - (float)VPotencial();
			if (adentro > 0) {
				if (particula.velocity.x > 0) {
					particula.velocity = new Vector3(Mathf.Sqrt((adentro)*2/(float)masa),0,0);
				} else {
					particula.velocity = new Vector3(-Mathf.Sqrt((adentro)*2/(float)masa),0,0);
				}
			} else {
				adentro = -(float)energia + (float)VPotencial();
				if(particula.velocity.x > 0) {
					particula.velocity = new Vector3(-Mathf.Sqrt((adentro)*2/(float)masa),0,0);
				} else {
					particula.velocity = new Vector3(Mathf.Sqrt((adentro)*2/(float)masa),0,0);
				}
			}
		}
	}

	public void iniciarSimulacion() {
		particula.position = new Vector3(0,0.25f,0);
		yaInicio = true;
		a = double.Parse(coeficienteA.text);
		b = double.Parse(coeficienteB.text);
		c = double.Parse(coeficienteC.text);
		carga = double.Parse(cargaInput.text);
		particula.velocity= new Vector3(float.Parse(velocidadInicialInput.text),0,0);
		velocidadInicial = double.Parse(velocidadInicialInput.text);
		masa = double.Parse(masaInput.text);
		particula.mass = (float)masa;
		energiaCinetica = (0.5 * masa * (Math.Pow(velocidadInicial,2)));
		energiaPotencial = VPotencial();
		energia = energiaCinetica + energiaPotencial;
		Debug.Log("Energia Total de tu mama: " + energia);
	}

	private double VPotencial() {
		double x = particula.GetComponent<Rigidbody>().position.x;
		switch (funciones.value) {
			case 0: // Constante
				return energiaPotencial = carga * potencialConstante(a,b,c,x);
			case 1: // Lineal
				return energiaPotencial = carga * potencialLineal(a,b,c,x);
			case 2: // Cuadratica
				return energiaPotencial = carga * potencialCuadratica(a,b,c,x);
			case 3: // Exponencial
				return energiaPotencial = carga * potencialExponencial(a,b,c,x);
			case 4: // Ln
				return energiaPotencial = carga * potencialLn(a,b,c,x);
			case 5: // Absoluto
				return energiaPotencial = carga * potencialAbsoluto(a,b,c,x);
			case 6: // Log
				return energiaPotencial = carga * potencialLog(a,b,c,x);
			case 7: // Raiz
				return energiaPotencial = carga * potencialRaiz(a,b,c,x);
			default:
				return 0;
		}
	}

	private double potencialConstante(double a, double b, double c, double x) {
		double potencial = a;
		return potencial;
	}

	private double potencialLineal(double a, double b, double c, double x) {
		double potencial = a*x+b;
		return potencial;
	}

	private double potencialCuadratica(double a, double b, double c, double x) {
		double potencial = a*(Math.Pow(x,2))+b*x+c;
		return potencial;
	}

	private double potencialExponencial(double a, double b, double c, double x) {
		double potencial = Math.Exp(a*x+b)+c;
		return potencial;
	}

	private double potencialLn(double a, double b, double c, double x) {
		double potencial = Math.Log(a*x+b)+c;
		return potencial;
	}

	private double potencialAbsoluto(double a, double b, double c, double x) {
		double potencial = Math.Abs(a*x+b)+c;
		return potencial;
	}

	private double potencialLog(double a, double b, double c, double x) {
		double potencial = Math.Log(b*x+c, a);
		return potencial;
	}

	private double potencialRaiz(double a, double b, double c, double x) {
		double potencial = Math.Sqrt(a*x+b)+c;
		return potencial;
	}
}
