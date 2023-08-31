using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;

    [SerializeField] MeshRenderer[] _meshRenderer;

    void OnCollisionEnter(Collision other)
    {
        Debug.Log($"{gameObject.name} bumped into something.");
        gameObject.GetComponent<PlayerControllerScript>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        _particleSystem.Play();
        for (int i = 0; i < _meshRenderer.Length; i++)
        {
            _meshRenderer[i].enabled = false;
        }
        StartCoroutine(WaitBeforeReloar());
    }

    public IEnumerator WaitBeforeReloar()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
}
