using UnityEngine;
using System.Collections;

public class DataIni : MonoBehaviour {

    IniFile pIDIni;
    Monster mon;
    Game game;
    bool latestartcheck;

    // Use this for initialization
    void Start () {

        latestartcheck = false;
        pIDIni = new IniFile("ProjectID"); // ini extension appends to file name here
        

    }
	
	// Update is called once per frame
	void Update () {

        if (latestartcheck == false)
        {
            mon = GameObject.Find("GameObj").GetComponent<Monster>();
            game = GameObject.Find("GameObj").GetComponent<Game>();
            //Debug.Log(game.score);
            latestartcheck = true;
        }
	
	}
        

    public void SetExpLvMC()
    {
        pIDIni.SetInt("Exp", game.score);
        pIDIni.SetInt("Level", game.level);
        pIDIni.SetInt("MaxCombo", game.maxCombo);
        pIDIni.SetInt("BasicRemainTurn", game.basicRemainTurn);

        pIDIni.Save("ProjectID");
    }

    public void DataReset()
    {
        pIDIni.SetInt("Exp", 0);
        pIDIni.SetInt("Level", 1);
        pIDIni.SetInt("MaxCombo", 0);
        pIDIni.SetInt("BasicRemainTurn", 5);

        pIDIni.Save("ProjectID");
    }

    public int GetExp()
    {
        int exp = pIDIni.GetInt("Exp");        
        return exp;

    }

    public int GetMaxCombo()
    {
        int maxCombo = pIDIni.GetInt("MaxCombo");
        return maxCombo;

    }

    public int GetLV()
    {
        int level = pIDIni.GetInt("Level");
        return level;
    }

    public int GetBasicRemainTurn()
    {
        int basicRemainTurn = pIDIni.GetInt("BasicRemainTurn");
        return basicRemainTurn;

    }

}
