using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using System;

[RequireComponent(typeof(TapGesture))]
public class TraitInteraction : MonoBehaviour {

    private SpriteRenderer Icon;

	private TraitToolTipData tooltip;
    private CharacterCore chara;
	private GameObject background;

    private Trait trait;
	private TapGesture tapBack;
	private TapGesture tap;

    public void Setup(CharacterCore chara, TraitToolTipData ttip, Trait trait)
    {
        Icon = GetComponent<SpriteRenderer>();
        this.chara = chara;
        tooltip = ttip;
        this.trait = trait;
        Icon.sprite = trait.Icon;
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

        //tap.StateChanged += Tap_StateChanged;
		tap.Tapped += tappedHandler;
	}

    private void Tap_StateChanged(object sender, GestureStateChangeEventArgs e)
    {
        Debug.Log(gameObject.name + " " + e.State.ToString());
    }

    private void OnDisable()
	{
		tap.Tapped -= tappedHandler;
	}

	private void tappedHandler(object sender, EventArgs e)
	{
        //Debug.Log("tapped");
        tooltip.tooltipText.text = trait.TraitName;
		tooltip.gameObject.SetActive(true);
		tapBack.Tapped += tappedBackHandler;
	}

	private void tappedBackHandler(object sender, EventArgs e)
	{
		tooltip.gameObject.SetActive(false);
		tapBack.Tapped -= tappedBackHandler;
	}
}

