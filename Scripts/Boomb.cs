using UnityEngine;
using System.Collections;

public class Boomb : MonoBehaviour {
    public float timeToExplotion;
    public int PowerExplotion;
    public Player playerOwnBoomb;
	private GameManager gm ;
	public GameObject fire_ob;


	private GameObject go_temp;
	private Fire f_temp;


	void Start()
	{
		gm = GameManager.Instance;
		StartCoroutine (TimerBoomb());
	}


	void Update()
	{

	}

	public void ExploseIn(IntVector2 tile)
	{
		tile = gm.TileToMapIndex (tile);
		// tile is indexMap constant 
		int xMapIndex = tile.x;
		int yMapIndex = tile.y;
		gm.map[yMapIndex,xMapIndex] = 0;

		for (int i = 1; i < PowerExplotion + 1; i++) {
			yMapIndex = tile.y  + i;
			xMapIndex = tile.x;
			if( xMapIndex < 0 || yMapIndex < 0 || xMapIndex > 12 || yMapIndex > 10 || gm.map[yMapIndex,xMapIndex] == 3 )
			{
				break;
			}
			else
			{
				gm.map[yMapIndex,xMapIndex] = 0;
				InstanceFire(gm.TieToPosition(gm.MapIndexToTile(new IntVector2(xMapIndex,yMapIndex))));

			}
		}

		for (int i = 1; i < PowerExplotion + 1; i++) {
			yMapIndex = tile.y;
			xMapIndex = tile.x-i;
			if( xMapIndex < 0 || yMapIndex < 0 || xMapIndex > 12 || yMapIndex > 10 || gm.map[yMapIndex,xMapIndex] == 3 )
			{
				break;
			}
			else
			{
				gm.map[yMapIndex,xMapIndex] = 0;
				InstanceFire(gm.TieToPosition(gm.MapIndexToTile(new IntVector2(xMapIndex,yMapIndex))));
				
			}
		}

		for (int i = 1; i < PowerExplotion + 1; i++) {
			yMapIndex = tile.y;
			xMapIndex = tile.x + i;
			if( xMapIndex < 0 || yMapIndex < 0 || xMapIndex > 12 || yMapIndex > 10 || gm.map[yMapIndex,xMapIndex] == 3 )
			{
				break;
			}
			else
			{
				gm.map[yMapIndex,xMapIndex] = 0;

				InstanceFire(gm.TieToPosition(gm.MapIndexToTile(new IntVector2(xMapIndex,yMapIndex))));
				
			}
		}

		for (int i = 1; i < PowerExplotion + 1; i++) {
			yMapIndex = tile.y - i;
			xMapIndex = tile.x;
			if( xMapIndex < 0 || yMapIndex < 0 || xMapIndex > 12 || yMapIndex > 10 || gm.map[yMapIndex,xMapIndex] == 3 )
			{
				break;
			}
			else
			{
				gm.map[yMapIndex,xMapIndex] = 0;
				InstanceFire(gm.TieToPosition(gm.MapIndexToTile(new IntVector2(xMapIndex,yMapIndex))));
				
			}
		}
	}

    public void ExplotionBoomb()
    {
        playerOwnBoomb.ExplotionBoomb();
		IntVector2 Tile =  gm.getTile(transform.position);
		ExploseIn (Tile);
		GameObject.Destroy (this.gameObject);
    }

	IEnumerator TimerBoomb()
	{
		yield return new WaitForSeconds(timeToExplotion);
		ExplotionBoomb ();
	}

	public void InstanceFire(Vector3 pos)
	{
		GameObject.Instantiate (fire_ob, pos, Quaternion.identity);

	}

}
