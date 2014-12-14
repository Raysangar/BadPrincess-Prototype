using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {
    public int life;
    public Slider visualLife;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        visualLife.value = life;
	}
}
