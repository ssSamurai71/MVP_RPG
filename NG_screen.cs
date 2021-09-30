using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NG_screen : Main_Loop
{
    public Text ng_hp_text,ng_atk_text,ng_def_text;

    void Display_NG_text()
    {
        ng_hp_text.text = "Bounus HP: " + p1.NG_HP.ToString();
        ng_atk_text.text = "Bonus ATK: " + p1.NG_ATK.ToString();
        ng_def_text.text = "Bonus DEF: " + p1.NG_DEF.ToString();
    }

    public void Upgrade_HP()
    {
        ng_hp_up();
        Save_stats();
    }

    public void Upgrade_ATK()
    {
        ng_atk_up();
        Save_stats();
    }

    public void Upgrade_DEF()
    {
        ng_def_up();
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
        Display_NG_text();
    }
}
