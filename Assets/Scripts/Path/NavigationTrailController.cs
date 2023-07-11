using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationTrailController : MonoBehaviour
{
    private List<Vector3> trailPoints = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTrailPoint(Vector3 point)
    {
        trailPoints.Add(point);
    }
}
