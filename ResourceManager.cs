using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceManager : MonoBehaviour {
    private int wood = 0;
    private int stone = 200;
    private int iron = 0;
    public Text ironText;
    public Text woodText;
    public Text stoneText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ironText.text = iron.ToString();
        woodText.text = wood.ToString();
        stoneText.text = stone.ToString();
	}

    public void addStone(int amount)
    {
        stone += amount;
    }

    public void addWood(int amount)
    {
        wood += amount;
    }

    public void addIron(int amount)
    {
        iron += amount;
    }
}
