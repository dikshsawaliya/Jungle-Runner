using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotSpawner : MonoBehaviour
{
    private int initAmount = 5;
    private float initStartz = 14.45f;
    private float plotSize = 60f;
    private float xPosLeft = -4f;
    private float xPosRight = 21.57f;
    private float lastZPos = 0f;

    public List<GameObject> plots;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initAmount; i++)
        {
            SpawnPlot();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlot()
    {
        GameObject plotLeft = plots[Random.Range(0, plots.Count)];
        GameObject plotRight = plots[Random.Range(0, plots.Count)];

        float zPos = lastZPos + plotSize;

        Instantiate(plotLeft, new Vector3(xPosLeft, 4.6f, zPos), plotLeft.transform.rotation);
        Instantiate(plotRight, new Vector3(xPosRight, 4.6f, zPos), new Quaternion(0, 180, 0, 0));


        lastZPos += plotSize;
    }
}
