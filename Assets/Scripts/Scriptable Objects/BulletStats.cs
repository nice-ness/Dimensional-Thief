using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletStats", menuName = "ScriptableObjects/BulletStatsScriptableObject", order = 1)]


public class BulletStats : ScriptableObject
{
    public int speed;
    public int damage;
    public string teamTag = "Enemy";
}
