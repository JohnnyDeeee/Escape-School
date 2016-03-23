using UnityEngine;

public abstract class Interactable : MonoBehaviour {

    public bool highlight = false;
    private Color originalColor;
    private MeshRenderer mRenderer;

	void Start () {
        mRenderer = GetComponent<MeshRenderer>();
        originalColor = mRenderer.material.color;
        tag = "Interactable";
	}
	
	void Update () {
        if (highlight)
        {
            mRenderer.material.color = Color.red;
        }
        else
        {
            mRenderer.material.color = originalColor;
        }
	}

    public abstract void Action();
}
