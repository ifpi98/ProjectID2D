using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardSlotToggler : MonoBehaviour {

    Game game;
    GameCanvasGui gCanvas;
    ColorBlock defaultCB;
    ColorBlock selectedCB;

    // Use this for initialization
    void Start () {

        game = GameObject.Find("GameObj").GetComponent<Game>();
        gCanvas = GameObject.Find("UIObj").GetComponent<GameCanvasGui>();

        defaultCB = gCanvas.mButton0.colors;
        selectedCB.normalColor = new Color32(255, 127, 0, 255);
        selectedCB.highlightedColor = new Color32(255, 127, 0, 255);
        selectedCB.pressedColor = new Color32(255, 127, 0, 255);
        selectedCB.disabledColor = new Color32(255, 127, 0, 255);
        selectedCB.colorMultiplier = 1;
        selectedCB.fadeDuration = 0.1f;

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
        }
        else
        {
            gCanvas.mButton0.colors = defaultCB;
        }

        if (game.remainturncardslot[1] == 0 || !game.checkremainTurncardslot[1])
        {
            gCanvas.mButton1.colors = selectedCB;
        }
        else
        {
            gCanvas.mButton1.colors = defaultCB;
        }

        if (game.remainturncardslot[2] == 0 || !game.checkremainTurncardslot[2])        
        {
            gCanvas.mButton2.colors = selectedCB;
        }
        else
        {
            gCanvas.mButton2.colors = defaultCB;
        }

        if (game.remainturncardslot[3] == 0 || !game.checkremainTurncardslot[3])        
        {
            gCanvas.mButton3.colors = selectedCB;
        }
        else
        {
            gCanvas.mButton3.colors = defaultCB;
        }

        if (game.remainturncardslot[4] == 0 || !game.checkremainTurncardslot[4])        
        {
            gCanvas.mButton4.colors = selectedCB;
        }
        else
        {
            gCanvas.mButton4.colors = defaultCB;
        }
    }
}
