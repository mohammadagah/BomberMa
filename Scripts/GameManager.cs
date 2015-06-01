using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    #region SingleToon
    protected GameManager() { }
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (GameManager.instance == null)
            {
                GameManager.instance = GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;
                //find is any gameobject that have this script.
                if (GameManager.instance == null)
                {
                    Debug.Log("error:: You dont have singleToon gameObject");
                    Debug.LogError("solve:First create GameObject with the any name.And Add this Script to it.");
                }
                else
                {
                    DontDestroyOnLoad(GameManager.instance); // exist in all Scenes
                }
            }
            return GameManager.instance;
        }
    }
    public void OnApplicationQuit()
    {
        GameManager.instance = null;
    }
    #endregion

	public int[,] map;
	public GameObject fireBoomb;
    public Player player01;
    public Player player02;
	public GameObject backgroundGridView;
    public delegate void OnTimerChangeSecendDel();
    public event OnTimerChangeSecendDel OnTimerChangeSecend = null;
	public int gameTime;

	[HideInInspector]
	public float x_change ;
	
	[HideInInspector]
	public float y_change ;
	
	private Vector3 tile0_0_position;


    public void Awake()
    {
        map = MapManager.Instance.getMap();
    }

    public void Start()
    {
        TimerSecendStart();


    }

	
	public void mapGenerated(IntVector2 player_one_tile , IntVector2 player_two_tile)
	{
		x_change =backgroundGridView.GetComponents<GridView> ()[0].CellSize.x;
		y_change = backgroundGridView.GetComponents<GridView> ()[0].CellSize.y;

		tile0_0_position = backgroundGridView.transform.GetChild (1).gameObject.transform.position;
		player01.GetComponent<MovePlayer> ().setPosition (TieToPosition (player_one_tile));
	}


	
	// Update is called once per frame
	void Update () {
	
	}

    public void CreatMapObject()
    {

    }

    IEnumerator TimerSecendStart()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            OnTimerChangeSecendPublish();
        }
    }

    public void OnTimerChangeSecendPublish()
    {
        gameTime = gameTime - 1;
        OnTimerChangeSecend.Invoke();
    }

	public IntVector2 getTile(Vector3 who )
	{
		int xTile = Mathf.RoundToInt ((who.x - tile0_0_position.x) / x_change);
		int yTile = Mathf.RoundToInt ((who.y - tile0_0_position.y) / y_change) ;
		yTile = -yTile;

		return new IntVector2 (xTile, yTile);
	}

	public IntVector2 TileToMapIndex(IntVector2 tile)
	{
		return tile + new IntVector2(1 ,1);
	}

	public IntVector2 MapIndexToTile(IntVector2 mapIndex)
	{
		return mapIndex + new IntVector2(-1 ,-1);
	}

	public int tileContex(IntVector2 tile)
	{
		IntVector2 tt;
		tt = TileToMapIndex (tile);

		if (tt.y < 0 || tt.x < 0) 
		{
			return 20;
		}

		return map[tt.y , tt.x];
	}

	public bool canMoveTo(Vector3 des)
	{
		return canGoThisTile (getTile (des));
	}

	public bool canGoThisTile(IntVector2 tile)
	{
		int tt = tileContex (tile);
		return !(tt == 3 || tt == 4 || tt == 50 || tt == 20);
	}


	public Vector3 TieToPosition(IntVector2 tile)
	{
		return new Vector3 ( tile0_0_position.x + x_change * tile.x, tile0_0_position.y - y_change * tile.y, 0);
	}

	



}
