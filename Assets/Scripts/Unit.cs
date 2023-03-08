using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic Class for Holding the Stats of a unit in game
/// and calling dmg dealing methods
/// </summary>

public abstract class Unit : MonoBehaviour
{
    //fields
    [SerializeField] private int level;
    protected Dictionary<Stat, float> stats;
    
    //Getter Properties
    public Dictionary<Stat, float> Stats => stats;

    //Initialization
    private void Awake()
    {
        level = 0;
        stats = new Dictionary<Stat, float>() { {Stat.MaxHp,0}, { Stat.Hp, 0 }, { Stat.Atk, 0 }, { Stat.DmgRes, 0 }, { Stat.AttackSpeed, 0 }, { Stat.CritChance, 0 }, };
        SetSecondaryStats();
    }

    protected abstract void SetSecondaryStats();

    //Methods for Dmg Handling
    public void ReceiveHit(float incomingDmg)
    {
        float dmgReceived = CalculateDmgReceived(incomingDmg);
        LowerHp(dmgReceived);
    }

    private float CalculateDmgReceived(float incomingDmg)
    {
        float dmgMitigated = incomingDmg * stats[Stat.DmgRes]/100f;
        return incomingDmg - dmgMitigated;
    }

    private void LowerHp(float dmgReceived)
    {
        float hpAfterHit = stats[Stat.Hp] - dmgReceived;
        if (hpAfterHit <= 0) //lethal hit
        {
            Die();
        }
        else//non-lethal hit
        {
            stats[Stat.Hp] = hpAfterHit;
            OnDmgReceived();
        }
    }


    protected virtual void OnDmgReceived()
    {
        
        //animator dmgTakenBool true
    }

    protected virtual void Die()
    {
        //animator isDeadBool true
    }

}
