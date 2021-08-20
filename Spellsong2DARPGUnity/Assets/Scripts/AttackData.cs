using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackData", menuName = "ScriptableObjects/AttackData")]
public class AttackData : ScriptableObject
{
    public string attackName;
    public string attackType;
    public int damage;
    public int hitstunToApply;
    public bool canBeDeflected;
    public bool canBeParried;
    public bool canBeBlocked;
    public bool blockNegates;
}
