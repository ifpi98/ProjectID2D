using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Unit2 : MonoBehaviour
{
    Game game;
    GameCanvasGui gCanvas;
    public Text Label;
    public int instanceCharID;

    void Start()
    {
        game = GameObject.Find("GameObj").GetComponent<Game>();
        gCanvas = GameObject.Find("UIObj").GetComponent<GameCanvasGui>();
    }

    public void CharDescription()
    {
        //Debug.Log(instanceCharID);
        //Debug.Log(game.madeSlotCount);
        gCanvas.CharDescription(instanceCharID);
    }

}
