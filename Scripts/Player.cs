using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public string name;
    public int level;
    public GameObject boomb;

	private int boombCountInMap = 0;
	private int BoombLimit = 1;
	private IntVector2 temp;
	private GameManager gm;
	private Transform player_position_transform;


	private GameObject go_temp;
	private Boomb b_temp;

    void Awake()
	{
		player_position_transform = transform.GetChild (0).transform;
        gm = GameManager.Instance;

    }

	void Start()
	{


	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.A)) 
		{
			DownBoomb();
		}
	}

	public bool canDownBoomb()
	{
		return boombCountInMap < BoombLimit;
	}


    public void DownBoomb()
    {
		if (canDownBoomb())
		{
			boombCountInMap++;
			temp = gm.getTile(player_position_transform.position);

			InstanceBoomb(gm.TieToPosition(temp) + new Vector3(-0.05f ,0.2f ,0));
			
			temp = gm.TileToMapIndex(temp);
			gm.map[temp.y , temp.x] = 50;
		}
    }

	public void InstanceBoomb(Vector3 pos)
	{
		go_temp = GameObject.Instantiate (boomb);
		b_temp = go_temp.GetComponent<Boomb> ();
		b_temp.playerOwnBoomb = this.gameObject.GetComponent<Player>();
		go_temp.transform.position = pos;
	}

    public void ExplotionBoomb()
    {
        boombCountInMap--;
    }
}
