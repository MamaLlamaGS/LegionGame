using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingColor : MonoBehaviour
{
    public GameObject panel;

    public SpriteRenderer head;
    //public SpriteRenderer body;

    public Image squareHeadDisplay; //creation and connection of buttons to color

    public Color[] colors;
    
    public int whatColor = 0;
    

    private void Update()
    {
        squareHeadDisplay.color = head.color; //creation and connection of buttons to color

        for (int i= 1; i < colors.Length; i++)
        {
            if (i == whatColor) {
                head.color = colors[i];
                //body.color =colors[i]
				Debug.Log ("Update: whatColor index is " + colors[i]);

            }
        }
        
    }

   public void ChangePanelState (bool state)
    {
        panel.SetActive(state);
		Debug.Log ("Update: ChangePanelState state is " + state);
    }

	
    public void changeDemonColor(int index)
    {
        whatColor = index;
    }
}

	