using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;

public class CollectableSpawner : MonoBehaviour
{

    //El objeto de destino Recolectable (desaparecer al estar cerca y terminar la ruta)
    [SerializeField]
    public Collectable Prefab;
    [SerializeField]
    public Transform Player;
    //Ruta a visualizar
    [SerializeField]
    public LineRenderer Path;
    //Altura de la línea al piso
    [SerializeField]
    public float PathHeightOffset = 1.25f;
    //Altura del objeto de destino entre el piso
    [SerializeField]
    public float SpawnHeightOffset = 1.50f;
    //Velocidad que se muestra la línea
    [SerializeField]
    public float PathUpdateSpeed = 0.25f;


    private Collectable ActiveInstance;
    private NavMeshTriangulation Triangulation;
    private Coroutine DrawPathCoroutine;

    public void Awake()
    {
        Triangulation = NavMesh.CalculateTriangulation();
    }

    private void Start()
    {
        SpawnNewObject();
    }

    public void SpawnNewObject()
    {
        ActiveInstance = Instantiate(Prefab, Triangulation.vertices[Random.Range(0, Triangulation.vertices.Length)] + Vector3.up * SpawnHeightOffset, 
            Quaternion.Euler(90,0,0)
        );

        ActiveInstance.Spawner = this;

        if (DrawPathCoroutine != null)
        {
            StopCoroutine(DrawPathCoroutine);
        }

        DrawPathCoroutine = StartCoroutine(DrawPathToCollectable());
    }

    private IEnumerator DrawPathToCollectable()
    {
        WaitForSeconds Wait = new WaitForSeconds(PathUpdateSpeed);
        NavMeshPath path = new NavMeshPath();

        while (ActiveInstance != null)
        {
            //Checar documentacion de NavMeshPath
            if (NavMesh.CalculatePath(Player.position, ActiveInstance.transform.position, NavMesh.AllAreas, path))
            {
                Path.positionCount = path.corners.Length;

                for (int i = 0; i < path.corners.Length; i++)
                {
                    Path.SetPosition(i, path.corners[i] + Vector3.up * PathHeightOffset);
                }
            }
            else
            {
                Debug.LogError($"Unable to calculate a path on the NavMesh between {Player.position} and {ActiveInstance.transform.position}!");
            }

            yield return Wait;
        }
    }
}
