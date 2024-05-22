namespace Material.Components.Maui;

class IconButtonDrawable(IconButton view) : IDrawable
{
    public void Draw(ICanvas canvas, RectF rect)
    {
        canvas.SaveState();
        canvas.Antialias = true;
        canvas.ClipPath(view.GetClipPath(rect));

        canvas.DrawBackground(view, rect);
        canvas.DrawOutline(view, rect);

        var scale = rect.Height / 40f;
        canvas.DrawIcon(view, rect, 24, scale);
        canvas.DrawOverlayLayer(view, rect);

        canvas.DrawStateLayer(view, rect, view.ViewState);
        if (view.RipplePercent is not 0f)
            canvas.DrawRipple(
                view,
                view.LastTouchPoint,
                view.RippleSize,
                view.RipplePercent
            );

        canvas.ResetState();
    }
}
