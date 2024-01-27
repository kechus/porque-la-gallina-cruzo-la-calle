using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;
	
	// How long the object should shake for.
	public float shakeDuration = 0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.25f;
	public float decreaseFactor = 1.0f;
	GameObject player;
	
	Vector3 originalPos;
	
	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}
	
	void OnEnable()
	{
        originalPos = camTransform.localPosition;
	}

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
	{
		if (shakeDuration > 0)
		{
			camTransform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10) + Random.insideUnitSphere * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			camTransform.position = new Vector3(player.transform.position.x, originalPos.y, -10);
        }
	}
}