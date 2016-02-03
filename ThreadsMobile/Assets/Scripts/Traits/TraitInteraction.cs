using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using System;

[RequireComponent(typeof(TapGesture))]
public class TraitInteraction : MonoBehaviour {

	public GameObject tooltip;
	public GameObject Background;

	private TapGesture tapBack;
	private TapGesture tap;

	private void OnEnable()
	{
		tap = GetComponent<TapGesture> ();
		tapBack = Background.GetComponent<TapGesture>();
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

