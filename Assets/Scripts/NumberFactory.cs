using System;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// Class collecting useful static methods for number generating and altering
/// </summary>

public class NumberFactory 
{
    //Random Entropy Generator
    static RandomNumberGenerator randomGenerator2;

    //Generating Better Random Numbers
    private static int GenerateRandomInteger()
    {
        // Generate four random bytes
        byte[] four_bytes = new byte[4];
        randomGenerator2.GetBytes(four_bytes);

        // Convert the bytes to a Int32
        int rand = BitConverter.ToInt32(four_bytes, 0);
        if (rand < 0) { rand = -rand; } //only positive numbers wanted

        return rand;
    }

    public static int RandomInt(int minInclusive, int maxExclusive)
    {
        return (minInclusive + GenerateRandomInteger() % (maxExclusive - minInclusive));
    }

    public static int RandomPerc() // Generate random number in [0,100)
    {
       
        return (GenerateRandomInteger() % 100);
    }

    //Conventional Rounding
    public static int ProperRound(float x)
    {
        float y = Mathf.Floor(x);
        if (y + 0.5 > x) { return (int)y; }
        else { return (int)(y + 1); }
    }

}



