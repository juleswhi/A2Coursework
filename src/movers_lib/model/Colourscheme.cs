namespace movers_lib.model;

using MaterialSkin;
using state;
using Colour = Color;

public class Colourscheme
{
    public Primary Primary { get; set; }
    public Accent Secondary { get; set; }
    public Colour? Tertiary { get; set; }

    public static void LoadColourscheme()
    {
        LOG("LOADING COLOURSCHEME");
        var light = new ColorScheme(Blue300, Blue300, Blue300, Accent.Blue700, TextShade.BLACK);
        var dark = new ColorScheme(Red300, Red300, Red300, Accent.Red700, TextShade.BLACK);
        GlobalStateAdd(light.GetState(COLOURSCHEME, COLOURSCHEME_LIGHT));
        GlobalStateAdd(dark.GetState(COLOURSCHEME, COLOURSCHEME_DARK));
        GlobalStateAdd(dark.GetState(COLOURSCHEME_CURRENT));
    }

    public static void Toggle(ColorScheme colourscheme) 
    {
        //GlobalStateRemoveColorScheme();
        //GlobalStateAdd(colourscheme.GetState(COLOURSCHEME, COLOURSCHEME_CURRENT));
        //MaterialSkinManager.Instance.ColorScheme = (ColorScheme)GetGlobalState().GetFirst(COLOURSCHEME_CURRENT)!;
    }
}
