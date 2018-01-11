using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataManager : MonoBehaviour {
	private const string KEY = "SAVEPOS";

	private static GameObject _singletonObject;
	private static DataManager _singleton;
	private static int _currentMax;
	public static DataManager Instance{
		get{
			if(_singleton == null){
				_currentMax = PlayerPrefs.GetInt(KEY, 0);
				if(_currentMax > 0){
					_savePositions = new Vector3[_currentMax];
					for(int i = 0; i < _currentMax; i++){
						_savePositions[i] = PlayerPrefsX.GetVector3(KEY + i.ToString());
					}
				} else {
					_savePositions = new Vector3[0];
				}
				_singletonObject = new GameObject("DataManager");
				_singletonObject.AddComponent<DataManager>();
				_singleton = _singletonObject.GetComponent<DataManager>();
			}
			return _singleton;
		}
	}
	private static Vector3[] _savePositions;
	public static string filePath;

	public void Add(Vector3 value){
		_currentMax++;
		PlayerPrefs.SetInt(KEY, _currentMax);
		Vector3[] pos = new Vector3[_currentMax];
		Array.Copy(_savePositions, pos, _savePositions.Length);
		pos[_currentMax - 1] = value;
		_savePositions = pos;
		StartCoroutine(Save(pos));
	}

	private IEnumerator Save(Vector3[] data){
		for(int i = 0; i < data.Length; i++){
			PlayerPrefsX.SetVector3(KEY + i.ToString(), data[i]);
			yield return new WaitForEndOfFrame();
		}
		yield break;
	}

	public Vector3[] GetSaveData(){
		return _savePositions;
	}
}