using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    // Objetos y materiales de la escena 
    public GameObject sphereBase, lastButtonOverlay;
    public GameObject butt;
    public Material[] sphereMaterials;
    public Material selectMaterial, noSelectMaterial;
    [SerializeField] Transform[] objs;
    
    // Control de estado de material del botón
    bool startButtons = false;
    
    // Preparo un Raycast que sale de mi raton . Los botones tienen un collider q detectará
    Ray ray;
    RaycastHit hit;

    private void Start()
    {
        // Empiezo llenando un array con todos los transform de todos los objetos d la escena ( activos e inactivos ) para poder buscarlos luego
        objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
    }
    void Update()
    {
        //creo el raycast
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //si colisiona con algo
        if (Physics.Raycast(ray, out hit))
        {
            //aviso que estoy collisionando
            startButtons = true;
            // guardo el gameObject del boton para modificar su material
            lastButtonOverlay = hit.collider.gameObject;
            // pongo el material del botón en seleccionado
            hit.collider.gameObject.GetComponent<MeshRenderer>().material = selectMaterial;

            // Si mientras colisiono con un boton, hago click
            if (Input.GetMouseButtonDown(0))
                // acciones según boton con el que colisiono
                switch (hit.collider.name)
                {
                    case "buttonEntrance":
                        ChangeRoomTo(sphereMaterials[1]);
                        FindInActiveObjectByName("buttons1").SetActive(true);
                        break;
                    case "backToEntrance":
                        ChangeRoomTo(sphereMaterials[0]);
                        FindInActiveObjectByName("buttons0").SetActive(true);
                        break;
                    case "buttonOrangeHall":
                        ChangeRoomTo(sphereMaterials[2]);
                        break;
                }
        } // si no colisiona con nada (todo el rato menos cuando colisiona) el material del botón mantiene su color original
        else if(startButtons) { lastButtonOverlay.GetComponent<MeshRenderer>().material = noSelectMaterial; }
    }

    public void ChangeRoomTo(Material _material)
    {
        // Guardo el gameObjects de botones activos en la escena de la que vengo
        GameObject activeButtons = hit.collider.transform.parent.gameObject;
        // los desactivo
        activeButtons.SetActive(false);
        //cambio el material que me pasen x funcion
        sphereBase.GetComponent<MeshRenderer>().material = _material;
        
        
    }



    GameObject FindInActiveObjectByName(string name)
    {
        
        for (int i = 0; i < objs.Length; i++)
        {
            //si esta inactivo
            if (objs[i].hideFlags == HideFlags.None)
            {
                //y su nombre es el pasado por parametro
                if (objs[i].name == name)
                {
                    //devuelve el gameobject de ese nombre
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}
