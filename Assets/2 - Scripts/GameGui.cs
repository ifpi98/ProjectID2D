using UnityEngine;
using System;
using System.Collections;
using System.Text;

public class GameGui : MonoBehaviour {

    Monster mon;
    Game game;
    DataIni DI;
    string cardSlot0;
    string cardSlot1;
    string cardSlot2;
    string cardSlot3;
    string cardSlot4;
    string finishWord;    

    void Start()
    {
        mon = GameObject.Find("GameObj").GetComponent<Monster>();
        game = GameObject.Find("GameObj").GetComponent<Game>();
        DI = GameObject.Find("DataObj").GetComponent<DataIni>();
        finishWord = "";
    }

   
    
        void OnGUI()
    {
        var oldcolor = GUI.color;
        cardSlot0 = mon.charData2[game.cardSlot[0], 1];
        cardSlot1 = mon.charData2[game.cardSlot[1], 1];
        cardSlot2 = mon.charData2[game.cardSlot[2], 1];
        cardSlot3 = mon.charData2[game.cardSlot[3], 1];
        cardSlot4 = mon.charData2[game.cardSlot[4], 1];

        if (game.checkremainTurncardslot[0] == false || game.remainturncardslot[0] == 0)
        {
            GUI.color = new Color32(255, 127, 0, 255);
            if (GUI.Button(new Rect(10, 10, 150, 100), cardSlot0))
            {
                game.checkremainTurncardslot[0] = !game.checkremainTurncardslot[0];
            }
        }
        else
        {
            GUI.color = oldcolor;
            if (GUI.Button(new Rect(10, 10, 150, 100), cardSlot0))
            {
                game.checkremainTurncardslot[0] = !game.checkremainTurncardslot[0];
            }

        }

        if (game.checkremainTurncardslot[1] == false || game.remainturncardslot[1] == 0)
        {
            GUI.color = new Color32(255, 127, 0, 255);
            if (GUI.Button(new Rect(160, 10, 150, 100), cardSlot1))
            {
                game.checkremainTurncardslot[1] = !game.checkremainTurncardslot[1];
            }

        }
        else
        {
            GUI.color = oldcolor;
            if (GUI.Button(new Rect(160, 10, 150, 100), cardSlot1))
            {
                game.checkremainTurncardslot[1] = !game.checkremainTurncardslot[1];
            }

        }

        if (game.checkremainTurncardslot[2] == false || game.remainturncardslot[2] == 0)
        {
            GUI.color = new Color32(255, 127, 0, 255);
            if (GUI.Button(new Rect(310, 10, 150, 100), cardSlot2))
            {
                game.checkremainTurncardslot[2] = !game.checkremainTurncardslot[2];
            }

        }
        else
        {
            GUI.color = oldcolor;
            if (GUI.Button(new Rect(310, 10, 150, 100), cardSlot2))
            {
                game.checkremainTurncardslot[2] = !game.checkremainTurncardslot[2];
            }

        }

        if (game.checkremainTurncardslot[3] == false || game.remainturncardslot[3] == 0)
        {
            GUI.color = new Color32(255, 127, 0, 255);
            if (GUI.Button(new Rect(460, 10, 150, 100), cardSlot3))
            {
                game.checkremainTurncardslot[3] = !game.checkremainTurncardslot[3];
            }

        }
        else
        {
            GUI.color = oldcolor;
            if (GUI.Button(new Rect(460, 10, 150, 100), cardSlot3))
            {
                game.checkremainTurncardslot[3] = !game.checkremainTurncardslot[3];
            }

        }

        if (game.checkremainTurncardslot[4] == false || game.remainturncardslot[4] == 0)
        {
            GUI.color = new Color32(255, 127, 0, 255);
            if (GUI.Button(new Rect(610, 10, 150, 100), cardSlot4))
            {
                game.checkremainTurncardslot[4] = !game.checkremainTurncardslot[4];
            }

        }
        else
        {
            GUI.color = oldcolor;
            if (GUI.Button(new Rect(610, 10, 150, 100), cardSlot4))
            {
                game.checkremainTurncardslot[4] = !game.checkremainTurncardslot[4];
            }

        }
        

        if (game.madeSlotList.Count != 0)
        {
            //mon = GameObject.Find("GameObj").GetComponent<Monster>();
            StringBuilder str0 = new StringBuilder();
            str0.Append(mon.unitData2[game.madeSlotList[0], 1]);
            str0.Append(" : ");
            str0.Append(mon.unitData2[game.madeSlotList[0], 9]);
            str0.Append(" ");
            str0.Append(mon.unitData2[game.madeSlotList[0], 10]);
            str0.Append(" ");
            str0.Append(mon.unitData2[game.madeSlotList[0], 11]);
            str0.Append(" ");
            str0.Append(mon.unitData2[game.madeSlotList[0], 12]);
            str0.Append(" ");
            str0.Append(mon.unitData2[game.madeSlotList[0], 13]);

            //Debug.Log(mon.unitData2[game.madeSlotList[0] + 1, 1]);
            //string aa = Convert.ToString(game.madeSlotList[0]);
            GUI.color = Color.green;
            if (GUI.Button(new Rect(10, 350, 750, 40), str0.ToString()))
            {                
                game.score = game.score + 100;
                game.PassTurnWithMake(game.madeSlotList[0]);
            }
        }

        if (game.madeSlotList.Count > 1)
        {
            //mon = GameObject.Find("GameObj").GetComponent<Monster>();
            StringBuilder str1 = new StringBuilder();
            str1.Append(mon.unitData2[game.madeSlotList[1], 1]);
            str1.Append(" : ");
            str1.Append(mon.unitData2[game.madeSlotList[1], 9]);
            str1.Append(" ");
            str1.Append(mon.unitData2[game.madeSlotList[1], 10]);
            str1.Append(" ");
            str1.Append(mon.unitData2[game.madeSlotList[1], 11]);
            str1.Append(" ");
            str1.Append(mon.unitData2[game.madeSlotList[1], 12]);
            str1.Append(" ");
            str1.Append(mon.unitData2[game.madeSlotList[1], 13]);

            //Debug.Log(mon.unitData2[game.madeSlotList[0] + 1, 1]);
            //string aa = Convert.ToString(game.madeSlotList[0]);
            if (GUI.Button(new Rect(10, 400, 750, 40), str1.ToString()))
            {
                game.score = game.score + 100;
                game.PassTurnWithMake(game.madeSlotList[1]);
            }
        }

        if (game.madeSlotList.Count > 2)
        {
            //mon = GameObject.Find("GameObj").GetComponent<Monster>();
            StringBuilder str2 = new StringBuilder();
            str2.Append(mon.unitData2[game.madeSlotList[2], 1]);
            str2.Append(" : ");
            str2.Append(mon.unitData2[game.madeSlotList[2], 9]);
            str2.Append(" ");
            str2.Append(mon.unitData2[game.madeSlotList[2], 10]);
            str2.Append(" ");
            str2.Append(mon.unitData2[game.madeSlotList[2], 11]);
            str2.Append(" ");
            str2.Append(mon.unitData2[game.madeSlotList[2], 12]);
            str2.Append(" ");
            str2.Append(mon.unitData2[game.madeSlotList[2], 13]);

            //Debug.Log(mon.unitData2[game.madeSlotList[0] + 1, 1]);
            //string aa = Convert.ToString(game.madeSlotList[0]);
            if (GUI.Button(new Rect(10, 450, 750, 40), str2.ToString()))
            {
                game.score = game.score + 100;
                game.PassTurnWithMake(game.madeSlotList[2]);
            }

        }

        if (game.madeSlotList.Count > 3)
        {
            //mon = GameObject.Find("GameObj").GetComponent<Monster>();
            StringBuilder str3 = new StringBuilder();
            str3.Append(mon.unitData2[game.madeSlotList[3], 1]);
            str3.Append(" : ");
            str3.Append(mon.unitData2[game.madeSlotList[3], 9]);
            str3.Append(" ");
            str3.Append(mon.unitData2[game.madeSlotList[3], 10]);
            str3.Append(" ");
            str3.Append(mon.unitData2[game.madeSlotList[3], 11]);
            str3.Append(" ");
            str3.Append(mon.unitData2[game.madeSlotList[3], 12]);
            str3.Append(" ");
            str3.Append(mon.unitData2[game.madeSlotList[3], 13]);

            //Debug.Log(mon.unitData2[game.madeSlotList[0] + 1, 1]);
            //string aa = Convert.ToString(game.madeSlotList[0]);
            if (GUI.Button(new Rect(10, 500, 750, 40), str3.ToString()))
            {
                game.score = game.score + 100;
                game.PassTurnWithMake(game.madeSlotList[3]);
            }

        }

        if (game.madeSlotList.Count > 4)
        {
            //mon = GameObject.Find("GameObj").GetComponent<Monster>();
            StringBuilder str4 = new StringBuilder();
            str4.Append(mon.unitData2[game.madeSlotList[4], 1]);
            str4.Append(" : ");
            str4.Append(mon.unitData2[game.madeSlotList[4], 9]);
            str4.Append(" ");
            str4.Append(mon.unitData2[game.madeSlotList[4], 10]);
            str4.Append(" ");
            str4.Append(mon.unitData2[game.madeSlotList[4], 11]);
            str4.Append(" ");
            str4.Append(mon.unitData2[game.madeSlotList[4], 12]);
            str4.Append(" ");
            str4.Append(mon.unitData2[game.madeSlotList[4], 13]);

            //Debug.Log(mon.unitData2[game.madeSlotList[0] + 1, 1]);
            //string aa = Convert.ToString(game.madeSlotList[0]);
            if (GUI.Button(new Rect(10, 550, 750, 40), str4.ToString()))
            {
                game.score = game.score + 100;
                game.PassTurnWithMake(game.madeSlotList[4]);
            }

        }

        if (game.madeSlotList.Count > 5)
        {
            //mon = GameObject.Find("GameObj").GetComponent<Monster>();
            StringBuilder str5 = new StringBuilder();
            str5.Append(mon.unitData2[game.madeSlotList[5], 1]);
            str5.Append(" : ");
            str5.Append(mon.unitData2[game.madeSlotList[5], 9]);
            str5.Append(" ");
            str5.Append(mon.unitData2[game.madeSlotList[5], 10]);
            str5.Append(" ");
            str5.Append(mon.unitData2[game.madeSlotList[5], 11]);
            str5.Append(" ");
            str5.Append(mon.unitData2[game.madeSlotList[5], 12]);
            str5.Append(" ");
            str5.Append(mon.unitData2[game.madeSlotList[5], 13]);

            //Debug.Log(mon.unitData2[game.madeSlotList[0] + 1, 1]);
            //string aa = Convert.ToString(game.madeSlotList[0]);
            if (GUI.Button(new Rect(10, 600, 750, 40), str5.ToString()))
            {
                game.score = game.score + 100;
                game.PassTurnWithMake(game.madeSlotList[5]);
            }
        }

        if (game.madeSlotList.Count > 6)
        {
            //mon = GameObject.Find("GameObj").GetComponent<Monster>();
            StringBuilder str6 = new StringBuilder();
            str6.Append(mon.unitData2[game.madeSlotList[6], 1]);
            str6.Append(" : ");
            str6.Append(mon.unitData2[game.madeSlotList[6], 9]);
            str6.Append(" ");
            str6.Append(mon.unitData2[game.madeSlotList[6], 10]);
            str6.Append(" ");
            str6.Append(mon.unitData2[game.madeSlotList[6], 11]);
            str6.Append(" ");
            str6.Append(mon.unitData2[game.madeSlotList[6], 12]);
            str6.Append(" ");
            str6.Append(mon.unitData2[game.madeSlotList[6], 13]);

            //Debug.Log(mon.unitData2[game.madeSlotList[0] + 1, 1]);
            //string aa = Convert.ToString(game.madeSlotList[0]);
            if (GUI.Button(new Rect(10, 600, 750, 40), str6.ToString()))
            {
                game.score = game.score + 100;
                game.PassTurnWithMake(game.madeSlotList[6]);
            }
        }

        //if (game.madeSlotList.Count > 4)
        //{
        //     thirdcheck = true;

        //}

        if (game.madeSlotList.Count > 6 && game.thirdcheck == false)
        {
            game.thirdcheck = true;
            Debug.Log(game.madeSlotList.Count);
            for (int i = 6; i < game.madeSlotList.Count; i++)
            {
                Debug.Log(mon.unitData2[game.madeSlotList[i], 1]);
            }

        }

        if (game.checkremainTurncardslot[0] == false || game.remainturncardslot[0] == 0
            || game.checkremainTurncardslot[1] == false || game.remainturncardslot[1] == 0
            || game.checkremainTurncardslot[2] == false || game.remainturncardslot[2] == 0
            || game.checkremainTurncardslot[3] == false || game.remainturncardslot[3] == 0
            || game.checkremainTurncardslot[4] == false || game.remainturncardslot[4] == 0)
        {
            GUI.color = oldcolor;
            if (Input.GetKey(KeyCode.A) || GUI.Button(new Rect(280, 200, 250, 100), "버튼을 누르면 다음 턴이 진행됩니다." + "\n 변경할 멤버를 더 고를 수 있습니다."))
            {
                if (game.thirdcheck == false)
                {
                    game.madeSlotList.Clear();
                    game.secondcheck = false;
                }
            }
        }
        else
        {
            GUI.color = Color.red;
            GUI.Button(new Rect(280, 200, 250, 100), "변경할 멤버를 고르세요.");
        }

        //if (Input.GetKey(KeyCode.E))
        //{
        //    game.score = game.score + 100;
        //}

        if (Input.GetKey(KeyCode.W))
        {
            if (game.madeSlotList.Count != 0)
            {
                game.score = game.score + 100;
                game.PassTurnWithMake(game.madeSlotList[0]);
            }
            else
            {
                game.checkremainTurncardslot[0] = false;
                if (game.thirdcheck == false)
                {
                    game.madeSlotList.Clear();
                    game.secondcheck = false;
                }
            }
            
        }

        if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.T) && Input.GetKey(KeyCode.Y))
        {
            DI.DataReset();
            game.score = DI.GetExp();
            game.level = DI.GetLV();
            if (DI.GetBasicRemainTurn() != 0)
            {
                game.basicRemainTurn = DI.GetBasicRemainTurn();
            }

            game.maxCombo = DI.GetMaxCombo();
            game.checkExp();
            Debug.Log("Game Data Reset" + game.score);
        }

        GUI.color = oldcolor;

        int requireLevelup = Convert.ToInt32(mon.expLvData2[game.level + 1, 2]) - game.score;

        GUI.color = new Color32(255, 220, 55, 255);
        GUI.Button(new Rect(100, 200, 150, 100), "Score : " + game.score + " (" + requireLevelup + ") "+  "\n Level : " + game.level + "\n MaxCombo : " + game.maxCombo);

        
        if (game.combocount != 0)
        {
            GUI.Button(new Rect(560, 200, 200, 100), "ComboCount : " + game.combocount + " " + finishWord);
        }
        GUI.color = oldcolor;


        if (game.madeSlotList.Count == 0)
        {
            finishWord = "Done!";
        }
        else
        {
            finishWord = "";
        }


        if (game.thirdcheck == true)
        {
            if (GUI.Button(new Rect(500, 200, 150, 100), "Restart!"))
            {
                Application.LoadLevel(Application.loadedLevel);

            }
        }


        if (game.remainturncardslot[0] == 0)
        {
            GUI.color = Color.red;
            GUI.Box(new Rect(10, 120, 150, 25), "남은 턴 : " + game.remainturncardslot[0]);
        }
        else
        {
            GUI.color = oldcolor;
            GUI.Box(new Rect(10, 120, 150, 25), "남은 턴 : " + game.remainturncardslot[0]);
        }

        if (game.remainturncardslot[1] == 0)
        {
            GUI.color = Color.red;
            GUI.Box(new Rect(160, 120, 150, 25), "남은 턴 : " + game.remainturncardslot[1]);
        }
        else
        {
            GUI.color = oldcolor;
            GUI.Box(new Rect(160, 120, 150, 25), "남은 턴 : " + game.remainturncardslot[1]);
        }

        if (game.remainturncardslot[2] == 0)
        {
            GUI.color = Color.red;
            GUI.Box(new Rect(310, 120, 150, 25), "남은 턴 : " + game.remainturncardslot[2]);
        }
        else
        {
            GUI.color = oldcolor;
            GUI.Box(new Rect(310, 120, 150, 25), "남은 턴 : " + game.remainturncardslot[2]);
        }

        if (game.remainturncardslot[3] == 0)
        {
            GUI.color = Color.red;
            GUI.Box(new Rect(460, 120, 150, 25), "남은 턴 : " + game.remainturncardslot[3]);
        }
        else
        {
            GUI.color = oldcolor;
            GUI.Box(new Rect(460, 120, 150, 25), "남은 턴 : " + game.remainturncardslot[3]);
        }

        if (game.remainturncardslot[4] == 0)
        {
            GUI.color = Color.red;
            GUI.Box(new Rect(610, 120, 150, 25), "남은 턴 : " + game.remainturncardslot[4]);
        }
        else
        {
            GUI.color = oldcolor;
            GUI.Box(new Rect(610, 120, 150, 25), "남은 턴 : " + game.remainturncardslot[4]);
        }
        

    }
}
