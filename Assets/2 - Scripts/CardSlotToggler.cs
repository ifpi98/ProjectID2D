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

    Outline[] oLCardSlot;    

    // Use this for initialization
    void Start() {

        game = GameObject.Find("GameObj").GetComponent<Game>();
        mon = GameObject.Find("GameObj").GetComponent<Monster>();
        gCanvas = GameObject.Find("UIObj").GetComponent<GameCanvasGui>();

        oLCardSlot = new Outline[5];

        defaultCB = gCanvas.mButton[0].colors;

        selectedCB.normalColor = new Color32(255, 127, 0, 255);
        selectedCB.highlightedColor = new Color32(255, 127, 0, 255);
        selectedCB.pressedColor = new Color32(255, 127, 0, 255);
        selectedCB.disabledColor = new Color32(255, 127, 0, 255);
        selectedCB.colorMultiplier = 1;
        selectedCB.fadeDuration = 0.1f;

        for (int i = 0; i < 5; i++)
        {
            oLCardSlot[i] = gCanvas.mButText[i].GetComponent<Outline>();
        }
        
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
    void Update()
    {

        for (int i = 0; i < 5; i++)
        {
            ButtonAndTextColor(i);
        }

    }


    void ButtonAndTextColor(int cardslot)
    {
        if (game.remainturncardslot[cardslot] == 0 || !game.checkremainTurncardslot[cardslot])
        {
            gCanvas.mButton[cardslot].colors = selectedCB;
            gCanvas.mButText[cardslot].color = Color.black;
            oLCardSlot[cardslot].effectColor = Color.black;
        }
        else
        {
            gCanvas.mButton[cardslot].colors = defaultCB;

            cardTypeColor = ShadowCardType(cardslot);
            gCanvas.mButText[cardslot].color = cardTypeColor;
            oLCardSlot[cardslot].effectColor = cardTypeColor;
            
        }
    }



    Color32 ShadowCardType(int cardnumber)
    {
        Color32 tempColor;

        switch (mon.charData2[game.cardSlot[cardnumber], 3])
        {
            case "Cute":
                tempColor = new Color32(255, 64, 255, 255);
                return tempColor;                

            case "Cool":
                tempColor = new Color32(46, 154, 254, 255);
                return tempColor;                

            case "Passion":
                tempColor = new Color32(255, 126, 0, 255);
                return tempColor;                

            default:
                Debug.LogWarning("Maybe, there is a data error!");                
                break;
        }

        Debug.LogWarning("Maybe, there is a data error!");
        tempColor = new Color32(0, 0, 0, 255);
        return tempColor;
    }

}
