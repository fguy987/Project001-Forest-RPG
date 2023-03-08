using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : Unit
{
    private bool isEnraged = false;
    
    protected override void SetSecondaryStats()
    {
        stats[Stat.Atk] = 10f;
        stats[Stat.DmgRes] = 20f;
        stats[Stat.AttackSpeed] = 10f;
        stats[Stat.CritChance] = 5f;
    }

    protected override void OnDmgReceived()
    {
        
    }

}
