using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehavior : MonoBehaviour
{
    private Palette _palette;

    public void Init(Palette palette)
    {
        _palette = palette;
    }
    
    public void Despawn()
    {
        Destroy(gameObject);
    }
}
