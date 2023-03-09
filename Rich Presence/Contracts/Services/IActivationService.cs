namespace Rich_Presence.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
