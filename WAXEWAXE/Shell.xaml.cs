using Intense.Presentation;
using System;
using System.Linq;
using Windows.UI.Xaml.Controls;
using WAXEWAXE.Pages;
using WAXEWAXE.Presentation;

namespace WAXEWAXE
{
    public sealed partial class Shell : UserControl
    {
        public Shell()
        {
            this.InitializeComponent();

            var vm = new ShellViewModel();
            vm.TopItems.Add(new NavigationItem { Icon = Constants.GlyphIcons.CollectionGlyph, DisplayName = "Collection", PageType = typeof(CollectionPage) });
            vm.TopItems.Add(new NavigationItem { Icon = Constants.GlyphIcons.PlaylistsGlyph, DisplayName = "Playlists", PageType = typeof(PlaylistsPage) });
            vm.TopItems.Add(new NavigationItem { Icon = Constants.GlyphIcons.StatisticsGlyph, DisplayName = "Statistics", PageType = typeof(StatisticsPage) });

            vm.BottomItems.Add(new NavigationItem { Icon = "", DisplayName = "Settings", PageType = typeof(SettingsPage) });

            // select the first top item
            vm.SelectedItem = vm.TopItems.First();

            this.ViewModel = vm;
        }

        public ShellViewModel ViewModel { get; private set; }

        public Frame RootFrame
        {
            get
            {
                return this.Frame;
            }
        }
    }
}
