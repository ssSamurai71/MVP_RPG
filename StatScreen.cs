using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatScreen : Main_Loop
{
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

    // Start is called before the first frame update
    void Start()
    {
        Load_stats();       
    }

    // Update is called once per frame
    void Update()
    {
        Display_player_stats();
    }
}
