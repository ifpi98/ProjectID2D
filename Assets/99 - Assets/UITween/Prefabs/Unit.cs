using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Unit : MonoBehaviour
{
    Game game;
    GameCanvasGui gCanvas;
    public Text Label;
    public int instanceUnitID;

    void Start()
    {
        game = GameObject.Find("GameObj").GetComponent<Game>();
        gCanvas = GameObject.Find("UIObj").GetComponent<GameCanvasGui>();
    }


    public void UnitDescription()
    {
        Debug.Log(instanceUnitID);
        Debug.Log(game.madeSlotCount);
        gCanvas.UnitDescription(instanceUnitID);
    }
}
