using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bootstrapper bootstrapper;

    void Start()
    {
        bootstrapper = FindFirstObjectByType<Bootstrapper>();
        if (bootstrapper.objectPool != null)
        {
            bootstrapper.currentBullet = bootstrapper.maxBullet;
        }
    }

    void Update()
    {
        bootstrapper.timeShoot += Time.deltaTime;
        if (bootstrapper.targetPoint != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, bootstrapper.targetPoint.position, bootstrapper.speedMove * Time.deltaTime);
            if (Vector3.Distance(transform.position, bootstrapper.targetPoint.position) <= 0.5f)
            {
                Shoot();
            }
        }
        if (bootstrapper.currentBulletImage != null)
        {
            bootstrapper.currentBulletImage.fillAmount = (float)bootstrapper.currentBullet / bootstrapper.maxBullet;
        }
        if (bootstrapper.scoreText != null)
        {
            bootstrapper.scoreText.text = bootstrapper.score.ToString();
        }
    }

    void Shoot()
    {
        if (bootstrapper.startShoot != null && bootstrapper.objectPool != null && Input.GetKey(KeyCode.Mouse0) && bootstrapper.timeShoot >= bootstrapper.timeNextShoot && bootstrapper.currentBullet > 0)
        {
            GameObject bullet = bootstrapper.objectPool.GetObject();
            bullet.transform.position = bootstrapper.startShoot.position;
            bootstrapper.currentBullet--;
            bootstrapper.timeShoot = 0;
        }
        else if (bootstrapper.timeShoot >= bootstrapper.timeNextShoot && bootstrapper.currentBullet < bootstrapper.maxBullet)
        {
            bootstrapper.currentBullet++;
            bootstrapper.timeShoot = 0;
        }
    }
}
