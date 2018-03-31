using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingColor : MonoBehaviour
{
    public GameObject panel;

    public SpriteRenderer head;
    public SpriteRenderer body;
    //public Image squareHeadDisplay; //creation and connection of buttons to color

	public Color[] colors;
    
    public int whatColor = 1;

	public void OpenPanel() {
		Debug.Log ("ChangingColor: OpenPanel");

		panel.SetActive (true);

	}

	public void ClosePanel() {
		Debug.Log ("ChangingColor: ClosePanel");
		panel.SetActive (false);

	}

    private void Update()
    {
		//squareHeadDisplay.color = head.color; //creation and connection of buttons to color

        for (int i= 0; i < colors.Length; i++)
        {
            if (i == whatColor) {
                head.color = colors[i];
                body.color = colors[i];//connection to both body and face?
            }
        }
    }
		

   public void ChangePanelState (bool state)
    {
        panel.SetActive(true); // whether panel is visible
    }

    public void changeDemonColor(int index)
    {
		Debug.Log ("ChangeColor: changeDemonColor and index is " + index);
        whatColor = index;
    }
}

	