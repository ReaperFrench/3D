//Nombre del desarrollador: Gabriel Vives
//Asignatura: Estructura de Datos
//Descripcion del uso de este codigo: Este scrpt se utilizara para realizar que el enmigo localize al jugador y se mueva hacia el
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float VelocidadEnemigo;
    public Transform Target;
    public Transform Ojos;
    // Start is called before the first frame update
    void Start()
    {
        //Encontramos el movimiento de las variables designadas para utilizarlas
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Ojos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // indica que el enemigo vea al jugador en cualquier posicion en la que este se encuentre
        Ojos.LookAt(Target.position);

         Vector3 PosEnemigo = this.transform.position;
         Vector3 PosTargetJugador = Target.position;

        float DistanciaEntreObjetos = Vector3.Distance(PosTargetJugador, PosEnemigo);
        // muestra una linea indicando si el enemigo realmente esta viendo al jugador
        Debug.DrawLine(PosEnemigo,PosTargetJugador,Color.green);
        // Esto genera que el enemigo depediendo de que distancia tenga, este se movera hasta el y parara a cierta distancia y muera.
        if (DistanciaEntreObjetos > 3)
        {
             transform.position = Vector3.MoveTowards(this.transform.position,Target.position,VelocidadEnemigo*Time.deltaTime);
        }
        if (DistanciaEntreObjetos <= 3)
        {
            Destroy(this.gameObject, 2f);
            
        }

       
    }
}
