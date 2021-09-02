using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_Loop : MonoBehaviour 
{
    public Text player_level, player_HP, player_DEF, player_ATK, player_EXP;
    public Text enemy_level, enemy_HP, enemy_DEF, enemy_ATK;
    public Text save_timer;

    protected Player p1 = new Player();
    Enemy random_mob = new Enemy();
    const int enemy_min_stat = 1, enemy_max_stat = 25, min_lvl = 2, max_lvl = 5;
    double min_scaling, max_scaling, min_lvl_scaling, max_lvl_scaling;
    float auto_save_time = 30;

    //have constants for starting stats
    const int start_player_hp = 100, start_current_hp = 100, start_player_hp_regen = 1, start_player_lvl = 1;
    const int start_player_atk = 10, start_player_def = 10, start_player_exp = 0, start_player_to_lvl = 100;

    public void Load_stats()
    {   
        p1.LVL = double.Parse(PlayerPrefs.GetString("p1.LVL","1"));
        p1.HP = double.Parse(PlayerPrefs.GetString("p1.HP","100"));
        p1.CURRENT_HP = double.Parse(PlayerPrefs.GetString("p1.CURRENT_HP","100"));
        p1.HP_REGEN = double.Parse(PlayerPrefs.GetString("p1.HP_REGEN","1"));
        p1.DEF = double.Parse(PlayerPrefs.GetString("p1.DEF","10"));
        p1.ATK = double.Parse(PlayerPrefs.GetString("p1.ATK","10"));
        p1.EXP = double.Parse(PlayerPrefs.GetString("p1.EXP","0"));
        p1.TO_LVL_UP = double.Parse(PlayerPrefs.GetString("p1.TO_LVL_UP","100"));
        p1.STAT_POINTS = double.Parse(PlayerPrefs.GetString("p1.STAT_POINTS","0"));
        p1.NG_POINTS = double.Parse(PlayerPrefs.GetString("p1.NG_POINTS","0"));
        p1.NG_HP = double.Parse(PlayerPrefs.GetString("p1.NG_HP","0"));
        p1.NG_HP_REGEN = double.Parse(PlayerPrefs.GetString("p1.NG_HP_REGEN","0"));
        p1.NG_ATK = double.Parse(PlayerPrefs.GetString("p1.NG_ATK","0"));
        p1.NG_DEF = double.Parse(PlayerPrefs.GetString("p1.NG_DEF","0"));               
    }

    public void Save_stats()
    {
        PlayerPrefs.SetString("p1.LVL",p1.LVL.ToString());
        PlayerPrefs.SetString("p1.HP",p1.HP.ToString());
        PlayerPrefs.SetString("p1.CURRENT_HP",p1.CURRENT_HP.ToString());
        PlayerPrefs.SetString("p1.HP_REGEN",p1.HP_REGEN.ToString());
        PlayerPrefs.SetString("p1.DEF",p1.DEF.ToString());
        PlayerPrefs.SetString("p1.ATK",p1.ATK.ToString());
        PlayerPrefs.SetString("p1.EXP",p1.EXP.ToString());
        PlayerPrefs.SetString("p1.TO_LVL_UP",p1.TO_LVL_UP.ToString());
        PlayerPrefs.SetString("p1.STAT_POINTS",p1.STAT_POINTS.ToString());
        PlayerPrefs.SetString("p1.NG_POINTS",p1.NG_POINTS.ToString());
        PlayerPrefs.SetString("p1.NG_HP",p1.NG_HP.ToString());
        PlayerPrefs.SetString("p1.NG_HP_REGEN",p1.NG_HP_REGEN.ToString());
        PlayerPrefs.SetString("p1.NG_ATK",p1.NG_ATK.ToString());
        PlayerPrefs.SetString("p1.NG_DEF",p1.NG_DEF.ToString());
    }

    void Auto_save()
    {
        if(auto_save_time <= 0)
        {        
            auto_save_time = 30;
            Save_stats();
        }
        auto_save_time -= 1 * Time.deltaTime;
        save_timer.text = "Time to next save: " + auto_save_time.ToString("F0");
    }

    public void Display_player_stats()
    {
        player_level.text = "Level: " + p1.LVL.ToString();
        player_HP.text = "HP: " + p1.CURRENT_HP.ToString("F0") + " / " + p1.HP.ToString();
        player_DEF.text = "DEF: " + p1.DEF.ToString("F0");
        player_ATK.text = "ATK: " + p1.ATK.ToString("F0");
        player_EXP.text = "EXP: " + p1.EXP.ToString("F0") + " / " + p1.TO_LVL_UP.ToString("F0");
    }

    public void Display_enemy_stats()
    {
        enemy_level.text = "Level: " + random_mob.LVL.ToString("F0");
        enemy_HP.text = "HP: " + random_mob.CURRENT_HP.ToString("F0") + " / " + random_mob.HP.ToString("F0");
        enemy_DEF.text = "DEF: " + random_mob.DEF.ToString("F0");
        enemy_ATK.text = "ATK: " + random_mob.ATK.ToString("F0");
    }

    void set_enemy_lvl()
    {
        if(p1.LVL == 1)
        {
            random_mob.LVL = Random.Range(min_lvl, max_lvl); 
        }
        else
        {
            min_lvl_scaling = min_lvl + p1.LVL;
            max_lvl_scaling = max_lvl + p1.LVL;
            random_mob.LVL = Random.Range( (float) min_lvl_scaling, (float) max_lvl_scaling); //Fix later
        }
    }

    void set_enemy_hp()
    {
        if(p1.LVL == 1)
        {
            random_mob.HP = Random.Range(enemy_min_stat , enemy_max_stat);
        }
        else
        {
            min_scaling = enemy_min_stat + (p1.ATK/2) + (p1.DEF/2) + (p1.LVL * 1.15);
            max_scaling = enemy_max_stat + (p1.ATK/2) + (p1.DEF/2) + (p1.LVL * 1.15);
            random_mob.HP = Random.Range( (float) min_scaling, (float) max_scaling);
        }
        
        random_mob.CURRENT_HP = random_mob.HP;
    }

    void set_enemy_atk()
    {
        if(p1.LVL == 1)
        {
            random_mob.ATK = Random.Range(enemy_min_stat, (float) p1.ATK + 1);
        }
        else
        {
            min_scaling = enemy_min_stat + (p1.LVL * 1.15);
            max_scaling = (p1.ATK + p1.LVL) + (p1.LVL * 1.15);
            random_mob.ATK = Random.Range( Mathf.RoundToInt( (float) min_scaling), Mathf.RoundToInt( (float) max_scaling));
        }
        
    }

    void set_enemy_def()
    {
        if(p1.LVL <= 3)
        {
            random_mob.DEF = Random.Range(enemy_min_stat, (float) p1.DEF - 1);
        }
        else
        {
            min_scaling = enemy_min_stat + (p1.LVL * 1.15);
            max_scaling = (p1.ATK - 4) + (p1.LVL * 1.15);
            random_mob.DEF = Random.Range( (float) min_scaling, (float) max_scaling);
        }
    }

    void set_enemy_drop_exp()
    {
        if(p1.LVL == 1)
        {
            random_mob.DROP_EXP = Random.Range(enemy_min_stat, 9);
        }
        else
        {
            min_scaling = enemy_min_stat + (p1.LVL * 1.15);
            max_scaling = enemy_max_stat + (p1.LVL * 1.15);
            random_mob.DROP_EXP = Random.Range( Mathf.RoundToInt( (float) min_scaling), Mathf.RoundToInt( (float)max_scaling));
        }
    }

    public void Spawn_enemy()
    {   
        set_enemy_atk();
        set_enemy_def();
        set_enemy_drop_exp();
        set_enemy_hp();
        set_enemy_lvl();
    }

    //damage the player
    void Enemy_attack()
    {
        double damage_reduced = p1.ATK - random_mob.DEF;
        if(damage_reduced < 0)
            { damage_reduced = 1; }
        random_mob.CURRENT_HP -= damage_reduced * Time.deltaTime;
    }

    //damage the enemy
    void Player_attack()
    {
        double damage_reduced = random_mob.ATK - p1.DEF;
        if(damage_reduced < 0)
            { damage_reduced = 1; }
        p1.CURRENT_HP -= damage_reduced * Time.deltaTime;
    }

    //respawn player if they died
    //use to also fight a new enemy
    public void Revive_player()
    {
        p1.CURRENT_HP = p1.HP;
        Spawn_enemy();
    }

    //give exp if enemy died
    void Provide_exp()
    {
        p1.EXP += random_mob.DROP_EXP;
        Spawn_enemy();
    }

    //handle some hp regen
    void Regen_health()
    {
        if(p1.CURRENT_HP <= p1.HP)
        {
            p1.CURRENT_HP += p1.HP_REGEN * Time.deltaTime;
        }
    }

    //handle the basic loop
    public void Fight()
    {
        if(random_mob.CURRENT_HP > 0)
        {
            Player_attack();
            Regen_health();
            if(p1.CURRENT_HP > 0 && random_mob.CURRENT_HP > 0)
            {
                Enemy_attack();
            }

            if(random_mob.CURRENT_HP <= 0)
            {
                Provide_exp();
            }

            if(p1.CURRENT_HP <= 0)
            {
                Revive_player();
            }
        }
    }

    public void improve_player_hp()
    {
        if(p1.STAT_POINTS > 0)
        {
            p1.improve_hp();
        }
    }

    public void improve_player_hp_regen()
    {
        if(p1.STAT_POINTS > 0)
        {
            p1.improve_hp_regen();
        }
    }

    public void improve_player_atk()
    {
        if(p1.STAT_POINTS > 0)
        {
            p1.improve_atk();
        }
    }

    public void improve_player_def()
    {
        if(p1.STAT_POINTS > 0)
        {
            p1.improve_def();
        }
    }

    void Level_up()
    {
        p1.lvl_up();
    }

    void set_starting_player_values()
    {
        p1.HP = start_player_hp;
        p1.CURRENT_HP = start_current_hp;
        p1.ATK = start_player_atk;
        p1.DEF = start_player_def;
        p1.LVL = start_player_lvl;
        p1.EXP = start_player_exp;
        p1.TO_LVL_UP = start_player_to_lvl;
        p1.HP_REGEN = start_player_hp_regen;
    }

    public void Start_NG()
    {
        p1.generate_NG_point();
        set_starting_player_values();
    }

    public void Hard_reset()
    {
        set_starting_player_values();
        p1.NG_ATK = 0;
        p1.NG_DEF = 0;
        p1.NG_HP = 0;
        p1.NG_HP_REGEN = 0;
        p1.NG_POINTS = 0;
        Spawn_enemy();
        Save_stats();
    }

    void Add_NG_stats()
    {
        p1.HP = p1.HP + p1.NG_HP;
        p1.HP_REGEN = p1.HP_REGEN + p1.HP_REGEN;
        p1.ATK = p1.ATK + p1.NG_ATK;
        p1.DEF = p1.DEF + p1.NG_DEF;
    }

    // Start is called before the first frame update
    void Start()
    {   
        Load_stats();
        Spawn_enemy();
        Add_NG_stats();
    }

    // Update is called once per frame
    void Update()
    {
        Display_player_stats();
        Display_enemy_stats();
        //Fight();
        Level_up();
        Auto_save();
        Add_NG_stats();
    }
}
