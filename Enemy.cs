using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Characters
{
    private double drop_exp;
    
    public double DROP_EXP
    {
        get
        {
            return drop_exp;
        }
        set
        {
            drop_exp = value;
        }
    }

}
