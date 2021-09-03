using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatScreen : Main_Loop
{
    public Text player_HP_REGEN, player_stat_points;

    public void SS_improve_hp()
    {
        improve_player_hp();
        Save_stats();
    }

    public void SS_improve_hp_regen()
    {   
        improve_player_hp_regen();
        Save_stats();
    }

    public void SS_improve_atk()
    {
        improve_player_atk();
        Save_stats();
    }

    public void SS_improve_def()
    {
        improve_player_def();
        Save_stats();
    }

    void Display_all_player_stats()
    {
        //p1.HP_REGEN = 1;
        player_HP_REGEN.text = "HP Regenration: " + p1.HP_REGEN.ToString();
        Debug.Log("Displayed regen " + p1.HP_REGEN.ToString());
        player_stat_points.text = "Usable Stat Points: " + p1.STAT_POINTS.ToString();
        Save_stats();
    }

    // Start is called before the first frame update
    void Start()
    {   
        Load_stats();       
        
    }

    // Update is called once per frame
    void Update()
    {   
        //p1.HP_REGEN = 1;
        Debug.Log("player regen "+ p1.HP_REGEN.ToString());
        Load_stats();
        Display_player_stats();
        Display_all_player_stats();
    }
}
