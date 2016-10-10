using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CreateAnimImage : MonoBehaviour {

    Game game;
    public CreateAnimImage[] createImageOtherReference;

	public Unit unitPrefab;
    public List<Unit> unitObjects;
    public int maxUnits;
    public int lastUnitCount = 0;
    Vector3 InstancePosition;

    public Unit2 charUnitPrefab;
    public List<Unit2> charUnitObjects;
    public int maxCharUnits;
    public int lastCharCount = 0;
    Vector3 InstancePosition2;
    
    public int HowManyButtons;
    public int HowManyButtons2;

    public Vector3 StartAnim;
	public Vector3 EndAnim;

	public float Offset;

	public AnimationCurve EnterAnim;
	public AnimationCurve ExitAnim;

	public RectTransform RootRect;
	public RectTransform RootCanvas;

	private List<EasyTween> Created = new List<EasyTween>();

	private Vector2 InitialCanvasScrollSize;
	private float totalWidth = 0f;

    void Start()
	{
        game = GameObject.Find("GameObj").GetComponent<Game>();
        InitialCanvasScrollSize = new Vector2(RootRect.rect.height, RootRect.rect.width);
        maxUnits = game.availableUnit;
        maxCharUnits = game.availableChar;
        unitObjects = new List<Unit>(maxUnits);
        charUnitObjects = new List<Unit2>(maxCharUnits);
        CreatePanels(maxUnits);
        CreatePanels2(maxCharUnits);
        InstancePosition = EndAnim;
        InstancePosition2 = EndAnim;
    }

	public void CallBack()
	{
		if (Created.Count == 0)
		{
			for (int i = 0; i < createImageOtherReference.Length; i++)
			{
				createImageOtherReference[i].DestroyButtons();
			}

			CreateButtons();
		}
	}

	public void DestroyButtons()
	{
		for (int i = 0; i < Created.Count; i++)
		{
			Created[i].OpenCloseObjectAnimation();
		}

		Created.Clear();
	}

	public void CreateButtons()
	{
        UpdatePanels();
		AdaptCanvas();
	}

    public void CreateButtons2()
    {
        UpdatePanels2();
        AdaptCanvas();
    }

    private void CreatePanels(int count)
	{
        for (int i = 0; i < count; i++)
        {
            var unit = Instantiate<Unit>(unitPrefab);            
            unit.gameObject.SetActive(false);
            unitObjects.Add(unit);
        }
	}

    private void CreatePanels2(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var unit = Instantiate<Unit2>(charUnitPrefab);
            unit.gameObject.SetActive(false);
            charUnitObjects.Add(unit);
        }
    }

    public void UpdatePanels()
    {
                
        for (int i = lastUnitCount; i < HowManyButtons; i++)
        {
            unitObjects[i].gameObject.SetActive(true);

            // Changes the Parent, Assing to scroll List
            unitObjects[i].transform.SetParent(RootRect, false);
            EasyTween easy = unitObjects[i].GetComponent<EasyTween>();
            // Add Tween To List
            Created.Add(easy);
            // Final Position
            StartAnim.y = InstancePosition.y;
            // Pass the positions to the Tween system
            easy.SetAnimationPosition(StartAnim, InstancePosition, EnterAnim, ExitAnim);
            // Intro fade
            easy.SetFade();
            // Execute Animation
            easy.OpenCloseObjectAnimation();
            // Increases the Y offset
            InstancePosition.y += Offset;

            totalWidth += Offset;
        }
        lastUnitCount = HowManyButtons;        
    }

    public void Set(string[] strArr, int[] intArr)
    {
        for (int i = 0; i < strArr.Length; i++)
        {
            unitObjects[i].Label.text = strArr[i];
            unitObjects[i].instanceUnitID = intArr[i];
            Color color = unitObjects[i].GetComponent<Image>().color;
            color.a = 1;
            unitObjects[i].GetComponent<Image>().color = color;
            color = unitObjects[i].Label.color;
            color.a = 1;
            unitObjects[i].Label.color = color;
        }
    }

    private void UpdatePanels2()
    {
        //Vector3 InstancePosition2 = EndAnim;

        //totalWidth = 0f;

        for (int i = lastCharCount; i < HowManyButtons2; i++)
        {
            charUnitObjects[i].gameObject.SetActive(true);

            // Creates Instance
            //GameObject unit = Instantiate(unitPrefab.gameObject) as GameObject;
            //unit.name = "CharDegreeList" + i;
            // Changes the Parent, Assing to scroll List
            charUnitObjects[i].transform.SetParent(RootRect, false);
            EasyTween easy = charUnitObjects[i].GetComponent<EasyTween>();
            // Add Tween To List
            Created.Add(easy);
            // Final Position
            StartAnim.y = InstancePosition2.y;
            // Pass the positions to the Tween system
            easy.SetAnimationPosition(StartAnim, InstancePosition2, EnterAnim, ExitAnim);
            // Intro fade
            easy.SetFade();
            // Execute Animation
            easy.OpenCloseObjectAnimation();
            // Increases the Y offset
            InstancePosition2.y += Offset;

            totalWidth += Offset;
        }

        lastCharCount = HowManyButtons2;
    }
    
    public void Set2(string[] strArr, int[] intArr)
    {
        for (int i = 0; i < strArr.Length; i++)
        {
            charUnitObjects[i].Label.text = strArr[i];
            charUnitObjects[i].instanceCharID = intArr[i];
            Color color = charUnitObjects[i].GetComponent<Image>().color;
            color.a = 1;
            charUnitObjects[i].GetComponent<Image>().color = color;
            color = charUnitObjects[i].Label.color;
            color.a = 1;
            charUnitObjects[i].Label.color = color;
        }
    }
    private void AdaptCanvas()
	{
		// Vertical Dynamic Adapter
		if (InitialCanvasScrollSize.x < Mathf.Abs(totalWidth) )
		{
			RootRect.offsetMin = new Vector2(RootRect.offsetMin.x, totalWidth + InitialCanvasScrollSize.x + RootRect.offsetMax.y);
		}
	}
}
