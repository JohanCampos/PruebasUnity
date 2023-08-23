using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMenu : MonoBehaviour
{
    public GameObject panelMenu;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) )
        {
            showMenu();
        }
    }

    public void showMenu()
    {
        if(panelMenu != null){
            Animator animator = panelMenu.GetComponent<Animator>();
            if(animator != null)
            {
                bool isOpen = animator.GetBool("show");
                animator.SetBool("show", !isOpen);
            }
        }
    }
}
