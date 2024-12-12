using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Bootstrapper bootstrapper;
    public float timeReturn;

    void Start()
    {
        bootstrapper = FindFirstObjectByType<Bootstrapper>();
        rigidbody.GetComponent<Rigidbody>();
        rigidbody.AddForce(Vector3.fwd * bootstrapper.speed, ForceMode.Impulse);
    }

    void Update()
    {
        timeReturn += Time.deltaTime;
        if (timeReturn >= bootstrapper.timeNextReturn)
        {
            bootstrapper.objectPool.ReturnObject(gameObject);
            transform.position = bootstrapper.objectPool.transform.position;
            timeReturn = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Layer")
        {
            bootstrapper.score += bootstrapper.towerSettings[bootstrapper.index].score;
            bootstrapper.objectPool.ReturnObject(gameObject);
            transform.position = bootstrapper.objectPool.transform.position;
            timeReturn = 0;
            bootstrapper.layers.Remove(other.gameObject);
            Destroy(other.gameObject);
        }

        if (other.tag == "Shield")
        {
            bootstrapper.score -= bootstrapper.towerSettings[bootstrapper.index].score;
            bootstrapper.objectPool.ReturnObject(gameObject);
            transform.position = bootstrapper.objectPool.transform.position;
            timeReturn = 0;
            bootstrapper.layers.Remove(other.gameObject);
        }
    }
}
