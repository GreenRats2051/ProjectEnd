using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject bullet;
    public int quantity;
    Queue<GameObject> queue;

    void Start()
    {
        queue = new Queue<GameObject>();
        for (int i = 0; i < quantity; i++)
        {
            GameObject gameObject = Instantiate(bullet, transform);
            gameObject.SetActive(false);
            queue.Enqueue(gameObject);
        }
    }

    public GameObject GetObject()
    {
        if (queue.Count > 0)
        {
            GameObject gameObject = queue.Dequeue();
            gameObject.SetActive(true);
            return gameObject;
        }
        else
        {
            return null;
        }
    }

    public void ReturnObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
        queue.Enqueue(gameObject);
    }
}
