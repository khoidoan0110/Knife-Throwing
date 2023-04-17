using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float duration;

    private SpriteRenderer spriteRenderer;
    private Material defaultMaterial;
    private Coroutine flashCoroutine;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMaterial = spriteRenderer.material;
        flashMaterial = new Material(flashMaterial);
    }

    private IEnumerator FlashCoroutine(){
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = defaultMaterial;
        flashCoroutine = null;
    }

    public void Flash(){
        if(flashCoroutine != null){
            StopCoroutine(flashCoroutine);
        }
        flashCoroutine = StartCoroutine(FlashCoroutine());
    }
}
