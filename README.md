 <h1 align="justify">Desarrollo de Interfaz para Manipulación de Coches en Unity</h1>
  
  <h2 align="justify">Introducción</h2>
  <p align="justify">El presente informe detalla el desarrollo de una interfaz en Unity para la manipulación de coches dentro de un entorno de juego. El objetivo principal es permitir al usuario controlar diversas acciones, como movimiento, rotación y cambio de color, en cinco vehículos diferentes a través de la interacción con teclas específicas.</p>

&nbsp; 


  <h2 align="justify">Desarrollo del Script</h2>
  
  <h3 align="justify">Definición de Variables y Asignación de Sprites</h3>
  <p align="justify">Se han definido las siguientes variables para cada uno de los cinco vehículos:</p>
  <ul align="justify">
    <li align="justify">Nombre</li>
    <li align="justify">Velocidad</li>
    <li align="justify">Distancia máxima</li>
    <li align="justify">Activo</li>
    <li align="justify">Motor</li>
    <li align="justify">GameObject</li>
  </ul>
  
  <p align="justify">Además, se han creado sprites para representar visualmente cada uno de los coches, los cuales han sido asignados a los correspondientes GameObjects.</p>

```sh
// Definición de variables para cada vehículo
public string[] Nombre;
public int[] Velocidad;
public int[] DistanciaMaxima;
public bool[] Activo;
public Motor[] Motores;
public GameObject[] GO;

// Asignación de sprites a los GameObjects correspondientes
GO[0].GetComponent<SpriteRenderer>().sprite = spriteCoche1;
GO[1].GetComponent<SpriteRenderer>().sprite = spriteCoche2;
// Resto de asignaciones...
```

&nbsp; 

  <h3 align="justify">Selección y Color del Coche</h3>
  <p align="justify">Se ha creado una variable numérica llamada "CocheSeleccionado" que puede modificarse en el inspector. Al cambiar esta variable, el coche correspondiente a ese número cambia de color a verde. Cuando la variable está en 0, ningún coche está seleccionado y ninguno se muestra en verde.</p>
  
```sh
// Creación de una variable numérica para seleccionar el coche
public int CocheSeleccionado;

// Cambio de color del coche seleccionado
if (CocheSeleccionado == 1)
{
    GO[0].GetComponent<SpriteRenderer>().color = Color.green;
}
```
&nbsp; 

  <h3 align="justify">Cambio de Color según Estado y Valores</h3>
  <p align="justify">Los coches activos se muestran en color azul, los inactivos en rojo y aquellos con velocidad o distancia máxima igual a 0 en gris. El coche seleccionado permanece en verde independientemente de su estado de activación.</p>

```sh
// Cambio de color según estado y valores
if (Activo[0])
{
    GO[0].GetComponent<SpriteRenderer>().color = Color.blue;
}
else
{
    GO[0].GetComponent<SpriteRenderer>().color = Color.red;
}
```
&nbsp; 

  <h3 align="justify">Selección de Coche mediante Teclas Numéricas</h3>
  <p align="justify">Presionando las teclas numéricas del 1 al 5, se cambia la variable "CocheSeleccionado" al número correspondiente, lo que hace que el coche respectivo se muestre en verde.</p>

```sh
// Selección de coche mediante teclas numéricas
if (Input.GetKeyDown(KeyCode.Alpha1))
{
    CocheSeleccionado = 1;
}
```
&nbsp; 

  <h3 align="justify">Visualización de Información del Coche Seleccionado</h3>
  <p align="justify">Se han creado textos en la escena que muestran los valores del coche seleccionado, incluyendo nombre, velocidad, distancia máxima, estado de funcionamiento y tipo de motor. Si no hay coche seleccionado, estos textos muestran los nombres de las variables correspondientes.</p>

