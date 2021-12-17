using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private AnimalBehavior animalBehavior;
    private Mediator _mediator;
    private Palette _palette;
    private int _dayPassed;

    public void Init(Palette palette, Mediator mediator)
    {
        _palette = palette;
        _mediator = mediator;
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
        {
            _palette.ChangePaintCount(animalBehavior.Paint.Name, animalBehavior.Income);
        }
        else
        {
            GetEssenceCommand command = new GetEssenceCommand();
            command.Count = animalBehavior.Income;
            _mediator.Publish(command);
        }
        _dayPassed = 0;
    }
    
    public void Despawn()
    {
        Destroy(gameObject);
    }
}
