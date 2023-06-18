using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{

    public Material materialHall, materialEntr, materialEste, materialOeste;
    public GameObject buttonHall, buttonEntr, buttonEste, buttonOeste;
    public GameObject panel, baseSphere;
    int cont = 0;
    public GameObject[] listButtons;
    public GameObject[] buttons;
    public void OpenGoTo() {
        if (cont == 0)
        {
            panel.SetActive(true);
            cont++;
        }else if (cont == 1)
        {
            panel.SetActive(false);
            cont = 0;
        }
    }

    private void OnEnable()
    {
        listButtons[0].GetComponent<Button>().onClick.AddListener(() => buttonCallBack(materialEntr, buttonEntr));
        listButtons[1].GetComponent<Button>().onClick.AddListener(() => buttonCallBack(materialHall,buttonHall));
        listButtons[2].GetComponent<Button>().onClick.AddListener(() => buttonCallBack(materialOeste, buttonOeste));
        listButtons[3].GetComponent<Button>().onClick.AddListener(() => buttonCallBack(materialEste, buttonEste));
    }

    private void buttonCallBack(Material _material, GameObject _button)
    {
        foreach (GameObject but in buttons)
        {
            but.SetActive(false);
        }
        baseSphere.GetComponent<MeshRenderer>().material = _material;
        _button.SetActive(true);
    }

}
