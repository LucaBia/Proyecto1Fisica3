using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class programa : MonoBehaviour
{
	public Camera cam;
	public Dropdown funciones;
	public InputField cargaInput;
	public InputField velocidadInicialInput;
	public InputField masaInput;
	private double energia = 0;
	public Rigidbody particula;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		switch (funciones.value) {
			case 0:  //Constante
				cam.backgroundColor = Color.red;
				break;
			case 1: //Lineal
				cam.backgroundColor = Color.blue;
				break;
			case 2: //Cuadratica
				cam.backgroundColor = Color.green;
				break;
			case 3: //Exponencial
				cam.backgroundColor = Color.black;
				break;
		}
	}

	public void iniciarSimulacion() {
		double carga = double.Parse(cargaInput.text);
		double velocidadInicial = double.Parse(velocidadInicialInput.text);
		double masa = double.Parse(masaInput.text);
		particula.mass = (float)masa;
		energia = (0.5 * masa * (Math.Pow(velocidadInicial,2)));
		Debug.Log("Energia Total: " + energia);
	}
}
