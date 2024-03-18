namespace Blazr.PreRenderState.Components;

public class PreRenderAppState
{
    public const string TokenName = "IPAddress";

    public string RemoteIPAddress { get; set; } = "Not Set";

    public void Load(PreRenderAppState state)
    {
        this.RemoteIPAddress = state.RemoteIPAddress;
    }
}
