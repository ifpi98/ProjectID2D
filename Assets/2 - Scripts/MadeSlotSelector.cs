using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.UI;

public class MadeSlotSelector : MonoBehaviour {

    Game game;
    Monster mon;
    GameCanvasGui gCanvas;
    ColorBlock defaultCB;
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

        gCanvas.madeSlotButton0.colors = selectedCB;
        gCanvas.madeSlotButton1.colors = selectedCB;
        gCanvas.madeSlotButton2.colors = selectedCB;
        gCanvas.madeSlotButton3.colors = selectedCB;
        gCanvas.madeSlotButton4.colors = selectedCB;
        gCanvas.madeSlotButton5.colors = selectedCB;

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

        switch (game.madeSlotList.Count)
        {
            case 0:
                Debug.LogWarning("Logical Error! Check!");
                gCanvas.madeSlot0.SetActive(false);
                gCanvas.madeSlot1.SetActive(false);
                gCanvas.madeSlot2.SetActive(false);
                gCanvas.madeSlot3.SetActive(false);
                gCanvas.madeSlot4.SetActive(false);
                gCanvas.madeSlot5.SetActive(false);
                break;

            case 1:

                gCanvas.madeSlot0.SetActive(true);
                gCanvas.madeSlot1.SetActive(false);
                gCanvas.madeSlot2.SetActive(false);
                gCanvas.madeSlot3.SetActive(false);
                gCanvas.madeSlot4.SetActive(false);
                gCanvas.madeSlot5.SetActive(false);                                        
                break;

            case 2:

                gCanvas.madeSlot0.SetActive(true);
                gCanvas.madeSlot1.SetActive(true);
                gCanvas.madeSlot2.SetActive(false);
                gCanvas.madeSlot3.SetActive(false);
                gCanvas.madeSlot4.SetActive(false);
                gCanvas.madeSlot5.SetActive(false);
                break;

            case 3:

                gCanvas.madeSlot0.SetActive(true);
                gCanvas.madeSlot1.SetActive(true);
                gCanvas.madeSlot2.SetActive(true);
                gCanvas.madeSlot3.SetActive(false);
                gCanvas.madeSlot4.SetActive(false);
                gCanvas.madeSlot5.SetActive(false);
                break;

            case 4:

                gCanvas.madeSlot0.SetActive(true);
                gCanvas.madeSlot1.SetActive(true);
                gCanvas.madeSlot2.SetActive(true);
                gCanvas.madeSlot3.SetActive(true);
                gCanvas.madeSlot4.SetActive(false);
                gCanvas.madeSlot5.SetActive(false);
                break;
                
            case 5:

                gCanvas.madeSlot0.SetActive(true);
                gCanvas.madeSlot1.SetActive(true);
                gCanvas.madeSlot2.SetActive(true);
                gCanvas.madeSlot3.SetActive(true);
                gCanvas.madeSlot4.SetActive(true);
                gCanvas.madeSlot5.SetActive(false);
                break;

            case 6:

                gCanvas.madeSlot0.SetActive(true);
                gCanvas.madeSlot1.SetActive(true);
                gCanvas.madeSlot2.SetActive(true);
                gCanvas.madeSlot3.SetActive(true);
                gCanvas.madeSlot4.SetActive(true);
                gCanvas.madeSlot5.SetActive(true);
                break;

            default:
                Debug.LogWarning("There are Seven or More MADESLOT! Check it!");
                gCanvas.madeSlot0.SetActive(true);
                gCanvas.madeSlot1.SetActive(true);
                gCanvas.madeSlot2.SetActive(true);
                gCanvas.madeSlot3.SetActive(true);
                gCanvas.madeSlot4.SetActive(true);
                gCanvas.madeSlot5.SetActive(true);
                break;

        }
        

    }


    void madeSlotText(int madeslot)
    {
        StringBuilder str = new StringBuilder();

        if (game.unitDebutHistory[game.madeSlotList[madeslot]])
        {
            str.Append(mon.unitData2[game.madeSlotList[madeslot], 1]);

            switch (madeslot)
            {
                case 0:
                    gCanvas.madeSlotButton0.colors = selectedCB;
                    break;

                case 1:
                    gCanvas.madeSlotButton1.colors = selectedCB;
                    break;

                case 2:
                    gCanvas.madeSlotButton2.colors = selectedCB;
                    break;

                case 3:
                    gCanvas.madeSlotButton3.colors = selectedCB;
                    break;

                case 4:
                    gCanvas.madeSlotButton4.colors = selectedCB;
                    break;

                case 5:
                    gCanvas.madeSlotButton5.colors = selectedCB;
                    break;

                default:
                    Debug.LogWarning("There is seven or more MADESLOT!, Check this!");
                    break;
            }
        }
        else
        {
            switch (madeslot)
            {
                case 0:
                    gCanvas.madeSlotButton0.colors = notYetDebutCB;
                    break;

                case 1:
                    gCanvas.madeSlotButton1.colors = notYetDebutCB;
                    break;

                case 2:
                    gCanvas.madeSlotButton2.colors = notYetDebutCB;
                    break;

                case 3:
                    gCanvas.madeSlotButton3.colors = notYetDebutCB;
                    break;

                case 4:
                    gCanvas.madeSlotButton4.colors = notYetDebutCB;
                    break;

                case 5:
                    gCanvas.madeSlotButton5.colors = notYetDebutCB;
                    break;

                default:
                    Debug.LogWarning("There is seven or more MADESLOT!, Check this!");
                    break;
            }
            
            str.Append("?아직 데뷰하지 않은 유닛?");
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

        switch (madeslot)
        {
            case 0:
                gCanvas.madeSlotButtonText0.text = str.ToString();
                break;

            case 1:
                gCanvas.madeSlotButtonText1.text = str.ToString();
                break;

            case 2:
                gCanvas.madeSlotButtonText2.text = str.ToString();
                break;

            case 3:
                gCanvas.madeSlotButtonText3.text = str.ToString();
                break;

            case 4:
                gCanvas.madeSlotButtonText4.text = str.ToString();
                break;

            case 5:
                gCanvas.madeSlotButtonText5.text = str.ToString();
                break;

            default:
                Debug.LogWarning("There are Seven or More MADESLOT! Check it!");
                break;
        }
                
    }    

    public void MadeSlotDecide(int a)
    {
        game.PassTurnWithMake(game.madeSlotList[a]);        
    }
    


}
