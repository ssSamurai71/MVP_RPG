using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Characters
{
    private double exp;
    private double level;
    private double to_lvl_up;
    private double stat_points;
    private double new_game_points;
    private double start_hp;
    private double start_hp_regen;
    private double start_def;
    private double start_atk;
    const int min_stat_roll = 1;
    const int max_stat_roll = 5;
    const int ng_calc = 5;
    private double ng_hp;
    private double ng_hp_regen;
    private double ng_def;
    private double ng_atk;

    public double EXP
    {
        get
        {
            return exp;
        }
        set
        {
            exp = value;
        }
    }

    public double TO_LVL_UP
    {
        get
        {
            return to_lvl_up;
        }
        set
        {
            to_lvl_up = value;
        }
    }

    public double STAT_POINTS
    {
        get
        {
            return stat_points;
        }
        set
        {
            stat_points = value;
        }
    }

    public double NG_POINTS
    {
        get
        {
            return new_game_points;
        }
        set
        {
            new_game_points = value;
        }
    }

    public double START_HP
    {
        get
        {
            return start_hp;
        }
        set
        {
            start_hp = value;
        }
    }

    public double START_HP_REGEN
    {
        get
        {
            return start_hp_regen;
        }
        set
        {
            start_hp_regen = value;
        }
    }

    public double START_DEF
    {
        get
        {
            return start_def;
        }
        set
        {
            start_def = value;
        }
    }

    public double START_ATK
    {
        get
        {
            return start_atk;
        }
        set
        {
            start_atk = value;
        }
    }

    //figure out if a point can be generated
    public void generate_NG_point()
    {
        if(LVL >= ng_calc )
        {
            NG_POINTS = Mathf.Round( (float) LVL / (float) ng_calc);
        }
        
    }

    public void lvl_up()
    {
        if(EXP >= TO_LVL_UP)
        {
            while(EXP >= TO_LVL_UP)
            {
                LVL += 1;
                STAT_POINTS += 3;
                TO_LVL_UP *= 1.15;
                HP += Random.Range(min_stat_roll, max_stat_roll);
                HP_REGEN += Random.Range(min_stat_roll, max_stat_roll);
                DEF += Random.Range(min_stat_roll, max_stat_roll);
                ATK += Random.Range(min_stat_roll, max_stat_roll);
            }
            EXP = 0;
        }
    }

    public void improve_hp()
    {
        if(STAT_POINTS > 0)
        {
            HP += 50;
            STAT_POINTS = STAT_POINTS - 1;
        }
    }

    public void improve_hp_regen()
    {
        if(STAT_POINTS > 0)
        {
            HP_REGEN += 5;
            STAT_POINTS = STAT_POINTS - 1; 
        }
        
    }

    public void improve_def()
    {
        if(STAT_POINTS > 0)
        {
            DEF += 1;
            STAT_POINTS = STAT_POINTS - 1;
        }
        
    }

    public void improve_atk()
    {
        if(STAT_POINTS > 0)
        {
            ATK += 1;
            STAT_POINTS = STAT_POINTS - 1;
        }
        
    }

    public void set_start_stats()
    {
        START_HP = HP;
        START_HP_REGEN = HP_REGEN;
        START_DEF = DEF;
        START_ATK = ATK;
    }

    public void hard_reset_stats()
    {
        HP = START_HP;
        HP_REGEN = START_HP_REGEN;
        DEF = START_DEF;
        ATK = START_ATK;
    }

    //ng plus stuff
    public double NG_HP
    {
        get
        {
            return ng_hp;
        }
        set
        {
            ng_hp = value;
        }
    }

    public double NG_HP_REGEN
    {
        get
        {
            return ng_hp_regen;
        }
        set
        {
            ng_hp_regen = value;
        }
    }

    public double NG_ATK
    {
        get
        {
            return ng_atk;
        }
        set
        {
            ng_atk = value;
        }
    }

    public double NG_DEF
    {
        get
        {
            return ng_def;
        }
        set
        {
            ng_def = value;
        }
    }

    public void improve_ng_hp()
    {
        if(NG_POINTS > 0)
        {
            NG_HP += 10;
            NG_POINTS = NG_POINTS - 1;    
        }
        
    }

    public void improve_ng_hp_regen()
    {
        if(NG_POINTS > 0)
        {
            NG_HP_REGEN += 2;
            NG_POINTS = NG_POINTS - 1; 
        }
        
    }

    public void improve_ng_def()
    {
        if(NG_POINTS > 0)
        {
            NG_DEF += 1;
            NG_POINTS = NG_POINTS - 1;    
        }
        
    }

    public void improve_ng_atk()
    {
        if(NG_POINTS > 0)
        {
            NG_ATK += 1;
            NG_POINTS = NG_POINTS - 1;
        }
    }
}
