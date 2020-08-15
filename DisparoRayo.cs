//Nombre del desarrollador: Gabriel Vives
//Asignatura: Estructura de Datos
//Descripcion del uso de este codigo: Este scrpt se utilizara para que el jugador localize al enemigo y pueda eliminarlo

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisparoRayo : MonoBehaviour
{
    public float DistanciaRayo;// mide la distancia del registro con los objetos a registrar
    public LayerMask CapaDaño; // nos registra el daño dado
    public Transform Barril; // es el inicio de donde saldra nuestro proyectil
    public Image Puntero; //es una imagen a utilizar como reticula
    private Ray Rayo;// es el registro en si
    private Ray RayoInteraccion; //la interaccion que tiene el registro con los objetos
    private RaycastHit HitInfo;// registra la colision con un objeto
    private Vector2 CentroCamara;// variable que nos designa el centro de la camara

    // Start is called before the first frame update
    void Start()
    {
        // estas variables nos sirven para posisionar una imagen en el centro de la pantalla
        this.CentroCamara.x = Screen.width / 2;
        this.CentroCamara.y = Screen.height / 2;
        //este nos dice que el puntero del mouse no sera mostrado al momento de ponerle play
        Cursor.lockState=CursorLockMode.None;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //nos indica la direccion y posicion del objeto a lanzar
        Rayo.origin = Barril.position;
        Rayo.direction = Barril.forward;
        RayoInteraccion = Camera.main.ScreenPointToRay(this.CentroCamara);
        //nos indica en pantalla como desarrolladores la linea que se genera
        Debug.DrawRay(RayoInteraccion.origin,RayoInteraccion.direction*DistanciaRayo,Color.green);
        // al momento de que el rayo colisiona con algo le ocasionara daño
        if(Physics.Raycast(RayoInteraccion, out HitInfo,DistanciaRayo,CapaDaño))
        {
            // al momento de que colisione con un tag en especifico la reticula se coloreara de un color en especifico
            if(HitInfo.collider!=null)
            {
                if (HitInfo.collider.tag == "Enemy")
                {
                    Puntero.color = Color.green;
                }
            }
        }
        else
        {
            Puntero.color = Color.white;
        }
        // Al momento de hacer click y que el rayo este colisionando con un tag en especifico este sera destruido
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(Rayo,out HitInfo,DistanciaRayo,CapaDaño))
            {
                if (HitInfo.collider != null)
                {
                    if (HitInfo.collider.tag == "Enemy")
                    {
                        Destroy(HitInfo.collider.gameObject);
                    }
                }   
            }
        }
    }
}
