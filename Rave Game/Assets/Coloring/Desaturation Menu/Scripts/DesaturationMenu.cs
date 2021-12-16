using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DesaturationMenu : MonoBehaviour, IIDSettable
{
    [SerializeField] private Mediator _mediator;
    [SerializeField] private Palette _palette;
    [SerializeField] private TextMeshProUGUI _countOutput;
    private CloseMenusCommand _closeCommand = new CloseMenusCommand();
    private Branch _branch;

    private void Awake()
    { 
        _mediator.Subscribe<OpenMenuCommand<Branch>>(SetMenuData);
    }

    private void Start()
    {
        SetMenuInControllerComand command = new SetMenuInControllerComand();
        command.IDSettable = this;
        command.Transform = this.gameObject.transform;
        _mediator.Publish(command); 
    }

    public void SetID(string id)
    {
        _closeCommand.IDs.Add(id);
    }

    private void SetMenuData(OpenMenuCommand<Branch> callback)
    {
        _branch = callback.Object;
        UpdateDesaturation();
    }

    public void CloseMenu()
    {
        _mediator.Publish(_closeCommand);
    }

    private void UpdateDesaturation()
    {
        _countOutput.text = _palette.GetDesaturationCount().ToString();
    }

    public void Desaturate() 
    {
        if(_palette.UseDesaturation())
        {
            _branch.UncolorizeLeafs();
            UpdateDesaturation();
            CloseMenu();
        }
        else
        {
            CantColorize();
        }
    }

    private void CantColorize()
    {
        Debug.Log("Cant Desaturate");
    }
}
