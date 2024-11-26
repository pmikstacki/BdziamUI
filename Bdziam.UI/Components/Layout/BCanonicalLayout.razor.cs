﻿using System.Drawing;
using Bdziam.UI.Model.Enums;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BCanonicalLayout
{ 
    [Parameter] public RenderFragment? Body { get; set; }
    [Parameter] public ColorVariant LayoutColor { get; set; }
    [Parameter] public int Elevation { get; set; } = 0;
    private bool IsDrawerOpen { get; set; } = false;
    [Parameter] public RenderFragment? DrawerMenuContent { get; set; }
    [Parameter] public RenderFragment? LeftTopBarContent { get; set; }
    [Parameter] public RenderFragment? RightTopBarContent { get; set; }
    
    private Color SeedColor { get; set; }   
    private void ToggleDrawer()
    {
        IsDrawerOpen = !IsDrawerOpen;
    }

}