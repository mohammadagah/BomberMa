using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            
            var posVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(posVec);
        }
	}
}
