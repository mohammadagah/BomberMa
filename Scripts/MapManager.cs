using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.IO;

[Serializable]
public struct MapSprites
{
	public Sprite Back;
	public Sprite Brick;
	public Sprite Divar;

}

public enum ItemMode{ NONE = 0 , START_ONE , START_TWO , DIVAR , BRICK };

[ExecuteInEditMode]
public class MapManager : MonoBehaviour {
    
	
	public GameObject ItemGridView;
	public GameObject BackGridView;

	public GameObject BackPrefab;
	public GameObject BrickPrefab;
	public GameObject DivarPrefab;

	public GameObject nullPrefab;

	public MapSprites[] MapSprites;

	private int numberOfRow  =  11;
	private int numberOfCol  =  13;


    #region SingleToon
    protected MapManager() { }
    private static MapManager instance = null;
    
    public static MapManager Instance
    {
        get
        {
            if (MapManager.instance == null)
            {
                MapManager.instance = GameObject.FindObjectOfType(typeof(MapManager)) as MapManager;
                //find is any gameobject that have this script.
                if (MapManager.instance == null)
                {
                    Debug.Log("error:: You dont have singleToon gameObject");
                    Debug.LogError("solve:First create GameObject with the any name.And Add this Script to it.");
                }
                else
                {
                    DontDestroyOnLoad(MapManager.instance); // exist in all Scenes
                }
            }
            return MapManager.instance;
        }
    }

    public void OnApplicationQuit()
    {
        MapManager.instance = null;
    }
    #endregion

	private int[,] mapTest = new int[,]
	{
		{ 3,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3  } ,
		{ 3,1 ,0 ,2 ,0 ,4 ,4 ,4 ,0 ,0 ,4 ,4 ,3  } ,
		{ 3,0 ,3 ,0 ,3 ,4 ,3 ,0 ,3 ,0 ,3 ,0 ,3  } ,
		{ 3,4 ,0 ,0 ,4 ,0 ,0 ,4 ,4 ,4 ,4 ,4 ,3  } ,
		{ 3,4 ,3 ,0,3 ,4 ,3 ,4 ,3 ,4 ,3 ,4 ,3  } ,
		{ 3,4 ,0 ,0 ,4 ,4 ,4 ,0 ,4 ,4 ,0 ,4 ,3  } ,
		{ 3,4 ,3 ,0 ,3 ,4 ,3 ,4 ,3 ,4 ,3 ,0 ,3  } ,
		{ 3,4 ,0 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,0 ,4 ,3  } ,
		{ 3,4 ,3 ,0 ,3 ,4 ,3 ,4 ,3 ,0 ,3 ,4 ,3  } ,
		{ 3,4 ,4 ,0 ,0 ,0 ,4 ,4 ,0 ,0 ,4 ,0 ,3  } ,
		{ 3,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3  } ,
    };

	private int[,] getMap(int id)
	{
		string path = @"Assets\" + id.ToString ();
		string allText = File.ReadAllText (path);
		string[] stringRows = allText.Split ('\n');
		int[,] mapArray = new int[11,13];
		for (int j = 0; j < 11; j++) {
			string[] thisRow = stringRows[j].Split (',');
			for(int i = 0 ; i < 13 ; i++)
			{
				mapArray[j,i] = Convert.ToInt32 (thisRow[i]);
			}
				}
		Console.WriteLine (mapArray);
		Debug.Log (mapArray);
		return mapArray;
	}

	void Awake()
	{

		if ( !Application.isPlaying)
		{

		}
		else
		{
			
		}
	}

	void Start()
	{
		
		generateMap();
		if ( !Application.isPlaying)
		{
			
		}
		else
		{
			
			
		}
	}



	void Update()
	{
		if ( !Application.isPlaying)
		{
			
		}
		else
		{
			
			
		}

	}


	public int[,] getMap()
    {
		return mapTest;
    }

