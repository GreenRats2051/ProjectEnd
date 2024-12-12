using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    public Bootstrapper bootstrapper;

    void Start()
    {
        bootstrapper = FindFirstObjectByType<Bootstrapper>();
        bootstrapper.index = Random.Range(0, bootstrapper.towerSettings.Length);
        for (int i = 0; i < bootstrapper.NumberOfLayers; i++)
        {
            GameObject layer = Instantiate(bootstrapper.towerSettings[bootstrapper.index].layerModel, new Vector3(transform.position.x, transform.position.y + 0.5f + i * bootstrapper.towerHeight, transform.position.z), transform.rotation);
            bootstrapper.layers.Add(layer);
        }
    }
}
