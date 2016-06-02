using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextTurn : MonoBehaviour {

    Game game;
    GameCanvasGui gCanvas;
    ColorBlock defaultCB;
    ColorBlock selectedCB;

    // Use this for initialization
    void Start () {

        game = GameObject.Find("GameObj").GetComponent<Game>();
        gCanvas = GameObject.Find("UIObj").GetComponent<GameCanvasGui>();

        defaultCB = gCanvas.nTurnButton.colors;
        selectedCB.normalColor = new Color32(255, 127, 0, 255);
        selectedCB.highlightedColor = new Color32(255, 127, 0, 255);
        selectedCB.pressedColor = new Color32(255, 127, 0, 255);
        selectedCB.disabledColor = new Color32(255, 127, 0, 255);
        selectedCB.colorMultiplier = 1;
        selectedCB.fadeDuration = 0.1f;

    }

    public void TabNextTurn()
    {
        if (game.checkremainTurncardslot[0] == false || game.remainturncardslot[0] == 0
           || game.checkremainTurncardslot[1] == false || game.remainturncardslot[1] == 0
           || game.checkremainTurncardslot[2] == false || game.remainturncardslot[2] == 0
           || game.checkremainTurncardslot[3] == false || game.remainturncardslot[3] == 0
           || game.checkremainTurncardslot[4] == false || game.remainturncardslot[4] == 0)
        {
            if (game.thirdcheck == false)
            {
                game.madeSlotList.Clear();
                game.secondcheck = false;
            }
        }
        else
        {
            
        }        
    }



    // Update is called once per frame
    void Update () {

        if (game.checkremainTurncardslot[0] == false || game.remainturncardslot[0] == 0
           || game.checkremainTurncardslot[1] == false || game.remainturncardslot[1] == 0
           || game.checkremainTurncardslot[2] == false || game.remainturncardslot[2] == 0
           || game.checkremainTurncardslot[3] == false || game.remainturncardslot[3] == 0
           || game.checkremainTurncardslot[4] == false || game.remainturncardslot[4] == 0)
        {
            gCanvas.nTurnButton.colors = selectedCB;
            gCanvas.nTurnButText.text = "버튼을 누르면 다음 턴이 진행됩니다." + "\n 변경할 멤버를 더 고를 수 있습니다.";
        }
        else
        {
            gCanvas.nTurnButton.colors = defaultCB;
            gCanvas.nTurnButText.text = "변경할 멤버를 고르세요.";
        }
                        
    }
}
