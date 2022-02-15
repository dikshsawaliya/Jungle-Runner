using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoadSpawnerUpside : MonoBehaviour
{

    public List<GameObject> roads1;
    private float offset = 7f;


    void Start()
    {
        if (roads1 != null && roads1.Count > 0)
        {
            roads1 = roads1.OrderBy(r => r.transform.position.z).ToList();
        }
    }


    public void MoveRoad()

    {

        GameObject moveRoad = roads1[0];
        roads1.Remove(moveRoad);
        float newZ = roads1[roads1.Count - 1].transform.position.z + offset;
        moveRoad.transform.position = new Vector3(0, 0, newZ);
        roads1.Add(moveRoad);

    }
}
