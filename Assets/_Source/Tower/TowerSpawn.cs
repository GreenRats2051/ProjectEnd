using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    private Bootstrapper bootstrapper;

    void Start()
    {
        bootstrapper = FindFirstObjectByType<Bootstrapper>();
        bootstrapper.index = Random.Range(0, bootstrapper.towerSettings.Length);
        int rangeHieghtTower = Random.Range(10, 20);
        for (int i = 0; i < rangeHieghtTower; i++)
        {
            GameObject layer = Instantiate(bootstrapper.towerSettings[bootstrapper.index].layerModel, new Vector3(transform.position.x, transform.position.y + 0.5f + i * bootstrapper.towerHeight, transform.position.z), transform.rotation);
            if (i%2 == 0)
            {
                layer.GetComponent<Renderer>().material.color = Color.white;
            }
            else
            {
                layer.GetComponent<Renderer>().material.color = Color.grey;
            }
            bootstrapper.layers.Add(layer);
        }
    }
}
