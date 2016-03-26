using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {

    public bool highlight = false;
    [SerializeField] private List<GameObject> objectsToColor;
    private List<KeyValuePair<GameObject, Color>> objectsWithOriginalColor;

	void Start () {
        //Make a list that has as Key: GameObject and Value: original Color
        objectsWithOriginalColor = new List<KeyValuePair<GameObject, Color>>();
        foreach (GameObject obj in objectsToColor)
        {
            objectsWithOriginalColor.Add(new KeyValuePair<GameObject, Color>(obj, obj.GetComponent<MeshRenderer>().material.color));
        }

        //Give parent and all childs the "interactable" tag
        tag = "Interactable";
    }
	
	void Update () {
        if (highlight)
        {
            //Make all objects color red
            foreach (KeyValuePair<GameObject, Color> pair in objectsWithOriginalColor)
            {
                pair.Key.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
        else
        {
            //Reset all objects color
            foreach (KeyValuePair<GameObject, Color> pair in objectsWithOriginalColor)
            {
                pair.Key.GetComponent<MeshRenderer>().material.color = pair.Value;
            }
        }
	}

    public abstract void Action();
}
