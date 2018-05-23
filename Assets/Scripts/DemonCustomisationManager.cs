using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// makes this run even when not playing the game
[ExecuteInEditMode]
public class DemonCustomisationManager : MonoBehaviour
{

    // this class comes from https://www.youtube.com/watch?v=xoIagG1RVeE

    private int levelIndex;
    private GameManager gameManager;

    public List <Feature> features;
    public int currentFeature;
    private GameObject face;
    public Image buttonColourDisplay; //creation and connection of buttons to color
    private Color[] colours;
    public int whatColour = 0;
    public SpriteRenderer head;
    public SpriteRenderer body;
    private Color currentColour;

    private void Start()
    {
        body = GameObject.Find("Body").GetComponent<SpriteRenderer>();
        gameManager = GameManager.instance;
        levelIndex = gameManager.GetLevel();
        currentColour = SetDefaultColourForLevel(levelIndex);

    }

    private Color SetDefaultColourForLevel (int iLevel) {
        // need to get real values from bosses heads in RGBA and use Color32 instead
        //Level 1 is hot pink
        if (iLevel == 0)
        {
            return Color.magenta;
        }
        //Level 2 is mustard yellow
        else if (iLevel == 1)
        {
            return Color.yellow;
        }
        //Level 3 is intense purple
        else if (iLevel == 2)
        {
            return Color.gray;
        }
        //Level 4 is bright green
        else if (iLevel == 3)
        {
            return Color.green;
        }
        //Level 5 is red
        else
        {
            return Color.red;
        }
    }

    void OnEnable()
    {
        LoadFeatures();
    }

    void OnDisable()
    {
        SaveFeatures();
    }

    // get the group of features from the assets themselves
    void LoadFeatures()
    {
        features = new List <Feature>();
        face = GameObject.Find("Demon/Face");
        head = face.GetComponent<SpriteRenderer>();
        features.Add(new Feature("Ears", face.transform.Find("Ears").GetComponent<SpriteRenderer>()));
        features.Add(new Feature("Eyes", face.transform.Find("Eyes").GetComponent<SpriteRenderer>()));
        features.Add(new Feature("Nose", face.transform.Find("Nose").GetComponent<SpriteRenderer>()));
        features.Add(new Feature("Mouth", face.transform.Find("Mouth").GetComponent<SpriteRenderer>()));
        //features.Add(new Feature("ArmsWings", transform.Find("ArmsWings").GetComponent<SpriteRenderer>()));
        //features.Add(new Feature("Feet", transform.Find("Feet").GetComponent<SpriteRenderer>()));
        //features.Add(new Feature("Body", transform.Find("Body").GetComponent<SpriteRenderer>()));


        if (features.Count != null) {
            for (int i = 0; i < features.Count; i++)
            {
                string key = "FEATURE_" + i;
                if (!PlayerPrefs.HasKey(key))
                    PlayerPrefs.SetInt(key, features[i].currentIndex);
                features[i].currentIndex = PlayerPrefs.GetInt(key);
                features[i].UpdateFeature();
            }
          
        }
    }

    void SaveFeatures()
    {
        for (int i = 0; i < features.Count; i++)
        {
            string key = "FEATURE_" + i;
            PlayerPrefs.SetInt(key, features[i].currentIndex);
        }
        PlayerPrefs.Save();
    }

    // set the feature type based on the feature icon button
    public void SetCurrentFeatureType(int index)
    {
        if (features == null)
        {
            return;
        }
        else
        {
            currentFeature = index;
            NextChoice(index);
        }
    }

    // reaction to next feature button
    public void NextChoice(int iFeature)
    {
        if (features == null)
            return;
        features[iFeature].currentIndex++;
        features[iFeature].UpdateFeature();
    }

    // change color of Demon
    public void ChangeDemonColour()
    {
        whatColour++;
        Debug.Log ("ChangeDemonColour: whatColour is " + whatColour);
        UpdateColour(whatColour);
    }

    public void UpdateColour(int iColour)
    {
        buttonColourDisplay.color = colours[iColour];

        for (int i = 1; i < colours.Length; i++)
        {
            if (i == whatColour)
            {
                head.color = colours[i];
                body.color = colours[i];
                Debug.Log("Update: whatColour index is " + i);
                //Debug.Log ("Update: whatColour index is " + colours[i]);
            }
        }
    }



    // makes it so it can be seen in the Inspector
    [System.Serializable]
    // Feature class within
    public class Feature
    {
        public string ID;
        public int currentIndex;
        public Sprite[] choices;
        public SpriteRenderer renderer;

        public Feature(string id, SpriteRenderer rend)
        {
            ID = id;
            renderer = rend;
            UpdateFeature();
        }


        public void UpdateFeature()
        {
            // goes to get the list of choices from what is available from the Assets/Sprites folder
            choices = Resources.LoadAll<Sprite>("DemonParts/" + ID);
            if (choices == null || renderer == null)
            {
                return;
            }
            if (currentIndex < 0)
            {
                currentIndex = choices.Length - 1;
            }

            if (currentIndex >= choices.Length)
            {
                currentIndex = 0;
            }

            renderer.sprite = choices[currentIndex];
        }
    }



    /*
    // reaction to next feature button
    public void NextChoice()
    {
        if (features == null)
            return;
        features[currentFeature].currentIndex++;
        features[currentFeature].UpdateFeature();
    }

    // reaction to previous feature button
    public void PrevChoice()
    {
        if (features == null)
            return;
        features[currentFeature].currentIndex--;
        features[currentFeature].UpdateFeature();
    }
    */


}
