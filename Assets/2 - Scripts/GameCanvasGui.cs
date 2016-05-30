using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameCanvasGui : MonoBehaviour
{
    Monster mon;
    Game game;
    DataIni DI;

    string[] cardSlot;
    string finishWord;

    public Button mButton0;
    public Button mButton1;
    public Button mButton2;
    public Button mButton3;
    public Button mButton4;

    public Text mButText0;
    public Text mButText1;
    public Text mButText2;
    public Text mButText3;
    public Text mButText4;
    

    //Canvas gameCanvas;


    // Use this for initialization
    void Start()
    {
        mon = GameObject.Find("GameObj").GetComponent<Monster>();
        game = GameObject.Find("GameObj").GetComponent<Game>();
        DI = GameObject.Find("DataObj").GetComponent<DataIni>();
                
        finishWord = "";
        cardSlot = new string[5];

        mButton0 = GameObject.Find("Member Button 0").GetComponent<Button>();
        mButText0 = mButton0.GetComponentInChildren<Text>();
        mButton1 = GameObject.Find("Member Button 1").GetComponent<Button>();
        mButText1 = mButton1.GetComponentInChildren<Text>();
        mButton2 = GameObject.Find("Member Button 2").GetComponent<Button>();
        mButText2 = mButton2.GetComponentInChildren<Text>();
        mButton3 = GameObject.Find("Member Button 3").GetComponent<Button>();
        mButText3 = mButton3.GetComponentInChildren<Text>();
        mButton4 = GameObject.Find("Member Button 4").GetComponent<Button>();
        mButText4 = mButton4.GetComponentInChildren<Text>();
    }

    void Update()
    {

        TextRefresh();      
        
    }

    void TextRefresh()
    {

        for (int i = 0; i < 5; i++)
        {
            cardSlot[i] = mon.charData2[game.cardSlot[i], 1] + "\n(" + mon.charData2[game.cardSlot[i], 3] + ")";                                    
        }

        mButText0.text = cardSlot[0];
        mButText1.text = cardSlot[1];
        mButText2.text = cardSlot[2];
        mButText3.text = cardSlot[3];
        mButText4.text = cardSlot[4];
    }

    

}



