using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stats and unique traits of Grunt Unit
/// </summary>

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
        base.OnDmgReceived();
        
        //Grunts might become enraged when hit
        if (!isEnraged && (NumberFactory.RandomPerc() < 10f)) 
        { 
            isEnraged = true;
            stats[Stat.Atk] = 15f;
            stats[Stat.CritChance] = 10f;
            StartCoroutine(RageTimer());
        }
    }

    private IEnumerator RageTimer()
    {
        yield return new WaitForSeconds(8f);
        stats[Stat.Atk] = 10f;
        stats[Stat.CritChance] = 5f;
        isEnraged = false;
    }
}
