using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{

    public static List<Transform> points;
    // Start is called before the first frame update
    void Awake()
    {
        points = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            points.Add(transform.GetChild(i));
        }
    }
    
}
