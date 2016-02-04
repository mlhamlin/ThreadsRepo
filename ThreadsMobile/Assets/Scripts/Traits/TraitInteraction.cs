using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using System;

[RequireComponent(typeof(TapGesture))]
public class TraitInteraction : MonoBehaviour {

	public GameObject tooltip;
	private GameObject background;

	private TapGesture tapBack;
	private TapGesture tap;

    public void Start()
    {

    }

    private void OnEnable()
	{
        if(tap == null)
        {
            tap = GetComponent<TapGesture>();
        }

        if (background == null)
        {
            background = Background.Instance.gameObject;
            tapBack = background.GetComponent<TapGesture>();
        }

		tap.Tapped += tappedHandler;
	}

	private void OnDisable()
	{
		tap.Tapped -= tappedHandler;
	}

	private void tappedHandler(object sender, EventArgs e)
	{
		TraitToolTipData text = tooltip.GetComponent<TraitToolTipData> ();
		// get the trait's name here somehow
		// "Gender" is just filler for now
		text.tooltipText.text = "Gender";
		tooltip.SetActive(true);
		tapBack.Tapped += tappedBackHandler;
	}

	private void tappedBackHandler(object sender, EventArgs e)
	{
		tooltip.SetActive(false);
		tapBack.Tapped -= tappedBackHandler;
	}
}

