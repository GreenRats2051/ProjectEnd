using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerSettings", menuName = "ThisProject/TowerSettings", order = 1)]
public class TowerSettings : ScriptableObject
{
    public GameObject layerModel;
    public int score;
}
