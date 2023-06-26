using System;
using System.Diagnostics;
using System.Numerics;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GetPointerPositionPropertySet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ElementCompositionPreview.SetIsTranslationEnabled(Box, true);
            var boxCompositor = ElementCompositionPreview.GetElementVisual(Box).Compositor;
            var rectPointerState = ElementCompositionPreview.GetPointerPositionPropertySet(BoxContainer);

            var anim = boxCompositor.CreateExpressionAnimation("hover.Position.Y");
            anim.SetReferenceParameter("hover", rectPointerState);
            anim.Target = "Translation.Y";
            Box.StartAnimation(anim);
        }
    }
}
