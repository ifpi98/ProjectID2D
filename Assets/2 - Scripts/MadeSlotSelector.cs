using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.UI;

public class MadeSlotSelector : MonoBehaviour {

    Game game;
    Monster mon;
    GameCanvasGui gCanvas;
    //ColorBlock defaultCB;
    ColorBlock selectedCB;
    ColorBlock notYetDebutCB;    

    // Use this for initialization
    void Start () {

        game = GameObject.Find("GameObj").GetComponent<Game>();
        mon = GameObject.Find("GameObj").GetComponent<Monster>();
        gCanvas = GameObject.Find("UIObj").GetComponent<GameCanvasGui>();
        selectedCB.normalColor = new Color32(100, 233, 115, 200);
        selectedCB.highlightedColor = new Color32(100, 233, 115, 200);
        selectedCB.pressedColor = new Color32(100, 233, 115, 200);
        selectedCB.disabledColor = new Color32(100, 233, 115, 200);
        selectedCB.colorMultiplier = 1;
        selectedCB.fadeDuration = 0.1f;

        notYetDebutCB.normalColor = new Color32(0, 255, 0, 255);
        notYetDebutCB.highlightedColor = new Color32(0, 255, 0, 255);
        notYetDebutCB.pressedColor = new Color32(0, 255, 0, 255);
        notYetDebutCB.disabledColor = new Color32(0, 255, 0, 255);
        notYetDebutCB.colorMultiplier = 1;
        notYetDebutCB.fadeDuration = 0.1f;
        
        //for (int i = 0; i < 6; i++)
        //{
        //    gCanvas.madeSlotButton[0].colors = selectedCB;
        //}
        

    }
	
	// Update is called once per frame
	void Update () {
                
        MadeSlotButtonTextRefresh();        
    }

    void MadeSlotButtonTextRefresh()
    {
        for (int i = 0; i < game.madeSlotList.Count; i++)
        {
            madeSlotText(i);
        }

        for (int i = 0; i < game.madeSlotList.Count; i++)
        {
            gCanvas.madeSlot[i].SetActive(true);
        }

        for (int i = game.madeSlotList.Count; i < 8; i++)
        {
            gCanvas.madeSlot[i].SetActive(false);
        }

        if (game.madeSlotList.Count > 8)
        {
            Debug.LogWarning("There are Nine or More MADESLOT! Check it!");
        }
        
        
        //switch (game.madeSlotList.Count)
        //{
        //    case 0:
        //        //Debug.LogWarning("Logical Error! Check!");         
        //        gCanvas.madeSlot[0].SetActive(false);
        //        gCanvas.madeSlot[1].SetActive(false);
        //        gCanvas.madeSlot[2].SetActive(false);
        //        gCanvas.madeSlot[3].SetActive(false);
        //        gCanvas.madeSlot[4].SetActive(false);
        //        gCanvas.madeSlot[5].SetActive(false);
        //        break;

        //    case 1:

        //        gCanvas.madeSlot[0].SetActive(true);
        //        gCanvas.madeSlot[1].SetActive(false);
        //        gCanvas.madeSlot[2].SetActive(false);
        //        gCanvas.madeSlot[3].SetActive(false);
        //        gCanvas.madeSlot[4].SetActive(false);
        //        gCanvas.madeSlot[5].SetActive(false);
        //        break;

        //    case 2:

        //        gCanvas.madeSlot[0].SetActive(true);
        //        gCanvas.madeSlot[1].SetActive(true);
        //        gCanvas.madeSlot[2].SetActive(false);
        //        gCanvas.madeSlot[3].SetActive(false);
        //        gCanvas.madeSlot[4].SetActive(false);
        //        gCanvas.madeSlot[5].SetActive(false);
        //        break;

        //    case 3:

        //        gCanvas.madeSlot[0].SetActive(true);
        //        gCanvas.madeSlot[1].SetActive(true);
        //        gCanvas.madeSlot[2].SetActive(true);
        //        gCanvas.madeSlot[3].SetActive(false);
        //        gCanvas.madeSlot[4].SetActive(false);
        //        gCanvas.madeSlot[5].SetActive(false);
        //        break;

        //    case 4:

        //        gCanvas.madeSlot[0].SetActive(true);
        //        gCanvas.madeSlot[1].SetActive(true);
        //        gCanvas.madeSlot[2].SetActive(true);
        //        gCanvas.madeSlot[3].SetActive(true);
        //        gCanvas.madeSlot[4].SetActive(false);
        //        gCanvas.madeSlot[5].SetActive(false);
        //        break;
                
        //    case 5:

        //        gCanvas.madeSlot[0].SetActive(true);
        //        gCanvas.madeSlot[1].SetActive(true);
        //        gCanvas.madeSlot[2].SetActive(true);
        //        gCanvas.madeSlot[3].SetActive(true);
        //        gCanvas.madeSlot[4].SetActive(true);
        //        gCanvas.madeSlot[5].SetActive(false);
        //        break;

        //    case 6:

        //        gCanvas.madeSlot[0].SetActive(true);
        //        gCanvas.madeSlot[1].SetActive(true);
        //        gCanvas.madeSlot[2].SetActive(true);
        //        gCanvas.madeSlot[3].SetActive(true);
        //        gCanvas.madeSlot[4].SetActive(true);
        //        gCanvas.madeSlot[5].SetActive(true);
        //        break;

        //    default:
        //        Debug.LogWarning("There are Seven or More MADESLOT! Check it!");
        //        gCanvas.madeSlot[0].SetActive(true);
        //        gCanvas.madeSlot[1].SetActive(true);
        //        gCanvas.madeSlot[2].SetActive(true);
        //        gCanvas.madeSlot[3].SetActive(true);
        //        gCanvas.madeSlot[4].SetActive(true);
        //        gCanvas.madeSlot[5].SetActive(true);
        //        break;

        //}
        

    }


    void madeSlotText(int madeslot)
    {
        StringBuilder str = new StringBuilder();

        if (game.unitDebutHistory[game.madeSlotList[madeslot]])
        {
            str.Append(mon.unitData2[game.madeSlotList[madeslot], 1]);
            gCanvas.madeSlotButton[madeslot].colors = selectedCB;
            
        }
        else
        {
            str.Append("?아직 데뷰하지 않은 유닛?");
            gCanvas.madeSlotButton[madeslot].colors = notYetDebutCB;
            
        }
        str.Append(" : ");
        str.Append(mon.unitData2[game.madeSlotList[madeslot], 9]);
        str.Append(" ");
        str.Append(mon.unitData2[game.madeSlotList[madeslot], 10]);
        str.Append(" ");
        str.Append(mon.unitData2[game.madeSlotList[madeslot], 11]);
        str.Append(" ");
        str.Append(mon.unitData2[game.madeSlotList[madeslot], 12]);
        str.Append(" ");
        str.Append(mon.unitData2[game.madeSlotList[madeslot], 13]);
        
        gCanvas.madeSlotButtonText[madeslot].text = str.ToString();        
   
    }    

    public void MadeSlotDecide(int a)
    {        
        game.PassTurnWithMake(game.madeSlotList[a]);
                
    }
    


}
