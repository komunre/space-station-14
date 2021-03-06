using System;
using Content.Shared.GameObjects.Components.Observer;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.GameObjects.Components.Observer
{
    [GenerateTypedNameReferences]
    public partial class GhostRolesEntry : VBoxContainer
    {
        public GhostRolesEntry(GhostRoleInfo info, Action<BaseButton.ButtonEventArgs> requestAction)
        {
            RobustXamlLoader.Load(this);

            Title.SetMessage(info.Name);
            Description.SetMessage(info.Description);
            RequestButton.OnPressed += requestAction;
        }
    }
}
