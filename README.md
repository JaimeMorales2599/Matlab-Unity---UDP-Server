# Matlab-Unity---UDP-Server
Comunicación entre MATLAB y UNITY a través de un Servidor UDP

Se planteará una manera de comunicar **MATLAB Simulink** & **Unity** por un **Servidor UDP**, donde se enviará un paquete UDP desde un host (Simulink) hacia un servidor (Unity) 
utilizando una dirección IP remota y un puerto IP remoto.


## Configuración

### Simulink 

Utilizando el ambiente de **Simulink**, donde serán requeridos los siguientes bloques para lograr que un valor ( Sea número, Cadena) puedo ser enviado correctamente.

Bloques a utilizar:
- Constant
- To String
- String To ASCII
- Byte Data
- UDP Sent

![Resultado Esperado Simulink](https://github.com/JaimeMorales2599/Matlab-Unity---UDP-Server/blob/main/Imagen_1.PNG)

Esta configuración en Simulink, realiza la siguiente serie de instrucciones.

- **Constant - To String** : Convierte la señal de entrada tipo Entero **( 1 )** a una señal tipo Cadena **( "1" )**. 
- **To String - String To ASCII** : Convierte una señal tipo Cadena **( "1" )** hacia su valor ASCII correspondiente **( ASCII 49 )**.
- **String To ASCII - Byte Data** :   Empaqueta los datos de entrada ASCII en un vector único de salido tipo uint8.
- **Byte Data - UDP Send** : Se envía el paquete UDP hacia una  red identificada por una dirección **( 127.0.0.1 )** y puerto IP **( 1234 )** 



**Nota**: Las configuraciones y parámetros de los bloques se encuentran en el archivo **Conexion_Unity.slx** .


## Unity

Se creará un Componente en Unity donde se agregará el Script **Conexion.cs**, ya que este servirá como puente entre ambas conexiones, arrastrando el Componente al área llamada "Objecto Prueba" (Este recibirá la información)

![Resultado Esperado Unity](https://github.com/JaimeMorales2599/Matlab-Unity---UDP-Server/blob/main/Imagen_2.png)

## Ejecución

1.- Ejecutaremos el botón **Play** en el editor de Unity

2.- Cambiar a **Simulation Pacing** en el apartado de **Simulate** en Simulink 

3.- Ejecutar Simulink 

**Nota** : El "Stop Time" en Simulink puede variar en cualquier valor que el usuario desee.

.
.
.

## Resultado Esperado

![Resultado Esperado](https://github.com/JaimeMorales2599/Matlab-Unity---UDP-Server/blob/main/Imagen_3.png)


## Información Importante / Referencias

Este post está basado en información recopilada de los siguientes links

- https://forum.unity.com/threads/update-transform-component-of-the-object-from-local-server-via-udp.543324/
- https://github.com/simon-f-j/Simulink_In_Unity