```sh
// Visualización de información del coche seleccionado
textNombre.text = "Nombre: " + Nombre[CocheSeleccionado - 1] + "\n" +
                  "Velocidad: " + Velocidad[CocheSeleccionado - 1] + "\n" +
                  "Distancia Máxima: " + DistanciaMaxima[CocheSeleccionado - 1] + "\n" +
                  "Activo: " + Activo[CocheSeleccionado - 1] + "\n" +
                  "Motor: " + Motores[CocheSeleccionado - 1];
```
![1 seleccion coches](https://github.com/valen28030/Cars/assets/167770750/dc938555-24fe-47e3-b483-348489e4e1dd)

&nbsp; 

  <h3 align="justify">Deselección de Coche</h3>
  <p align="justify">Al presionar la tecla correspondiente a un coche ya seleccionado, se deselecciona dicho coche y devuelve la variable "CocheSeleccionado" a 0.</p>

```sh
// Deselección de coche
if (Input.GetKeyDown(KeyCode.Alpha1) && CocheSeleccionado == 1)
{
    CocheSeleccionado = 0;
}
```
&nbsp; 

  <h3 align="justify">Movimiento de Coches Activos</h3>
  <p align="justify">Los coches activos se mueven en línea recta según su velocidad hasta alcanzar su distancia máxima.</p>

```sh
// Movimiento de coches activos
if (Activo[0] && GO[0].transform.position.x <= DistanciaMaxima[0])
{
    GO[0].transform.Translate(new Vector3(0.0025f * Velocidad[0], 0, 0), Space.World);
}
```
&nbsp; 

  <h3 align="justify">Activación Masiva de Coches</h3>
  <p align="justify">Al presionar la tecla "Q", se activan todos los coches que tienen tanto velocidad como distancia máxima distintas de cero, permitiéndoles moverse hasta su distancia máxima.</p>

```sh
// Activación masiva de coches
if (Input.GetKeyDown(KeyCode.Q))
{
    for (int i = 0; i < Activo.Length; i++)
    {
        if (Velocidad[i] != 0 && DistanciaMaxima[i] != 0)
        {
            Activo[i] = true;
        }
    }
}
```
![2 pulsarQ](https://github.com/valen28030/Cars/assets/167770750/e0a9d8d2-433f-4292-a838-20a9d70e0323)

&nbsp; 

  <h3 align="justify">Activación Individual del Coche Seleccionado</h3>
  <p align="justify">Al presionar la tecla "W", se activa únicamente el coche seleccionado, obligándolo a moverse hasta su distancia máxima normalmente.</p>

```sh
// Activación individual del coche seleccionado
if (Input.GetKeyDown(KeyCode.W))
{
    Activo[CocheSeleccionado - 1] = true;
    textNombre.gameObject.SetActive(false);
}
```
![3 pulsarW](https://github.com/valen28030/Cars/assets/167770750/31e98475-04ce-4e24-8cc6-52b718fdab36)

&nbsp; 

   <h3 align="justify">Rotación de Coches Eléctricos</h3>
  <p align="justify">Al presionar la tecla "E", los coches eléctricos rotan sobre su eje Z. Una nueva pulsación detiene la rotación y restablece la rotación original.</p>

```sh
// Rotación de coches eléctricos
if (Input.GetKeyDown(KeyCode.E))
{
    for (int i = 0; i < GO.Length; i++)
    {
        if (Motores[i] == Motor.Electrico)
        {
            GO[i].transform.Rotate(new Vector3(0, 0, 1));
        }
    }
}
```
![2024-04-26-11-33-09-_online-video-cutter com_-_1_](https://github.com/valen28030/Cars/assets/167770750/4147f421-6749-4838-be38-8ac9a547ed89)

&nbsp; 

   <h3 align="justify">Utilización de un Único Script y Attributes</h3>
  <p align="justify">Todo el ejercicio se ha desarrollado en un único script, "Controlador.cs". Además, se han utilizado atributos para las variables y arrays para crear las variables necesarias.</p>

&nbsp; 

  <h3 align="justify">Función de Reset y Reinicio de Variables</h3>
  <p align="justify">Al presionar la tecla "R", se devuelve a los cinco coches a su posición inicial, se desactivan todos los coches y se reinician las variables, asignando valores aleatorios dentro de rangos lógicos. Los nombres de los coches también pueden cambiarse aleatoriamente si se implementa esta funcionalidad.</p>

```sh
// Función de reset y reinicio de variables
if (Input.GetKeyDown(KeyCode.R))
{
    // Devolver coches a posición inicial
    for (int i = 0; i < GO.Length; i++)
    {
        float posY = GO[i].transform.position.y;
        float posZ = GO[i].transform.position.z;
        transform.position = new Vector3(0, posY, posZ);
        GO[i].transform.position = transform.position;
    }

    // Desactivar todos los coches y devolver texto a opciones por defecto
    CocheSeleccionado = 0;
    textNombre.gameObject.SetActive(true);
    CocheSeleccionado();

    Activo[0] = false;
    Activo[1] = false;
    Activo[2] = false;
    Activo[3] = false;
    Activo[4] = false;

    // Reiniciar variables de los coches con valores aleatorios dentro de rangos lógicos
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

    DistanciaMaxima[0] = Random.Range(0, 15);
    DistanciaMaxima[1] = Random.Range(0, 15);
    DistanciaMaxima[2] = Random.Range(0, 15);
    DistanciaMaxima[3] = Random.Range(0, 15);
    DistanciaMaxima[4] = Random.Range(0, 15);
}
```
&nbsp;
<h2 align="justify">Requisitos del Sistema</h2>
<ul align="justify">
    <li><strong>Plataforma:</strong> Disponible para Windows, macOS y Linux.</li>
  &nbsp;
    <li><strong>Requisitos Mínimos de Hardware:</strong> Se recomienda un procesador de al menos 2.0 GHz, 4 GB de RAM y una tarjeta gráfica compatible con DirectX 11.</li>
</ul>
&nbsp; 

  <h2 align="justify">Conclusiones</h2>
  <p align="justify">El desarrollo de esta interfaz para la manipulación de coches en Unity ha sido exitoso. Se ha logrado una implementación robusta y funcional que permite al usuario interactuar con los coches de manera intuitiva y controlada.</p>
  <p align="justify">El uso de un único script y la integración de atributos y arrays demuestran un enfoque eficiente y organizado en el desarrollo del proyecto.</p>
  <p align="justify">En resumen, el proyecto ha sido una experiencia enriquecedora que ha permitido aplicar y consolidar conocimientos en el desarrollo de juegos con Unity, así como mejorar habilidades en programación y lógica de juego.</p>

&nbsp;

## Créditos

- **Desarrollador**: Carlos Valencia Sánchez
- **Diseñador de Juego**: Carlos Valencia Sánchez
- **Artista Gráfico**: Carlos Valencia Sánchez

&nbsp;
## Contacto

Para obtener soporte técnico, reportar errores o proporcionar comentarios, no dudes en contactar.

---
<p align="justify">Este documento proporciona una visión general del juego, incluyendo sus características, tecnología utilizada, requisitos del sistema, instrucciones de juego y créditos. Para obtener más información detallada sobre el desarrollo y funcionamiento del juego, consulta la documentación interna o comunícate con el desarrollador.</p>


