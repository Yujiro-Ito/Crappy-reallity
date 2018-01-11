using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;


public class ClickChecker : MonoBehaviour, IInputClickHandler, IHoldHandler{
	public GameObject prefab;
	public GameObject introPrefab;

	// Use this for initialization
	void Start () {
		InputManager.Instance.PushFallbackInputHandler(gameObject);
	}

	public void OnInputClicked(InputClickedEventData eventData){
		DataManager.Instance.Add(this.transform.position);
		GameObject tmp = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
		Debug.Log("pass");
	}

	public void OnHoldCompleted(HoldEventData eventData){
		GameObject tmp = (GameObject)Instantiate(introPrefab, transform.position, transform.rotation);
		Transform[] pos = tmp.GetComponentsInChildren<Transform>();
		StartCoroutine(SaveIntroPos(pos));
	}

	private IEnumerator SaveIntroPos(Transform[] positions){
		for(int i = 0; i < positions.Length; i++){
			DataManager.Instance.Add(positions[i].transform.position);
			yield return new WaitForEndOfFrame();
		}
	}

	public void OnHoldStarted(HoldEventData eventData){}
    public void OnHoldCanceled(HoldEventData eventData){}
}
