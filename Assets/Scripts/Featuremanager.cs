using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Featuremanager : MonoBehaviour
{
    public List<Feature> features;
    public int currFeature;

    private void OnEnable()
    {
        LoadFeatures();
    }
    private void OnDisable()
    {
        SaveFeatures();
    }
    void LoadFeatures()
    {
        features = new List<Feature>();
        //features.Add(new Feature("Face", transform.Child("Face").GetComponent<SpriteRenderer>()))
        //features.Add(new Feature("Ears", transform.Child("Face").findChild("Hair")GetComponent<SpriteRenderer>()))
        //features.Add(new Feature("Eyes", transform.Child("Face").findChild("Eyes")GetComponent<SpriteRenderer>()))
        //features.Add(new Feature("Mouth", transform.Child("Face").findChild("Mouth")GetComponent<SpriteRenderer>()))
    }
    void SaveFeatures()
    {

    }

    public void SetCurrent(int index)
    {
        if (features == null)
            return;
        currFeature = index;
    }

    public void NextChoice(){
    	if (features == null)
    		return;
    	features[currFeature].currIndex ++;
		features [currFeature].UpdateFeature ();
	}

    public void PreviousChoice(){
    	if (features == null)
    		return;
    	features[currFeature].currIndex --;
		features [currFeature].UpdateFeature ();
	}



    [System.Serializable]
    public class Feature
    {
        public string ID;
        public int currIndex;
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
            choices = Resources.LoadAll<Sprite>("Textures/" + ID);

            if (choices == null || renderer == null)
                return;
        }
    }
}
