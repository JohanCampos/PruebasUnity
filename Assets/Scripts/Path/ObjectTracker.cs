using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTracker : MonoBehaviour
{
    public NavigationTrailController trailController;

    // Start is called before the first frame update
    void Start()
    {
        trailController = FindObjectOfType<NavigationTrailController>();
    }

    // Update is called once per frame
    void Update()
    {
        trailController.AddTrailPoint(transform.position);
    }
}
