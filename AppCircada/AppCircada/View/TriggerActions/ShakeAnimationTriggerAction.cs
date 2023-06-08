namespace AppCircada.View.TriggerActions;

class ShakeAnimationTriggerAction : TriggerAction<VisualElement>
{
    protected async override void Invoke(VisualElement element)
    {
        await element.ScaleTo(0.85, 75, Easing.CubicInOut);
        await element.TranslateTo(-10,0,70,Easing.CubicInOut);
        await element.TranslateTo(10, 0, 70, Easing.CubicInOut);
        await element.TranslateTo(-10, 0, 70, Easing.CubicInOut);
        await element.TranslateTo(10, 0, 70, Easing.CubicInOut);
        await element.TranslateTo(0, 0, 70, Easing.CubicInOut);
        await element.ScaleTo(1, 75, Easing.CubicIn);
    }
}
