using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;

public class CardSlotToggler : MonoBehaviour {

    Game game;
    Monster mon;
    GameCanvasGui gCanvas;
    ColorBlock defaultCB;
    ColorBlock selectedCB;
    Color32 cardTypeColor;

    Outline oLCardSlot0;
    Outline oLCardSlot1;
    Outline oLCardSlot2;
    Outline oLCardSlot3;
    Outline oLCardSlot4;
    Outline oLCardSlot5;

    // Use this for initialization
    void Start () {

        game = GameObject.Find("GameObj").GetComponent<Game>();
        mon = GameObject.Find("GameObj").GetComponent<Monster>();
        gCanvas = GameObject.Find("UIObj").GetComponent<GameCanvasGui>();

        defaultCB = gCanvas.mButton0.colors;
        selectedCB.normalColor = new Color32(255, 127, 0, 255);
        selectedCB.highlightedColor = new Color32(255, 127, 0, 255);
        selectedCB.pressedColor = new Color32(255, 127, 0, 255);
        selectedCB.disabledColor = new Color32(255, 127, 0, 255);
        selectedCB.colorMultiplier = 1;
        selectedCB.fadeDuration = 0.1f;

        oLCardSlot0 = gCanvas.mButText0.GetComponent<Outline>();
        oLCardSlot1 = gCanvas.mButText1.GetComponent<Outline>();
        oLCardSlot2 = gCanvas.mButText2.GetComponent<Outline>();
        oLCardSlot3 = gCanvas.mButText3.GetComponent<Outline>();
        oLCardSlot4 = gCanvas.mButText4.GetComponent<Outline>();

    }

    

    public void CardSlotToggle(int a)
    {
        if (game.remainturncardslot[a] != 0)
        {   
            {
                game.checkremainTurncardslot[a] = !game.checkremainTurncardslot[a];
            }
        }
    }

	// Update is called once per frame
	void Update () {

        if (game.remainturncardslot[0] == 0 || !game.checkremainTurncardslot[0])        
        {
            gCanvas.mButton0.colors = selectedCB;
            gCanvas.mButText0.color = Color.black;
            oLCardSlot0.effectColor = Color.black;
        }
        else
        {
            gCanvas.mButton0.colors = defaultCB;
        }

        if (game.remainturncardslot[1] == 0 || !game.checkremainTurncardslot[1])
        {
            gCanvas.mButton1.colors = selectedCB;
            gCanvas.mButText1.color = Color.black;
            oLCardSlot1.effectColor = Color.black;
        }
        else
        {
            gCanvas.mButton1.colors = defaultCB;
        }

        if (game.remainturncardslot[2] == 0 || !game.checkremainTurncardslot[2])        
        {
            gCanvas.mButton2.colors = selectedCB;
            gCanvas.mButText2.color = Color.black;
            oLCardSlot2.effectColor = Color.black;
        }
        else
        {
            gCanvas.mButton2.colors = defaultCB;
        }

        if (game.remainturncardslot[3] == 0 || !game.checkremainTurncardslot[3])        
        {
            gCanvas.mButton3.colors = selectedCB;
            gCanvas.mButText3.color = Color.black;
            oLCardSlot3.effectColor = Color.black;
        }
        else
        {
            gCanvas.mButton3.colors = defaultCB;
        }

        if (game.remainturncardslot[4] == 0 || !game.checkremainTurncardslot[4])        
        {
            gCanvas.mButton4.colors = selectedCB;
            gCanvas.mButText4.color = Color.black;
            oLCardSlot4.effectColor = Color.black;
        }
        else
        {
            gCanvas.mButton4.colors = defaultCB;
        }




        for (int i = 0; i < 5; i++)
        {
            if (game.remainturncardslot[i] == 0 || !game.checkremainTurncardslot[i])
            {
            }
            else
            {
                switch (i)
                {
                    case 0:
                        cardTypeColor = ShadowCardType(i);
                        gCanvas.mButText0.color = cardTypeColor;
                        oLCardSlot0.effectColor = cardTypeColor;
                        break;

                    case 1:
                        cardTypeColor = ShadowCardType(i);
                        gCanvas.mButText1.color = cardTypeColor;
                        oLCardSlot1.effectColor = cardTypeColor;
                        break;

                    case 2:
                        cardTypeColor = ShadowCardType(i);
                        gCanvas.mButText2.color = cardTypeColor;
                        oLCardSlot2.effectColor = cardTypeColor;
                        break;

                    case 3:
                        cardTypeColor = ShadowCardType(i);
                        gCanvas.mButText3.color = cardTypeColor;
                        oLCardSlot3.effectColor = cardTypeColor;
                        break;

                    case 4:
                        cardTypeColor = ShadowCardType(i);
                        gCanvas.mButText4.color = cardTypeColor;
                        oLCardSlot4.effectColor = cardTypeColor;
                        break;

                    default:
                        Debug.LogWarning("Logical Error, check it!");
                        break;
                }
            }
            
        }
        
    }

    Color32 ShadowCardType(int i)
    {
        Color32 tempColor;

        switch (mon.charData2[game.cardSlot[i], 3])
        {
            case "Cute":
                tempColor = new Color32(255, 64, 255, 255);
                return tempColor;                

            case "Cool":
                tempColor = new Color32(46, 154, 254, 255);
                return tempColor;
                break;

            case "Passion":
                tempColor = new Color32(255, 126, 0, 255);
                return tempColor;
                break;

            default:
                Debug.LogWarning("Maybe, there is a data error!");
                break;
        }

        Debug.LogWarning("Maybe, there is a data error!");
        tempColor = new Color32(0, 0, 0, 255);
        return tempColor;
    }

}
