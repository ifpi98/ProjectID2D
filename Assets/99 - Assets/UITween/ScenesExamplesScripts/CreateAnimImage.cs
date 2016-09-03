using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CreateAnimImage : MonoBehaviour {

	public CreateAnimImage[] createImageOtherReference;

	public Unit unitPrefab;
    public List<Unit> unitObjects;
    public int maxUnits;
    public int lastCount = 0;
    Vector3 InstancePosition;

    public int HowManyButtons;

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
		InitialCanvasScrollSize = new Vector2(RootRect.rect.height, RootRect.rect.width);
        unitObjects = new List<Unit>(maxUnits);
        CreatePanels(maxUnits);
        InstancePosition = EndAnim;
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
        CreatePanels2();
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

    public void UpdatePanels()
    {

        Profiler.BeginSample("UpdatePanels");
        for (int i = lastCount; i < HowManyButtons; i++)
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
        lastCount = HowManyButtons;
        Profiler.EndSample();
    }

    public void Set(string[] strArr)
    {
        for (int i = 0; i < strArr.Length; i++)
        {
            unitObjects[i].Label.text = strArr[i];
            Color color = unitObjects[i].GetComponent<Image>().color;
            color.a = 1;
            unitObjects[i].GetComponent<Image>().color = color;
            color = unitObjects[i].Label.color;
            color.a = 1;
            unitObjects[i].Label.color = color;
        }
    }

    private void CreatePanels2()
    {
        Vector3 InstancePosition2 = EndAnim;

        totalWidth = 0f;

        for (int i = 0; i < HowManyButtons; i++)
        {
            // Creates Instance
            GameObject unit = Instantiate(unitPrefab.gameObject) as GameObject;
            unit.name = "CharDegreeList" + i;
            // Changes the Parent, Assing to scroll List
            unit.transform.SetParent(RootRect, false);
            EasyTween easy = unit.GetComponent<EasyTween>();
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
