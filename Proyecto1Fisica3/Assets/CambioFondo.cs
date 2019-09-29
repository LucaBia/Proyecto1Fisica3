using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioFondo : MonoBehaviour
{

    public Camera cam;
    public Dropdown funciones;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (funciones.value)
        {
           
            case 1:  //Constante
                cam.backgroundColor = Color.red;
                break;
            case 2: //Lineal
                cam.backgroundColor = Color.blue;
                break;
            case 3: //Cuadratica
                cam.backgroundColor = Color.green;
                break;
            case 4: //Cubica
                cam.backgroundColor = Color.red;
                break;
            case 5: //Exponencial
                cam.backgroundColor = Color.red;
                break;

        }
    }
}
