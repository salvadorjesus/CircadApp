namespace AppCircada.View.TriggerActions;

public class BounceAnimationTriggerAction : TriggerAction<VisualElement>
{
    protected async override void Invoke(VisualElement element)
    {
        await element.ScaleTo(0.85, 75, Easing.CubicInOut);
        await element.ScaleTo(1, 600, Easing.BounceOut);
    }
}
