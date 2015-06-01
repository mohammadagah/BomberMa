using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Move { UP , DOWN , RIGHT , LEFT , NULL};

public class MovePlayer : MonoBehaviour {
	
	public float t_to_move_one; 
	public int smoothing ;
	public int n_o_p_beetwen_tiles; //odd number
	
	private Transform player_position_transform;
	private int padding_h;
	private int padding_v;

	private Move move;
	private bool is_moving ;
	private GameManager gm;
	private Vector3 dest;
	private IntVector2 p_tile_temp;
	private int max_padding;

	// Use this for initialization
	void Awake()
	{
		player_position_transform = transform.GetChild (0).transform;
	}
	void Start ()
	{
		padding_h = 0;
		padding_v = 0;



		if (n_o_p_beetwen_tiles % 2 == 0 || n_o_p_beetwen_tiles < 0)
			Debug.LogError ("n_o_p_beetwen_tiles must be odd and positive");
		
		max_padding = (n_o_p_beetwen_tiles - 1) / 2;

		gm = GameManager.Instance;
		is_moving = false;
		move = Move.NULL;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			move = Move.UP;
		} 
		else if (Input.GetKey (KeyCode.DownArrow)) 
		{
			move = Move.DOWN;
		}
		else if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			move = Move.LEFT;
		}
		else if (Input.GetKey (KeyCode.RightArrow)) 
		{
			move = Move.RIGHT;
		}

		if (move != Move.NULL && !is_moving) 
		{
			switch(move){
				case Move.UP:
					Upping();
					break;

				case Move.DOWN:
				    Downing();     
					break;

				case Move.LEFT:
				    Lefting();
					break;

				case Move.RIGHT:
				    Righting();
					break;
			}
		}

		move = Move.NULL;
	}

	private void Upping()
	{
		p_tile_temp = gm.getTile(player_position_transform.position);
		p_tile_temp.y --;
		if (gm.canGoThisTile(p_tile_temp))
		{
			if (padding_h > 0)
			{
				goLeft();
			}
			else if (padding_h < 0)
			{
				goRight();
			}
			else
			{
				goUp();
			}
		}
		else
		{
			if (padding_v < 0 )
			{
				goUp();
			}
			else if (padding_h > 0 )
			{
				p_tile_temp.x ++;
				
				if (gm.canGoThisTile(p_tile_temp))
				{
					goRight();
				}else
				{
					//can change direction to up
				}
				
			}
			else if (padding_h < 0 )
			{
				p_tile_temp.x --;
				
				if (gm.canGoThisTile(p_tile_temp))
				{
					goLeft();
				}else
				{
					//can change direction to up
				}
			}
			else
			{
				//only change direction to up
			}
		}
	}

	private void Downing()
	{
		p_tile_temp = gm.getTile(player_position_transform.position);
		p_tile_temp.y ++;

		if (gm.canGoThisTile(p_tile_temp))
		{

			if (padding_h > 0)
			{
				goLeft();
			}
			else if (padding_h < 0)
			{
				goRight();
			}
			else
			{
				goDown();
			}
		}
		else
		{
			if (padding_v > 0 )
			{
				goDown();
			}
			else if (padding_h > 0 )
			{
				p_tile_temp.x ++;
				
				if (gm.canGoThisTile(p_tile_temp))
				{
					goRight();
				}else
				{
					//can change direction to up
				}
				
			}
			else if (padding_h < 0 )
			{
				p_tile_temp.x --;
				
				if (gm.canGoThisTile(p_tile_temp))
				{
					goLeft();
				}else
				{
					//can change direction to up
				}
			}
			else
			{
				//only change direction to up
			}
		}
	}

	private void Lefting()
	{
		p_tile_temp = gm.getTile(player_position_transform.position);
		p_tile_temp.x --;
		if (gm.canGoThisTile(p_tile_temp))
		{
			if (padding_v > 0)
			{
				goDown();
			}
			else if (padding_v < 0)
			{
				goUp();
			}
			else
			{
				goLeft();
			}
		}
		else
		{
			if (padding_h > 0 )
			{
				goLeft();
			}
			else if (padding_v > 0 )
			{
				p_tile_temp.y --;
				
				if (gm.canGoThisTile(p_tile_temp))
				{
					goUp();
				}else
				{
					//can change direction to up
				}
				
			}
			else if (padding_v < 0 )
			{
				p_tile_temp.y ++;
				
				if (gm.canGoThisTile(p_tile_temp))
				{
					goDown();
				}else
				{
					//can change direction to up
				}
			}
			else
			{
				//only change direction to up
			}
		}
	}

	private void Righting()
	{
		p_tile_temp = gm.getTile(player_position_transform.position);
		p_tile_temp.x ++;
		if (gm.canGoThisTile(p_tile_temp))
		{
			if (padding_v > 0)
			{
				goDown();
			}
			else if (padding_v < 0)
			{
				goUp();
			}
			else
			{
				goRight();
			}
		}
		else
		{
			if (padding_h < 0 )
			{
				goRight();
			}
			else if (padding_v > 0 )
			{
				p_tile_temp.y --;
				
				if (gm.canGoThisTile(p_tile_temp))
				{
					goUp();
				}else
				{
					//can change direction to up
				}
				
			}
			else if (padding_v < 0 )
			{
				p_tile_temp.y ++;
				
				if (gm.canGoThisTile(p_tile_temp))
				{
					goDown();
				}else
				{
					//can change direction to up
				}
			}
			else
			{
				//only change direction to up
			}
		}
	}



	public void goUp()
	{

		dest = new Vector3(player_position_transform.position.x,player_position_transform.position.y + gm.y_change /n_o_p_beetwen_tiles,player_position_transform.position.z);
		if (gm.getTile(dest) == gm.getTile(player_position_transform.position) || gm.canMoveTo (dest))
		{
			AddToVPadding();
			StartCoroutine(MovementFromTo(transform, player_position_transform.position,dest ));
		}


	}

	public void goDown()
	{
		dest = new Vector3(player_position_transform.position.x,player_position_transform.position.y - gm.y_change / n_o_p_beetwen_tiles,player_position_transform.position.z );
		if (gm.getTile(dest) == gm.getTile(player_position_transform.position) || gm.canMoveTo (dest))
		{
			SubFromVPadding();
			StartCoroutine (MovementFromTo (transform, player_position_transform.position, dest));
		}
	}

	public void goRight()
	{
		dest = new Vector3(player_position_transform.position.x + gm.x_change/n_o_p_beetwen_tiles,player_position_transform.position.y ,player_position_transform.position.z );
		if (gm.getTile(dest) == gm.getTile(player_position_transform.position) || gm.canMoveTo (dest)) 
		{
			AddToHPadding();
			StartCoroutine(MovementFromTo(transform, player_position_transform.position,dest));
		}
	}

	public void goLeft()
	{
		dest = new Vector3(player_position_transform.position.x - gm.x_change / n_o_p_beetwen_tiles,player_position_transform.position.y,player_position_transform.position.z );
		if (gm.getTile(dest) == gm.getTile(player_position_transform.position) || gm.canMoveTo (dest)) 
		{
			SubFromHPadding();
			StartCoroutine(MovementFromTo(transform, player_position_transform.position,dest));
		}
	}

	public void AddToHPadding() //when Right
	{
		if (padding_h == max_padding)
		{
			padding_h = -max_padding;
		}
		else
			padding_h ++;

	}

	public void SubFromHPadding()//when Left
	{
		if (padding_h == -max_padding)
		{
			padding_h = max_padding;
		}
		else
			padding_h --;
	}

	public void AddToVPadding()//when Up
	{
		if (padding_v == max_padding)
		{
			padding_v = -max_padding;
		}
		else
			padding_v ++;
	}

	public void SubFromVPadding()//when Down
	{
		if (padding_v == -max_padding)
		{
			padding_v = max_padding;
		}
		else
			padding_v --;
		
	}

	IEnumerator MovementFromTo(Transform who, Vector3 startPoint, Vector3 endPoint)
	{
		
		is_moving = true;

		float tt = t_to_move_one / smoothing;
		float tt2 = 1f / smoothing;

		float u = tt2;

		while (u < 1.01f) {
			setPosition(Vector3.Lerp (startPoint, endPoint, u));
			yield return new WaitForSeconds (tt);
			u = u + tt2;
		}

		setPosition(Vector3.Lerp (startPoint, endPoint, 1f));
						
		is_moving = false;
	}

	public void setPosition(Vector3 pos)
	{
		Vector3 movement = pos - player_position_transform.position;
		transform.position = transform.position + movement;
		
	}
}