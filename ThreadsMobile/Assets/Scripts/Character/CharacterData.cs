using UnityEngine;
using System.Collections.Generic;

public class CharacterData : MonoBehaviour {

    public int Gender = 200; //Cis-Woman
    public int MaxRelationships = 1;

    //first element in each Vector2 is the trait # 
    //second is the degree: 0, 1, 2, or 3
    public List<Vector2> traits;
    public List<Vector2> likes;
    public List<Vector2> dislikes;

    public List<CharacterData> PlatonicPartners;
    public List<CharacterData> RomanticPartners;
    public List<CharacterData> SexualPartners;

    public RelationshipWeb currentShipWeb;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
