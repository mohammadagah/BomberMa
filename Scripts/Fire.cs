using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
	public float timeToTerminate;
	// Use this for initialization
	void Start () {
		StartCoroutine( TimerBoomb());
	}


	IEnumerator TimerBoomb()
	{
		yield return new WaitForSeconds(timeToTerminate);
		GameObject.Destroy (this.gameObject);
	}

}
