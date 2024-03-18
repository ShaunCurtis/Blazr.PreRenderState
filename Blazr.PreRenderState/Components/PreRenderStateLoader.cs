using Microsoft.AspNetCore.Components;

namespace Blazr.PreRenderState.Components;

public class PreRenderStateLoader : ComponentBase
{
    [Inject] public PreRenderAppState AppState { get; set; } = default!;
    [Inject] public PersistentComponentState ApplicationState { get; set; } = default!;

    private bool _subsequentRender;

    // Short circuit all the lifecycle stuff - we don't need it
    public override Task SetParametersAsync(ParameterView parameters)
    {
        if (_subsequentRender)
            return Task.CompletedTask;

        // if not prerender, try and get the persisted value
        if (this.ApplicationState.TryTakeFromJson<PreRenderAppState>(PreRenderAppState.TokenName, out var state))
        {
            if (state is not null)
                this.AppState.Load(state);
        }

        _subsequentRender = true;
        return Task.CompletedTask;
    }
}
