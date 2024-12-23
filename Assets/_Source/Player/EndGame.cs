using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private Bootstrapper bootstrapper;

    void Start()
    {
        bootstrapper = FindFirstObjectByType<Bootstrapper>();
        Time.timeScale = 1;
    }

    void Update()
    {
        if (bootstrapper.score < 0)
        {
            Time.timeScale = 0;
            bootstrapper.result.text = "You over!";
            bootstrapper.result.color = Color.red;
            bootstrapper.retry.SetActive(true);
        }
        if (bootstrapper.layers.Count <= 0)
        {
            Time.timeScale = 0;
            bootstrapper.result.text = "You win!";
            bootstrapper.result.color = Color.green;
            bootstrapper.retry.SetActive(true);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
