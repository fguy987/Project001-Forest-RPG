using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class For Managing the stats of Hero
/// </summary>
public class Hero : Unit
{

    // Start is called before the first frame update
    void Start()
    {
        SetSecondaryStats();
    }
    protected override void SetSecondaryStats()
    {
        stats[Stat.Atk] = 15f;
        stats[Stat.DmgRes] = 20f;
        stats[Stat.AttackSpeed] = 10f;
        stats[Stat.CritChance] = 5f;
    }

}
