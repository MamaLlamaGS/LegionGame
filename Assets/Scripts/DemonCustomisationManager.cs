using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// makes this run even when not playing the game
[ExecuteInEditMode]
public class DemonCustomisationManager : MonoBehaviour
{

    // this class comes from https://www.youtube.com/watch?v=xoIagG1RVeE

    // all the sprites need to be named consecutively (ie, face_0, face_1)

    public List <Feature> features;
    public int currentFeature;
    private GameObject face;

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
        //Debug.Log("LoadFeatures: face is " + face.name);
        features.Add(new Feature("Ears", face.transform.Find("Ears").GetComponent<SpriteRenderer>()));
        //Debug.Log("LoadFeatures: Ears is " + face.transform.Find("Ears").name);
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
        }
    }

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
        //Debug.Log("PrevChoice(0): inside");
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
}
