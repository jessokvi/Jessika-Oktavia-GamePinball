using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Collider bola;
    public KeyCode input;

    public float maxTimeHold;
    public float maxforce;

    public Material normalMaterial; // Tambahkan material ini di editor Unity
    public Material holdingMaterial;

    private Renderer launcherRenderer;
    private bool isHold = false;

    private void Start() 
    {
        launcherRenderer = GetComponent<Renderer>();

        // Set material awal
        launcherRenderer.material = normalMaterial;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == bola)
        {
            Debug.Log("OnCollisionStay: Bola is colliding with " + bola.name);
            ReadInput(bola);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !isHold)
        {
            Debug.Log("ReadInput: Key " + input.ToString() + " is pressed");
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;

        float force = 0.0f;
        float timeHold = 0.0f;

         launcherRenderer.material = holdingMaterial;

        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxforce, timeHold/maxTimeHold);

            Debug.Log("StartHold: Holding with force " + force.ToString() + " and time held: " + timeHold.ToString());

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }

        launcherRenderer.material = normalMaterial;

        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;

        Debug.Log("StartHold: Released. Adding force to the ball: " + (Vector3.forward * force).ToString());

    }
}
