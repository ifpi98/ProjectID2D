using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillSelector : MonoBehaviour {

    Game game;
    GameCanvasGui gCanvas;
    ColorBlock condCannotCB;
    ColorBlock condCanCB;
    ColorBlock condUsingCB;


    // Use this for initialization
    void Start () {

        game = GameObject.Find("GameObj").GetComponent<Game>();        
        gCanvas = GameObject.Find("UIObj").GetComponent<GameCanvasGui>();

        condCannotCB.normalColor = new Color32(128, 128, 128, 255);
        condCannotCB.highlightedColor = new Color32(128, 128, 128, 255);
        condCannotCB.pressedColor = new Color32(128, 128, 128, 255);
        condCannotCB.disabledColor = new Color32(128, 128, 128, 255);
        condCannotCB.colorMultiplier = 1;
        condCannotCB.fadeDuration = 0.1f;

        condCanCB.normalColor = new Color32(100, 233, 115, 200);
        condCanCB.highlightedColor = new Color32(100, 233, 115, 200);
        condCanCB.pressedColor = new Color32(100, 233, 115, 200);
        condCanCB.disabledColor = new Color32(100, 233, 115, 200);
        condCanCB.colorMultiplier = 1;
        condCanCB.fadeDuration = 0.1f;

        condUsingCB.normalColor = new Color32(255, 50, 100, 255);
        condUsingCB.highlightedColor = new Color32(255, 50, 100, 255);
        condUsingCB.pressedColor = new Color32(255, 50, 100, 255);
        condUsingCB.disabledColor = new Color32(255, 50, 100, 255);
        condUsingCB.colorMultiplier = 1;
        condUsingCB.fadeDuration = 0.1f;
    }
	
	// Update is called once per frame
	void Update () {

        checkSkill();       
               

    }

    void checkSkill()
    {        
        for (int i = 0; i < 5; i++)
        {
            switch (i)
            {
                case 0:
                    if (game.skillOnCheck[i] != true)
                    {

                        if (game.skillPoint < 100)
                        {
                            gCanvas.skillButton[i].colors = condCannotCB;
                        }
                        else
                        {
                            gCanvas.skillButton[i].colors = condCanCB;
                        }                        
                        gCanvas.skillButtonText[i].text = "Skill : <color=#F000F0FF>Cute(100)</color>" + "\n다음 턴까지 <color=#F000F0FF>Cute</color> 타입 \n아이돌만 등장합니다. ";
                        break;

                    }

                    if (game.skillOnCheck[i] == true)
                    {
                        gCanvas.skillButton[i].colors = condUsingCB;
                        gCanvas.skillButtonText[i].text = "<color=#FF64C8FF>Cute</color> 스킬 발동 중!" + "\n다음 턴까지 <color=#FF64C8FF>Cute</color> 타입 \n아이돌만 등장합니다. ";
                        break;
                    }

                    Debug.LogWarning("Logical Error");
                    break;

                case 1:
                    if (game.skillOnCheck[i] != true)
                    {
                        if (game.skillPoint < 100)
                        {
                            gCanvas.skillButton[i].colors = condCannotCB;
                        }
                        else
                        {
                            gCanvas.skillButton[i].colors = condCanCB;
                        }
                        gCanvas.skillButtonText[i].text = "Skill : <color=#2E9AFEFF>Cool(100)</color>" + "\n다음 턴까지 <color=#2E9AFEFF>Cool</color> 타입 \n아이돌만 등장합니다. ";
                        break;

                    }

                    if (game.skillOnCheck[i] == true)
                    {
                        gCanvas.skillButton[i].colors = condUsingCB;
                        gCanvas.skillButtonText[i].text = "<color=#2E9AFEFF>Cool</color> 스킬 발동 중!" + "\n다음 턴까지 <color=#2E9AFEFF>Cool</color> 타입 \n아이돌만 등장합니다. ";
                        break;
                    }

                    Debug.LogWarning("Logical Error");
                    break;

                case 2:
                    if (game.skillOnCheck[i] != true)
                    {
                        if (game.skillPoint < 100)
                        {
                            gCanvas.skillButton[i].colors = condCannotCB;
                        }
                        else
                        {
                            gCanvas.skillButton[i].colors = condCanCB;
                        }
                        gCanvas.skillButtonText[i].text = "Skill : <color=#FF7E00FF>Passion(100)</color>" + "\n다음 턴까지 <color=#FF7E00FF>Passion</color> 타입 \n아이돌만 등장합니다. ";
                        break;

                    }

                    if (game.skillOnCheck[i] == true)
                    {
                        gCanvas.skillButton[i].colors = condUsingCB;
                        gCanvas.skillButtonText[i].text = "<color=#FF7E00FF>Passion</color> 스킬 발동 중!" + "\n다음 턴까지 <color=#FF7E00FF>Passion</color> 타입 \n아이돌만 등장합니다. ";
                        break;
                    }

                    Debug.LogWarning("Logical Error");
                    break;

                case 3:
                    if (game.skillOnCheck[i] != true)
                    {
                        if (game.skillPoint < 300)
                        {
                            gCanvas.skillButton[i].colors = condCannotCB;
                        }
                        else
                        {
                            gCanvas.skillButton[i].colors = condCanCB;
                        }
                        gCanvas.skillButtonText[i].text = "Skill : Sixteen(300)" + "\n 다음 턴까지 16세 이하 \n아이돌만 등장합니다. ";
                        break;

                    }

                    if (game.skillOnCheck[i] == true)
                    {
                        gCanvas.skillButton[i].colors = condUsingCB;
                        gCanvas.skillButtonText[i].text = "Sixteen 스킬 발동 중!" + "\n 다음 턴까지 16세 이하 \n아이돌만 등장합니다. ";
                        break;
                    }

                    Debug.LogWarning("Logical Error");
                    break;

                case 4:
                    if (game.skillOnCheck[i] != true)
                    {
                        if (game.skillPoint < 300)
                        {
                            gCanvas.skillButton[i].colors = condCannotCB;
                        }
                        else
                        {
                            gCanvas.skillButton[i].colors = condCanCB;
                        }
                        gCanvas.skillButtonText[i].text = "Skill : Seventeen(300)" + "\n 다음 턴까지 17세 이상 \n아이돌만 등장합니다. ";
                        break;

                    }

                    if (game.skillOnCheck[i] == true)
                    {
                        gCanvas.skillButton[i].colors = condUsingCB;
                        gCanvas.skillButtonText[i].text = "Seventeen 스킬 발동 중!" + "\n 다음 턴까지 17세 이상 \n아이돌만 등장합니다. ";
                        break;
                    }

                    Debug.LogWarning("Logical Error");
                    break;

                default:                
                    Debug.LogWarning("Logical Error! Check it!");
                    break;
                    
            }
        }
        
    }


    public void SkillSelect(int selectedSkill)
    {
        switch (selectedSkill)
        {
            case 0:
                if (game.skillOnCheck[0] != true && game.skillPoint >= 100)
                {
                    game.skillPoint = game.skillPoint - 100;
                    game.skillOnCheck[0] = true;
                    game.skillOnCheck[1] = false;
                    game.skillOnCheck[2] = false;
                }
                break;

            case 1:
                if (game.skillOnCheck[1] != true && game.skillPoint >= 100)
                {
                    game.skillPoint = game.skillPoint - 100;
                    game.skillOnCheck[0] = false;
                    game.skillOnCheck[1] = true;
                    game.skillOnCheck[2] = false;
                }
                break;

            case 2:
                if (game.skillOnCheck[2] != true && game.skillPoint >= 100)
                {
                    game.skillPoint = game.skillPoint - 100;
                    game.skillOnCheck[0] = false;
                    game.skillOnCheck[1] = false;
                    game.skillOnCheck[2] = true;
                }
                break;

            case 3:
                if (game.skillOnCheck[3] != true && game.skillPoint >= 300)
                {
                    game.skillPoint = game.skillPoint - 300;
                    game.skillOnCheck[3] = true;
                    game.skillOnCheck[4] = false;                    
                }
                break;

            case 4:
                if (game.skillOnCheck[4] != true && game.skillPoint >= 300)
                {
                    game.skillPoint = game.skillPoint - 300;
                    game.skillOnCheck[3] = false;
                    game.skillOnCheck[4] = true;
                }
                break;

            default:
                Debug.LogWarning("Logical Error! Check it!");
                break;

        }



    }
}
