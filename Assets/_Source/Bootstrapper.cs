using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bootstrapper : MonoBehaviour
{
    public List<GameObject> layers;
    public ObjectPool objectPool;
    [Header("TowerSpawn")]
    public TowerSettings[] towerSettings;
    public int NumberOfLayers;
    public int index;
    public float towerHeight;
    [Header("Bullet")]
    public Player player;
    public TowerSpawn towerSpawn;
    public float speed;
    public float timeNextReturn;
    [Header("Player")]
    public Transform targetPoint;
    public Transform startShoot;
    public Image currentBulletImage;
    public TMP_Text scoreText;
    public int maxBullet;
    public int currentBullet;
    public int score;
    public float speedMove;
    public float timeShoot;
    public float timeNextShoot;
    [Header("EndGame")]
    public GameObject retry;
    public TMP_Text result;
}
