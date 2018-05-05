using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangingColor : MonoBehaviour
{
    public GameObject panel;

    public SpriteRenderer head;
    public SpriteRenderer body;
    public Image buttonColorDisplay; //creation and connection of buttons to color

    public Image squareHeadDisplay; //creation and connection of buttons to color
                                    // array of colors
    public Color[] colors;

    public int whatColor = 0;


    private void Update()
    {
        buttonColorDisplay.color = head.color;

        for (int i = 1; i < colors.Length; i++)
        {
            if (i == whatColor)
            {
                head.color = colors[i];
                body.color = colors[i];
                Debug.Log("Update: whatColor index is " + i);
                //Debug.Log ("Update: whatColor index is " + colors[i]);
                head.color = colors[i];
                //body.color =colors[i]
                Debug.Log("Update: whatColor index is " + colors[i]);
            }
        }
    }

    public void ChangePanelState(bool state)
    {
        panel.SetActive(state);
        // Debug.Log ("Update: ChangePanelState state is " + state);
    }

    // change color of Demon
    public void ChangeDemonColor(int index)
    {
        //Debug.Log ("ChangeDemonColor: index is " + index);
        whatColor = index;
        //Debug.Log ("ChangeDemonColor: whatColor is " + whatColor);
    }




	public void Start()
	{
        head = GameObject.Find("Face").GetComponent<SpriteRenderer>();
        body = GameObject.Find("Body").GetComponent<SpriteRenderer>();

	}
}

