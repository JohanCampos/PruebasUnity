using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMenu : MonoBehaviour
{
    public GameObject panelMenu;
    public bool menuActivo = false;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject juego;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) )
        {
            menuActivo = !menuActivo;
            showMenu();
        }
    }

    public void showMenu()
    {
        if (menuActivo)
        {
            Time.timeScale = 0f;
            menuPausa.SetActive(true);
            juego.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            menuPausa.SetActive(false);
            juego.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }
}
