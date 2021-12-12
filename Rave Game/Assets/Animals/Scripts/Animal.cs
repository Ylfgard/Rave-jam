using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private AnimalBehavior animalBehavior;
    private Palette _palette;
    private int _dayPassed;

    public void Init(Palette palette)
    {
        _palette = palette;
        _dayPassed = 0;
    }

    public void EndDay()
    {
        _dayPassed++;
        if(_dayPassed == animalBehavior.Period)
            BringIncome();
    }

    private void BringIncome()
    {
        if(animalBehavior.BringEssence == false)
            _palette.ChangePaintCount(animalBehavior.Paint.Name, animalBehavior.Income);
        else
            Debug.Log("Bring essence " + animalBehavior.Income);
        _dayPassed = 0;
    }
    
    public void Despawn()
    {
        Destroy(gameObject);
    }
}
