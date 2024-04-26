using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Controlador : MonoBehaviour
{
    [Header("Tipos de Variables:")]
    [Header("")]
    public string[] Nombre;
    
    public string[] NombreAlternativos;
    public GameObject[] GO;
    public int cocheseleccionado;
    [Range(0, 15)]
    public int[] distanciamax;
    public bool[] Activo;
    public enum Motor { Diesel, Gasolina, Electrico };
    public Motor[] Motores;
    [Range(0, 7)]
    public int[] Velocidad;
    public TextMeshProUGUI textNombre;
    private bool PulsarE;
   

    // Start is called before the first frame update
    void Start()
    {
        Activo[0] = false; Activo[1]=false; Activo[2]=false; Activo[3]=false; Activo[4]=false;
    }

    // Update is called once per frame
    void Update()
    {
        Colores();
        Teclas();
        CocheSeleccionado();
        Movimiento();
        Rotacion();
    }

    //Asigna un color dependiendo de si el coche esta activado o desactivado.
    void Colores()
    {
        // Si el coche esta desactivado se convierte en color rojo.
        if (Activo[0] == false)
        {
            GO[0].GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (Activo[1] == false)
        {
            GO[1].GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (Activo[2] == false)
        {
            GO[2].GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (Activo[3] == false)
        {
            GO[3].GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (Activo[4] == false)
        {
            GO[4].GetComponent<SpriteRenderer>().color = Color.red;
        }

        // Si el coche esta activado se convierte en color rojo.
        if (Activo[0] == true)
        {
            GO[0].GetComponent<SpriteRenderer>().color = Color.blue;
        }
        if (Activo[1] == true)
        {
            GO[1].GetComponent<SpriteRenderer>().color = Color.blue;
        }
        if (Activo[2] == true)
        {
            GO[2].GetComponent<SpriteRenderer>().color = Color.blue;
        }
        if (Activo[3] == true)
        {
            GO[3].GetComponent<SpriteRenderer>().color = Color.blue;
        }
        if (Activo[4] == true)
        {
            GO[4].GetComponent<SpriteRenderer>().color = Color.blue;
        }

        // Si la distacia maxima es 0 se convierte en color gris.
        if (distanciamax[0] == 0)
        {
            GO[0].GetComponent<SpriteRenderer>().color = Color.grey;
        }
        if (distanciamax[1] == 0)
        {
            GO[1].GetComponent<SpriteRenderer>().color = Color.grey;
        }
        if (distanciamax[2] == 0)
        {
            GO[2].GetComponent<SpriteRenderer>().color = Color.grey;
        }
        if (distanciamax[3] == 0)
        {
            GO[3].GetComponent<SpriteRenderer>().color = Color.grey;
        }
        if (distanciamax[4] == 0)
        {
            GO[4].GetComponent<SpriteRenderer>().color = Color.grey;
        }

        // Si la distacia maxima es 0 se convierte en color gris.
        if (Velocidad[0] == 0)
        {
            GO[0].GetComponent<SpriteRenderer>().color = Color.grey;
        }
        if (Velocidad[1] == 0)
        {
            GO[1].GetComponent<SpriteRenderer>().color = Color.grey;
        }
        if (Velocidad[2] == 0)
        {
            GO[2].GetComponent<SpriteRenderer>().color = Color.grey;
        }
        if (Velocidad[3] == 0)
        {
            GO[3].GetComponent<SpriteRenderer>().color = Color.grey;
        }
        if (Velocidad[4] == 0)
        {
            GO[4].GetComponent<SpriteRenderer>().color = Color.grey;
        }
    }

    //Asigna valores y genera acciones dependiendo de la tecla que pulse el usuario.
    void Teclas()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (cocheseleccionado == 1)
            {
                cocheseleccionado = 0;
            }
            else if (cocheseleccionado != 1)
            {
                cocheseleccionado = 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (cocheseleccionado == 2)
            {
                cocheseleccionado = 0;
            }
            else if (cocheseleccionado != 2)
            {
                cocheseleccionado = 2;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (cocheseleccionado == 3)
            {
                cocheseleccionado = 0;

            }
            else if (cocheseleccionado != 3)
            {
                cocheseleccionado = 3;

            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (cocheseleccionado == 4)
            {
                cocheseleccionado = 0;
            }
            else if (cocheseleccionado != 4)
            {
                cocheseleccionado = 4;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (cocheseleccionado == 5)
            {
                cocheseleccionado = 0;
            }
            else if (cocheseleccionado != 5)
            {
                cocheseleccionado = 5;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            cocheseleccionado = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            cocheseleccionado = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            cocheseleccionado = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            cocheseleccionado = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            cocheseleccionado = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Activo[0] = true;
            Activo[1] = true;
            Activo[2] = true;
            Activo[3] = true;
            Activo[4] = true;
            textNombre.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (!PulsarE)
            {
                PulsarE = true;
            }
            else if (PulsarE)
            {
                PulsarE = false;
                for (int i = 0; i < GO.Length; i++)
                {
                    GO[i].transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.R)) 
        {    
            cocheseleccionado = 0;
            textNombre.gameObject.SetActive(true);
            CocheSeleccionado();

            Activo[0] = false;
            Activo[1] = false;
            Activo[2] = false;
            Activo[3] = false;
            Activo[4] = false;

            for (int i = 0; i < GO.Length; i++)
            {
                float posY = GO[i].transform.position.y;
                float posZ = GO[i].transform.position.z;
                transform.position = new Vector3(0, posY, posZ);
                GO[i].transform.position = transform.position;
            }

            Nombre[0] = NombreAlternativos[Random.Range(0, NombreAlternativos.Length)];
            Nombre[1] = NombreAlternativos[Random.Range(0, NombreAlternativos.Length)];
            Nombre[2] = NombreAlternativos[Random.Range(0, NombreAlternativos.Length)];
            Nombre[3] = NombreAlternativos[Random.Range(0, NombreAlternativos.Length)];
            Nombre[4] = NombreAlternativos[Random.Range(0, NombreAlternativos.Length)];

            Velocidad[0] = Random.Range(0, 8);
            Velocidad[1] = Random.Range(0, 8);
            Velocidad[2] = Random.Range(0, 8);
            Velocidad[3] = Random.Range(0, 8);
            Velocidad[4] = Random.Range(0, 8);

            distanciamax[0] = Random.Range(0, 15);
            distanciamax[1] = Random.Range(0, 15);
            distanciamax[2] = Random.Range(0, 15);
            distanciamax[3] = Random.Range(0, 15);
            distanciamax[4] = Random.Range(0, 15);

        }
        else if (!Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
   
    //Dependiendo del coche que este seleccionado se generaran una serie de acciones como cambiar el texto y cambiar el color.
    void CocheSeleccionado()
    {
        if (cocheseleccionado == 0)
        {
            textNombre.text = "Nombre: " + "\n" + "\n" + "\n" + "Velocidad: " + "\n" + "\n" + "\n" + "Distancia Max: " + "\n" + "\n" + "\n" + "Activo: " + "\n" + "\n" + "\n" + "Motor: ";
        }
        if (cocheseleccionado == 1)
        {
            GO[0].GetComponent<SpriteRenderer>().color = Color.green;
            textNombre.text = "Nombre: " + Nombre[0] + "\n" + "\n" + "\n" + "Velocidad: " + Velocidad[0] + "\n" + "\n" + "\n" + "Distancia Max: " + distanciamax[0] + "\n" + "\n" + "\n" + "Activo: " + Activo[0] + "\n" + "\n" + "\n" + "Motor: " + Motores[0];
            if (Input.GetKeyDown(KeyCode.W))
            {
                Activo[0] = true;
                textNombre.gameObject.SetActive(false);
            }
        }
        if (cocheseleccionado == 2)
        {
            GO[1].GetComponent<SpriteRenderer>().color = Color.green;
            textNombre.text = "Nombre: " + Nombre[1] + "\n" + "\n" + "\n" + "Velocidad: " + Velocidad[1] + "\n" + "\n" + "\n" + "Distancia Max: " + distanciamax[1] + "\n" + "\n" + "\n" + "Activo: " + Activo[1] + "\n" + "\n" + "\n" + "Motor: " + Motores[1];
            if (Input.GetKeyDown(KeyCode.W))
            {
                Activo[1] = true;
                textNombre.gameObject.SetActive(false);
            }
        }
        if (cocheseleccionado == 3)
        {
            GO[2].GetComponent<SpriteRenderer>().color = Color.green;
            textNombre.text = "Nombre: " + Nombre[2] + "\n" + "\n" + "\n" + "Velocidad: " + Velocidad[2] + "\n" + "\n" + "\n" + "Distancia Max: " + distanciamax[2] + "\n" + "\n" + "\n" + "Activo: " + Activo[2] + "\n" + "\n" + "\n" + "Motor: " + Motores[2];
            if (Input.GetKeyDown(KeyCode.W))
            {
                Activo[2] = true;
                textNombre.gameObject.SetActive(false);
            }
        }
        if (cocheseleccionado == 4)
        {
            GO[3].GetComponent<SpriteRenderer>().color = Color.green;
            textNombre.text = "Nombre: " + Nombre[3] + "\n" + "\n" + "\n" + "Velocidad: " + Velocidad[3] + "\n" + "\n" + "\n" + "Distancia Max: " + distanciamax[3] + "\n" + "\n" + "\n" + "Activo: " + Activo[3] + "\n" + "\n" + "\n" + "Motor: " + Motores[3];
            if (Input.GetKeyDown(KeyCode.W))
            {
                Activo[3] = true;
                textNombre.gameObject.SetActive(false);
            }
        }
        if (cocheseleccionado == 5)
        {
            GO[4].GetComponent<SpriteRenderer>().color = Color.green;
            textNombre.text = "Nombre: " + Nombre[4] + "\n" + "\n" + "\n" + "Velocidad: " + Velocidad[4] + "\n" + "\n" + "\n" + "Distancia Max: " + distanciamax[4] + "\n" + "\n" + "\n" + "Activo: " + Activo[4] + "\n" + "\n" + "\n" + "Motor: " + Motores[4];
            if (Input.GetKeyDown(KeyCode.W))
            {
                Activo[4] = true;
                textNombre.gameObject.SetActive(false);
            }
        }
    }

    //Genera movimiento en los diferentes coches.
    void Movimiento(){
        if (Activo[0] == true && GO[0].transform.position.x <= distanciamax[0])
        {
            GO[0].transform.Translate(new Vector3(0.0025f * Velocidad[0], 0, 0), Space.World);
        }
        if (Activo[1] == true && GO[1].transform.position.x <= distanciamax[1])
        {
            GO[1].transform.Translate(new Vector3(0.0025f * Velocidad[1], 0, 0), Space.World);
        }
        if (Activo[2] == true && GO[2].transform.position.x <= distanciamax[2])
        {
            GO[2].transform.Translate(new Vector3(0.0025f * Velocidad[2], 0, 0), Space.World);
        }
        if (Activo[3] == true && GO[3].transform.position.x <= distanciamax[3])
        {
            GO[3].transform.Translate(new Vector3(0.0025f * Velocidad[3], 0, 0), Space.World);
        }
        if (Activo[4] == true && GO[4].transform.position.x <= distanciamax[4])
        {
            GO[4].transform.Translate(new Vector3(0.0025f * Velocidad[4], 0, 0), Space.World);
        }
    }

    //Genera rotaci�n en los diferentes coches.
    void Rotacion()
    {
        if (PulsarE)
        {
            for (int i = 0; i < GO.Length; i++)
            {
                if (Motores[i] == Motor.Electrico)
                {
                    GO[i].transform.Rotate(new Vector3(0, 0, 1));
                }
            }
        }
    }
}