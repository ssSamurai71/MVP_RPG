using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatScreen : Main_Loop
{
    public Text player_stat_points;

    public void SS_improve_hp()
    {
        improve_player_hp();
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
        Display_player_stats();
        Display_all_player_stats();
    }
}
