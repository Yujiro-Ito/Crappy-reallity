using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DebugOnly : MonoBehaviour {
	public Text text;


	// Use this for initialization
	void Start () {
		StartCoroutine(UpdatePosition());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator UpdatePosition(){
		text.text = "";
		Vector3[] tmp = DataManager.Instance.GetSaveData();
		for(int i = 0; i < tmp.Length; i++){
			text.text += tmp[i].ToString() + "\n";
		}
		yield return new WaitForSeconds(5f);
		StartCoroutine(UpdatePosition());
	}
}
