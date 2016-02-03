using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using System;

[RequireComponent(typeof(TapGesture))]
public class TraitInteraction : MonoBehaviour {

	public GameObject tooltip;

	private TapGesture tapBack;

	private void OnEnable()
	{
		tapBack = GetComponent<TapGesture> ();
		tapBack.Tapped += tappedHandler;
	}

	private void OnDisable()
	{
		tapBack.Tapped -= tappedHandler;
	}

	private void tappedHandler(object sender, EventArgs e)
	{
		Debug.Log ("Got a Tap");
		TraitToolTipData text = tooltip.GetComponent<TraitToolTipData> ();
		// get the trait's name here somehow
		// "Gender" is just filler for now
		text.tooltipText.text = "Gender";
		tooltip.SetActive(true);
	}
}

