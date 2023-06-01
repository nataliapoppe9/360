using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    public GameObject sphereBase, lastButtonOverlay;
    public Material hallMaterial;
    public Material selectMaterial, noSelectMaterial;
    bool startButtons = false;
    Ray ray;
    RaycastHit hit;
  
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            startButtons = true;
            lastButtonOverlay = hit.collider.gameObject;
            hit.collider.gameObject.GetComponent<MeshRenderer>().material = selectMaterial;

            if (Input.GetMouseButtonDown(0))
                switch (hit.collider.name)
                {
                    case "buttonEntrance": ChangeRoomTo(hallMaterial); break;
                }
        }
        else if(startButtons) { lastButtonOverlay.GetComponent<MeshRenderer>().material = noSelectMaterial; }
    }

    public void ChangeRoomTo(Material _material)
    {

        GameObject activeButtons = hit.collider.transform.parent.gameObject;
        activeButtons.SetActive(false);
        sphereBase.GetComponent<MeshRenderer>().material = _material;
    }
}
