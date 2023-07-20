using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuscaRutas : MonoBehaviour
{
    public GameObject Objetivo;
    public NavMeshAgent[] agent;

    public GameObject carpetaDeAgentes;
    int numeroDeAgentes;


    void Start()
    {
        numeroDeAgentes = carpetaDeAgentes.transform.childCount;

        agent = new NavMeshAgent[numeroDeAgentes];

        for (int i = 0; i < numeroDeAgentes; i++)
        {
            agent[i] = carpetaDeAgentes.transform.GetChild(i).gameObject.GetComponent<NavMeshAgent>();
        }
    }

    void Update()
    {
       

    }
}