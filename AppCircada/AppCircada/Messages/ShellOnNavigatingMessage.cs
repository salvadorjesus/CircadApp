using CommunityToolkit.Mvvm.Messaging.Messages;

namespace AppCircada.Messages;

public class ShellOnNavigatingMessage : ValueChangedMessage<ShellNavigatingEventArgs>
{
    public ShellOnNavigatingMessage(ShellNavigatingEventArgs value) : base(value)
    {
    }
}

