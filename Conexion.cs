// Importamos las librerias

using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Specialized;
using System.Globalization;


// Clase publica principal

public class Conexion : MonoBehaviour
{

    // Inicializamos las variables

    private UdpClient Servidor;     // Inicializamos el Servidor
    private Thread hilo;           // Inicializamos un hilo
    private IPEndPoint remoteEndPoint;    // Representa un punto de conexión de red como una dirección IP y un número de puerto
    
    private String[] valorRecibidoCadena;
    private Byte[] valorEntrada; // Declaramos un valor de tipo Byte (En Matriz, Por los valores de tipo ASCII (048, 049, 050))
    private bool Activador = true;
    
    public GameObject objetoPrueba; // Iniciamos un GameObject

    void Start()
    {
        Servidor = new UdpClient(1234); // Creamos el Servidor y el Puerto "1234"

        hilo = new Thread(() => { 
            while (true) 
            {
                this.recibirDatos(); // Referencia al objeto que estamos utilizando. 
            }

        });

        hilo.Start(); // Iniciamos el Thread
        hilo.IsBackground = true; // Establecemos  el subproceso en segundo plano
        remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234); // Establecemos el Servidor y Host
    }

    void Update()
    {
        if(Activador == true) // Si no lo tiene, mandamos mensaje
        {
            Debug.Log("No se recibe ningun valor");
        }
    }

    private void OnApplicationQuit() // Al quitar la aplicacion
    {
        Servidor.Close(); // Cerramos el Servidor
        hilo.Abort(); // Terminamos el Hilo

    }

    private void recibirDatos() // Funcion "Recibir Datos"
    {
        valorEntrada = Servidor.Receive(ref remoteEndPoint); // Variable que recibimos en formato Byte (Uint-8)

        if(valorEntrada.Length > 0) // Checamos que tenga un valor
        {

            Activador = false; // Cancelamos el activador
            var str = System.Text.Encoding.Default.GetString(valorEntrada); // Convertimos el valor que se recibe de MATLAB
            Debug.Log("Dato Recibido: " + str); // Se imprime en pantalla

        }
        
    }

}