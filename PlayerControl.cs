//Nombre del desarrollador: Gabriel Vives
//Asignatura: Estructura de Datos
//Descripcion del uso de este codigo: Este scrpt se utilizara para generar el control del avatar jugador

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int vida;

    Rigidbody fisicasRB;

    [SerializeField]
   
    public float fuerzaSalto;
    float Direction;
     public Transform Cabeza;


    float EjeZ;
    float rotacionX; // estas variables son para designar cuanta rotacion tendra el jugador
    float rotacionY;
    [SerializeField]
    float VelRotPersonajeX = 0.3f; // estas variables son la velocidad de rotacion del jugador sobre sus respectivos ejes
    [SerializeField]
    float VelRotPersonajeY = 0.2f;

    void Start()
    {
      
        Cursor.visible = false;// Esto hace que nuestro cursor no aparezca al momento de ponerle play al juego
        fisicasRB = GetComponent<Rigidbody>(); //Busca un componente tipo RigidBody
        fuerzaSalto = 5.0f;// la fuerza que tendra nuestro personaje al momento de saltar
        Direction = 5.0f;// Es la fuerza con la que se movera nuestro jugador en las direcciones asignadas
        vida = 3;

    }

    // Update sirve para inicializar los datos previamente puestos.
    void Update()
    {
        // Los region nos sirven como carpetas para almacenar conjuntos de codigo
        //En esta parte, designamos en que direccion se movera nuestro jugador y las almacenamos en unas variables y la velocidad de rotacion al mirar
        #region Variables Locales
        EjeZ = Input.GetAxis("Vertical") * Direction* Time.deltaTime; 
     var EjeX = Input.GetAxis("Horizontal") * Direction* Time.deltaTime;
        rotacionX = Input.GetAxis("Mouse X") * VelRotPersonajeX;
        rotacionY = Input.mousePosition.x*VelRotPersonajeX;
        #endregion
      
      // este nos designa con que fuerza saltara el jugador junto con que tecla sera la designada para realizar dicha accion
        #region Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            fisicasRB.AddForce(Vector2.up * fuerzaSalto, ForceMode.Impulse);
        }
        #endregion

       
         #region Movimiento Fisicas

      /*  //voy a usar una entrada  input GetKey para el movimiento a izquierda y derecha de mi personaje
        //if (Input.GetKey(KeyCode.D))
        //{
        //    fisicasRB.AddForce(Vector2.right * Direction, ForceMode2D.Force);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    fisicasRB.AddForce(Vector2.left * Direction, ForceMode2D.Force);
        //}
        // Este if funciona para que al momento de que s deje de presionar la tecla indicada, el personaje se pare de manera inmediata y no tenga vuelo.
        if (Input.GetKey(KeyCode.D))
        {   // cambiar la velocidad del personaje de 0 a 1 en x //lee y mantiene el valor actual de velocidad en y
            fisicasRB.velocity =  new Vector2(Direction, fisicasRB.velocity.y);
           
        }

        else
        {
            fisicasRB.velocity = new Vector2(0, fisicasRB.velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            fisicasRB.velocity = new Vector3(-Direction, fisicasRB.velocity.y,0);
        }
         fisicasRB.velocity = new Vector3(fisicasRB.velocity.x,fisicasRB.velocity.y,EjeZ);

        */

        #endregion
       // aplicamos las variables previamente almacenadas y las ejecutamos
        #region Movimiento Transform

        transform.Translate(new Vector3(EjeX,0,EjeZ));


        #endregion
       // delimita la rotacion de vista del jugador
        #region Rotacion
         rotacionY = Mathf.Clamp(rotacionY,-90,90);
         transform.localEulerAngles = new Vector3(-Input.mousePosition.y*VelRotPersonajeY,rotacionY,0);
         #endregion
    
       /* if (Input.GetKey(KeyCode.Keypad4))
        {
            if(Time.time > tiempoDisparo)
        {
            if(PowerUp)
            {
               Instantiate(prefabPuntero, transform.position + new Vector3(1.0f,-0.59f,0),Quaternion.identity);
               Instantiate(prefabPuntero, transform.position + new Vector3(1.0f,0.59f,0),Quaternion.identity);
               Instantiate(prefabPuntero, transform.position + new Vector3(1.34f,0.0f,0),Quaternion.identity); 
            }
            else
            {
                   //rotacion = new Quaternion(0,0,-0.6f,1);
            Instantiate(prefabPuntero, transform.position + new Vector3(1.34f,0.0f,0),Quaternion.identity);
            
            }
            tiempoDisparo = Time.time + ritmoDisparo;
            */
         
        }
        }
        

  
    
    
    
// Fin del Cuerpo de la Clase


