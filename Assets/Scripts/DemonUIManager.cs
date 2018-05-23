using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DemonUIManager : MonoBehaviour
{

    private DemonCustomisationManager manager;
    private Button eyesButton;
    private Button earsButton;
    private Button noseButton;
    private Button mouthButton;
    private Button colourButton;
    private int featureIndex;

    //private Text descText;
    //private GameObject bottomNavigation = null;

    // examples from https://www.youtube.com/watch?v=xoIagG1RVeE


    // Use this for initialization
    void Start()
    {
        manager = FindObjectOfType<DemonCustomisationManager>();

        earsButton = GameObject.Find("Ears Button").GetComponent<Button>(); 
        earsButton.onClick.AddListener(() => manager.SetCurrentFeatureType(GetFeatureIndex(earsButton)));
        eyesButton = GameObject.Find("Eyes Button").GetComponent<Button>();
        eyesButton.onClick.AddListener(() => manager.SetCurrentFeatureType(GetFeatureIndex(eyesButton)));
        noseButton = GameObject.Find("Nose Button").GetComponent<Button>();
        noseButton.onClick.AddListener(() => manager.SetCurrentFeatureType(GetFeatureIndex(noseButton)));
        mouthButton = GameObject.Find("Mouth Button").GetComponent<Button>();
        mouthButton.onClick.AddListener(() => manager.SetCurrentFeatureType(GetFeatureIndex(mouthButton)));

        colourButton = GameObject.Find("Colour Button").GetComponent<Button>();
        colourButton.onClick.AddListener(() => manager.ChangeDemonColour());

        //bottomNavigation = GameObject.Find("Navigation");
        //descText = bottomNavigation.transform.Find("Description").GetComponent<Text>();
        //bottomNavigation.transform.Find("Previous").GetComponent<Button>().onClick.AddListener(() => manager.PrevChoice());
        //bottomNavigation.transform.Find("Next").GetComponent<Button>().onClick.AddListener(() => manager.NextChoice());
        //InitializeFeatureButtons();
    }


    private int GetFeatureIndex (Button b) {
        if (b.name == "Ears Button") {
            return 0;
        } else if (b.name == "Eyes Button") {
            return 1;         
        } else if (b.name == "Nose Button") {
            return 2;
        }
        else {
            return 3;
        }
    }

    private Button GetButtonByIndex (int i) {
        if (i == 0)
        {
            return earsButton;
        }
        else if (i == 1)
        {
            return eyesButton;
        }
        else if (i == 2)
        {
            return noseButton;
        }
        else
        {
            return mouthButton;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        EventSystem.current.SetSelectedGameObject(GetButtonByIndex(manager.currentFeature).gameObject);
        //UpdateFeatureButtons();
        //descText.text = manager.features[manager.currentFeature].ID + " #" + (manager.features[manager.currentFeature].currentIndex + 1).ToString();
        //Debug.Log("Update: descText is " + descText.text);
    }


    /*
    private void InitializeFeatureButtons()
    {
        buttons = new List<Button>();

        float height = ears.rect.height;
        float width = ears.rect.width;

        for (int i = 0; i < manager.features.Count; i++)
        {
            RectTransform temp = Instantiate<RectTransform>(ears);
            temp.name = i.ToString();
            temp.SetParent(transform.Find("Features").GetComponent<RectTransform>());
            temp.localScale = new Vector3(1, 1, 1);
            temp.localPosition = new Vector3(0, 0, 0);
            temp.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, width);
            temp.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, i * height, height);

            Button b = temp.GetComponent<Button>();
            b.onClick.AddListener(() => manager.SetCurrent(int.Parse(temp.name)));
            buttons.Add(b);
        } 
    }

    void UpdateFeatureButtons()
    {
        for (int i = 0; i < manager.features.Count; i++)
        {
            // first get the feature name and get the image that matches
            string featureName = manager.features[i].ID;
            Debug.Log("UpdateFeatureButtons: featureName is " + featureName);
            //buttons[i].transform.Find(featureName).GetComponent<Image>().sprite = manager.features[i].renderer.sprite;
            buttons[i].transform.Find("earicondial").GetComponent<Image>().sprite = manager.features[i].renderer.sprite;
        } 
    } */


}
