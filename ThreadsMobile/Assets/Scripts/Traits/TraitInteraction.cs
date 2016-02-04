using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using System;

[RequireComponent(typeof(TapGesture))]
public class TraitInteraction : MonoBehaviour {

	public TraitToolTipData tooltip;
    private CharacterCore chara;
	private GameObject background;

    private Trait trait;
	private TapGesture tapBack;
	private TapGesture tap;

    public void Setup(CharacterCore chara, TraitToolTipData ttip, Trait trait)
    {
        this.chara = chara;
        tooltip = ttip;
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
		// get the trait's name here somehow
		// "Gender" is just filler for now
		tooltip.tooltipText.text = "Gender";
		tooltip.gameObject.SetActive(true);
		tapBack.Tapped += tappedBackHandler;
	}

	private void tappedBackHandler(object sender, EventArgs e)
	{
		tooltip.gameObject.SetActive(false);
		tapBack.Tapped -= tappedBackHandler;
	}
}

