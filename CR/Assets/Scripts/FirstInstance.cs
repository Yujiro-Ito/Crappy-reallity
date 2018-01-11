using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstInstance : MonoBehaviour {
	public GameObject prefab;
	void Start () {
		Vector3[] datas = DataManager.Instance.GetSaveData();
		for(int i = 0; i < datas.Length; i++){
			GameObject tmp = (GameObject)Instantiate(prefab, datas[i], Quaternion.identity);
		}
	}
}
