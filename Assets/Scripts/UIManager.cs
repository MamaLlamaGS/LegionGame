using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    //public RectTransfrom btnprefab;
    private Featuremanager mgr;
    private Text descText;

	// Use this for initialization
	void Start () {
        mgr = FindObjectOfType<Featuremanager>();
        descText = transform.Find("Navigation").Find("Text").GetComponent<Text>();
        transform.Find("Navigation").Find("Previous").GetComponent<Button>().onClick.AddListener(() => mgr.PreviousChoice());
        transform.Find("Navigation").Find("Previous").GetComponent<Button>().onClick.AddListener(() => mgr.NextChoice());
    }
	
	// Update is called once per frame
	void Update () {
        descText.text = mgr.features[mgr.currFeature].ID + " #" + (mgr.features[mgr.currFeature].currIndex + 1).ToString();


    }
}
