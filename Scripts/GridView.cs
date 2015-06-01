using UnityEngine;
using System;
using System.Collections;

[Serializable]
public struct Padding
{
	public int Left;
	public int Right;
	public int Top;
	public int Bottom;
}

[ExecuteInEditMode]
public class GridView : MonoBehaviour {

	public		Padding		Padding;
	public		Vector2		CellSize;
	public		Vector2		Spacing;
	public		int			numberOfCol;
	private		Vector2		OrginalSize;
	private		int			numberOFBeforChild;

	void Start () {

		if ( !Application.isPlaying)
		{
			doIT();
		}
		else
		{
			doIT();

		}

	}


	void Update () {
		if ( !Application.isPlaying)
		{
			doIT();

		}
		else
		{
			if (transform.childCount != numberOFBeforChild)
			{
				doIT();
			}

		}
	}

	void doIT()
	{
		if (numberOfCol < 1){
			numberOfCol = 1;
		}

		if (CellSize.Equals(Vector2.zero)){
			if (transform.childCount != 0){
				OrginalSize = GetDimensionInPX(transform.GetChild(0).gameObject);
				CellSize = OrginalSize;
			}
		}

		if (OrginalSize.Equals(Vector2.zero) && transform.childCount != 0){
			OrginalSize = GetDimensionInPX(transform.GetChild(0).gameObject);
		}
		numberOFBeforChild = transform.childCount;
		for(int i = 0; i < transform.childCount; i++) {
			SpriteRenderer rn = transform.GetChild(i).GetComponent <SpriteRenderer>();
			rn.sortingOrder = i;
			transform.GetChild(i).transform.localScale = new Vector3(CellSize.x / OrginalSize.x  , CellSize.y / OrginalSize.y , 1f);
			int temp = i / numberOfCol;
			transform.GetChild(i).transform.position = new Vector3(transform.position.x + Padding.Left + (i - temp*numberOfCol)*(Spacing.x + CellSize.x) ,
			                                                       transform.position.y - Padding.Top - (i / numberOfCol)*(Spacing.y + CellSize.y),transform.position.z);

		}
	}

	private Vector2 GetDimensionInPX(GameObject obj) {
		Vector2 tmpDimension;
		tmpDimension.x = obj.GetComponent<SpriteRenderer>().sprite.bounds.size.x;  // this is gonna be our width
		tmpDimension.y =  obj.GetComponent<SpriteRenderer>().sprite.bounds.size.y;  // this is gonna be our height
		
		return tmpDimension;
	}
}


