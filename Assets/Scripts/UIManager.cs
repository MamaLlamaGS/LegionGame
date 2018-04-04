using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public RectTransfrom btnprefab;
    private FeatureManager mgr;
    private Text descText;

	// Use this for initialization
	void Start () {
        mgr = FindObjectofType<FeatureManager>();
        descText = transform.FindChild("Navigation").FindChild("Text").GetComponent<descText>();
        transform.FindChild("Navigation").FindChild("Previous").GetCompentent<Button>().onClick.AddListener(() => mgr.PreviousChoice());
        transform.FindChild("Navigation").FindChild("Previous").GetCompentent<Button>().onClick.AddListener(() => mgr.NextChoice());
    }
	
	// Update is called once per frame
	void Update () {
        descText.Text = mgr.feature[mgr.currfeature].ID + " #" + (mgr.features[mgr.currFeature]).currIndex + 1).ToString();


    }
}
