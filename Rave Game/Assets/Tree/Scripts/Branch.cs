using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour, IWithPosition
{
    [SerializeField] private Mediator _mediator;
    [SerializeField] private Transform _transform;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private List<Leaf> _leafs;

    private void Start() 
    {
        _mediator.Subscribe<LeafColorizedCommand>(CheckForCombination);
        _collider.enabled = false;
    }
    
    private void CheckForCombination(LeafColorizedCommand callback)
    {
        CombinationIsAssembledCommand command = new CombinationIsAssembledCommand();
        if(_leafs.Contains(callback.Leaf))
        {
            _collider.enabled = true;
            foreach(Leaf leaf in _leafs)
                if(leaf.Colorized)
                    command.Paints.Add(leaf.Paint);
            if(command.Paints.Count == _leafs.Count)
            {
                command.AddCombination = true;
                _mediator.Publish(command);
            } 
        }
    }

    public Vector3 GetPosition()
    {
        return _transform.position;
    }

    public void UncolorizeLeafs()
    {
        _collider.enabled = false;
        foreach(Leaf leaf in _leafs)
            leaf.Uncolorize();
    }
}