    public void generateMap()
    {
		IntVector2 player_one_tile = new IntVector2 ();
		IntVector2 player_two_tile = new IntVector2 ();

		int random = UnityEngine.Random.Range(0, MapSprites.Length );
		BackPrefab.GetComponent<SpriteRenderer> ().sprite = MapSprites [random].Back;
		BrickPrefab.GetComponent<SpriteRenderer> ().sprite = MapSprites [random].Brick;
		DivarPrefab.GetComponent<SpriteRenderer> ().sprite = MapSprites [random].Divar;

		if (ItemGridView.transform.childCount == 0) 
		{

			for (int i = 0; i < numberOfRow; i++) 
			{
				for (int j = 0; j < numberOfCol; j++) 
				{
					if (mapTest[i,j] == 4)
					{
						GameObject Brick = GameObject.Instantiate (BrickPrefab) as GameObject;
						Brick.transform.SetParent (ItemGridView.transform);
					}
					else if (mapTest[i,j] == 3)
					{
						GameObject Wall = GameObject.Instantiate (DivarPrefab) as GameObject;
						Wall.transform.SetParent (ItemGridView.transform);
					}
					else if (mapTest[i,j] == 0)
					{
						GameObject nulll = GameObject.Instantiate (nullPrefab) as GameObject;
						nulll.transform.SetParent (ItemGridView.transform);
					}
					else if (mapTest[i,j] == 1)
					{
						GameObject nulll = GameObject.Instantiate (nullPrefab) as GameObject;
						nulll.transform.SetParent (ItemGridView.transform);
						player_one_tile.x = j-1;
						player_one_tile.y = i-1;
					
					}else if (mapTest[i,j] == 2)
					{
						GameObject nulll = GameObject.Instantiate (nullPrefab) as GameObject;
						nulll.transform.SetParent (ItemGridView.transform);
						player_two_tile.x = j-1;
						player_two_tile.y = i-1;
					}
				}
			}
		}
		else 
		{

			for (int i = 0; i < numberOfRow; i++) 
			{
				for (int j = 0; j < numberOfCol; j++) 
				{
					if (mapTest[i,j] == 4)
					{
						ItemGridView.transform.GetChild(j + i*(numberOfCol)).GetComponent<SpriteRenderer>().sprite = MapSprites [random].Brick;
					}
					else if (mapTest[i,j] == 3)
					{
						ItemGridView.transform.GetChild(j + i*(numberOfCol)).GetComponent<SpriteRenderer>().sprite = MapSprites [random].Divar;
					}
					else if (mapTest[i,j] == 0)
					{
						ItemGridView.transform.GetChild(j+ i*(numberOfCol)).GetComponent<SpriteRenderer>().sprite = null;
					}
					else if (mapTest[i,j] == 1)
					{
						ItemGridView.transform.GetChild(j+ i*(numberOfCol)).GetComponent<SpriteRenderer>().sprite = null;
						player_one_tile.x = j-1;
						player_one_tile.y = i-1;

					}
					else if (mapTest[i,j] == 2)
					{
						ItemGridView.transform.GetChild(j+ i*(numberOfCol)).GetComponent<SpriteRenderer>().sprite = null; 
						player_two_tile.x = j-1;
						player_two_tile.y = i-1;

					}
				}
			}
		}


	
		if (BackGridView.transform.childCount == 0) 
		{

			for (int i = 0; i < numberOfRow - 2 ; i++) 
			{
				for (int j = 0; j < numberOfCol; j++) 
				{
						GameObject Back = GameObject.Instantiate (BackPrefab) as GameObject;
						Back.transform.SetParent (BackGridView.transform);
				}
			}
		}
		else
		{
			for (int i = 0; i < numberOfRow - 2 ; i++) 
			{
				for (int j = 0; j < numberOfCol  ; j++) 
				{	
					BackGridView.transform.GetChild(j + i*numberOfCol).GetComponent<SpriteRenderer>().sprite = MapSprites [random].Back;
				}
			}
		}

		GameManager.Instance.mapGenerated (player_one_tile, player_two_tile);

    }

}
