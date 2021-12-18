using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animals
{
    public class Animal : MonoBehaviour
    {
        [SerializeField] private AnimalBehavior _animalBehavior;
        private Mediator _mediator;
        private Palette _palette;
        private int _dayPassed;

        public void Init(Palette palette, Mediator mediator)
        {
            _palette = palette;
            _mediator = mediator;
            _dayPassed = 0;
            _palette.UnblockPaint(_animalBehavior.UnblockingPaint);
        }

        public void EndDay()
        {
            _dayPassed++;
            if(_dayPassed == _animalBehavior.Period)
                BringIncome();
        }

        private void BringIncome()
        {
            if(_animalBehavior.BringEssence == false)
            {
                _palette.ChangePaintCount(_animalBehavior.Paint.Name, _animalBehavior.Income);
            }
            else
            {
                GetEssenceCommand command = new GetEssenceCommand();
                command.Count = _animalBehavior.Income;
                _mediator.Publish(command);
            }
            _dayPassed = 0;
        }
        
        public void Despawn()
        {
            Destroy(gameObject);
        }
    }
}

